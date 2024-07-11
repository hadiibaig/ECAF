using ECAF.INFRASTRUCTURE.Enums;
using ECAF.INFRASTRUCTURE.Models;
using ECAF.INFRASTRUCTURE.utils;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECAF.INFRASTRUCTURE.Repositories
{
    public class SiteCardRepository
    {

        private readonly ECAFEntities _db;

        public SiteCardRepository()
        {
            _db = new ECAFEntities();
        }
        public string CreateSiteCard(CreateSiteCard createSiteCard)
        {
            using (DbContextTransaction transaction = _db.Database.BeginTransaction())
            {
                try
                {
                    Random random = new Random();
                    string referenceNumber = random.Next(1000, 10000).ToString();

                    SiteCard siteCard = new SiteCard()
                    {
                        Name = createSiteCard.Name,
                        Address = createSiteCard.Address,
                        CreatedDate = DateTime.Now,
                        SiteCardType = (int)Categories.Created,
                        ReferenceNumber = referenceNumber,
                        IsDeleted = false,
                        PostCode = createSiteCard.PostCode,
                        UserId = createSiteCard.UserId
                    };

                    _db.SiteCards.Add(siteCard);
                    _db.SaveChanges();
                    if (createSiteCard.Customer != null)
                    {
                        createSiteCard.Customer.SiteCardId = siteCard.SiteCardId;
                        _db.Customers.Add(createSiteCard.Customer);
                    }
                    if (createSiteCard.FacilitiesManager != null)
                    {
                        createSiteCard.FacilitiesManager.SiteCardId = siteCard.SiteCardId;
                        _db.FacilitiesManagers.Add(createSiteCard.FacilitiesManager);
                    }
                    if (createSiteCard.SiteCardAmount != null)
                    {
                        createSiteCard.SiteCardAmount.SiteCardId = siteCard.SiteCardId;
                        _db.SiteCardAmounts.Add(createSiteCard.SiteCardAmount);
                    }
                    if (createSiteCard.SiteCardCharge != null && createSiteCard.SiteCardCharge.Count() > 0)
                    {
                        foreach (var siteCardCharge in createSiteCard.SiteCardCharge)
                        {
                            siteCardCharge.SiteCardId = siteCard.SiteCardId;
                            _db.SiteCardCharges.Add(siteCardCharge);
                        }

                    }
                    _db.SaveChanges();
                    Form form = new Form()
                    {
                        Description = siteCard.Name,
                        Status = (int)FormStatus.InProgress,
                        AssignedToMe = false,
                        DueDate = siteCard.CreatedDate.Value.AddDays(2),
                        SiteCardId = siteCard.SiteCardId
                    };
                    _db.Forms.Add(form);
                    _db.SaveChanges();
                    transaction.Commit();
                    ;
                    EmailService.SendEmail(_db.AspNetUsers.FirstOrDefault(x => x.Id == createSiteCard.UserId).Email , "New Site Card has been created"  , "New Site card has been created in ECAF with reference no# : " + referenceNumber);
                    return referenceNumber;
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    return "";
                }
            }

        }
        public string UpdateSiteCard(UpdateSiteCard updateSiteCard)
        {
            using (DbContextTransaction transaction = _db.Database.BeginTransaction())
            {
                try
                {
                    string referenceNumber = "";

                    string mainSiteCard = string.Empty;
                    foreach (var SiteCardCode in updateSiteCard.SiteCardCodes)
                    {
                        var existingSiteCard = _db.SiteCards.FirstOrDefault(x => x.ReferenceNumber == SiteCardCode.SiteCardCode);
                        if (existingSiteCard != null)
                        {
                            mainSiteCard = existingSiteCard.ReferenceNumber;
                            existingSiteCard.Name = SiteCardCode.SiteCardName;
                            foreach (var siteCardCharge in updateSiteCard.SiteCardCharge)
                            {
                                siteCardCharge.SiteCardId = existingSiteCard.SiteCardId;
                                _db.SiteCardCharges.Add(siteCardCharge);
                            }
                        }
                        referenceNumber = existingSiteCard.ReferenceNumber;
                        EmailService.SendEmail(_db.AspNetUsers.FirstOrDefault(x => x.Id == existingSiteCard.UserId).Email, "Site Card has been Updated", "Site card has been updated in ECAF with reference no# : " + existingSiteCard.ReferenceNumber);
                    }
                    _db.SaveChanges();
                    transaction.Commit();
                    return referenceNumber;
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    return "";
                }
            }

        }
        public string TerminateSiteCard(TerminateSiteCard terminateSiteCard)
        {
            using (DbContextTransaction transaction = _db.Database.BeginTransaction())
            {
                try
                {
                    var existingSiteCard = _db.SiteCards.FirstOrDefault(x => x.Name == terminateSiteCard.SiteCardName);
                    existingSiteCard.TerminationDate = DateTime.Parse(terminateSiteCard.SiteCardTerminatioDate);
                    existingSiteCard.CategoryId = (int)Categories.Terminated;
                    _db.SaveChanges();
                    transaction.Commit();
                    return existingSiteCard.ReferenceNumber;
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    return "";
                }
            }

        }
        public string CreateECAF(EcafForm ecaf)
        {
            using (DbContextTransaction transaction = _db.Database.BeginTransaction())
            {
                try
                {
                    Random random = new Random();
                    string referenceNumber = random.Next(1000, 10000).ToString();
                    _db.EcafForms.Add(ecaf);
                    _db.SaveChanges();
                    transaction.Commit();
                    return referenceNumber;
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    return "";
                }
            }

        }
        public List<EcafForm> GetEmployeesList()
        {
            try
            {
                return _db.EcafForms.ToList();
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public DashboardViewModel LoadDashboardData()
        {
            try
            {
                var comments = _db.Comments.AsEnumerable();
                var siteCards = _db.SiteCards.AsEnumerable();
                return new DashboardViewModel() { Comments = comments.Count() > 0 ? comments.ToList() : null, SiteCards = siteCards.Count() > 0 ? siteCards.ToList() : null };
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public FormsViewModel LoadFormsData()
        {
            try
            {
                var forms = _db.EcafForms.AsEnumerable();
                var siteCards = _db.SiteCards.AsEnumerable();
                return new FormsViewModel() { EcafForms = forms.Count() > 0 ? forms.ToList() : null, SiteCards = siteCards.Count() > 0 ? siteCards.ToList() : null };
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public FormDetailsViewModel GetFormBYCardId(long Id)
        {
            try
            {
                var form = _db.Forms.FirstOrDefault(x => x.SiteCardId == Id);
                var comments = _db.Comments.Where(commet => commet.FormId == form.FormId);
                var siteCard = _db.SiteCards.FirstOrDefault(x => x.SiteCardId == Id);
                var questions = _db.Questions.Where(x => x.FormId == form.FormId);
                return new FormDetailsViewModel()
                {
                    Form = form,
                    Comments = comments != null && comments.Count() > 0 ? comments.ToList() : null,
                    Category = Helpers.GetEnumDescription<Categories>(siteCard?.CategoryId ?? 1),
                    Name = siteCard.Name,
                    Status = Helpers.GetEnumDescription<FormStatus>(form?.Status ?? 1),
                    Questions = questions != null && questions.Count() > 0 ? questions.ToList() : null
                };
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public bool SaveComment(long id, string text, string userId)
        {
            using (DbContextTransaction transaction = _db.Database.BeginTransaction())
            {
                try
                {
                    Comment comment = new Comment()
                    {
                        Text = text,
                        FormId = id,
                        UserId = userId
                    };
                    _db.Comments.Add(comment);
                    _db.SaveChanges();
                    transaction.Commit();
                    return true;
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    return false;
                }
            }

        }
    }
}
