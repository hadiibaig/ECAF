using ECAF.INFRASTRUCTURE.Config;
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
    public class FormRepository
    {
        private readonly ECAFEntities _db;

        public FormRepository()
        {
            _db = new ECAFEntities();
        }

        public FormsViewModel LoadFormsData(string userId)
        {
            try
            {
                var ecafForms = _db.EcafForms.AsEnumerable();
                var siteCards = _db.SiteCards.AsEnumerable();
                var userRoles = _db.AspNetUsers.FirstOrDefault().AspNetRoles.ToList();
                if (userRoles.Select(x => x.Name).Contains(RoleNames.AccountManager))
                {
                    var assignedToMe = _db.Forms.Where(x => x.AssignedUser == userId && x.AssignedToMe.Value);
                    return new FormsViewModel()
                    {
                        EcafForms = ecafForms.Count() > 0 ? ecafForms.ToList() : null,
                        SiteCards = siteCards.Count() > 0 ? siteCards.ToList() : null,
                        AssignedToMeForms = assignedToMe.Count() > 0 ? assignedToMe.ToList() : null
                    };
                }
                else
                {
                    var assignedToMe = _db.Forms.Where(x => x.AssignedToMe.Value);
                    return new FormsViewModel()
                    {
                        EcafForms = ecafForms.Count() > 0 ? ecafForms.ToList() : null,
                        SiteCards = siteCards.Count() > 0 ? siteCards.ToList() : null,
                        AssignedToMeForms = assignedToMe.Count() > 0 ? assignedToMe.ToList() : null
                    };
                }

            }
            catch (Exception e)
            {
                return null;
            }
        }
        public FormDetailsViewModel GetFormBYCardId(long Id, string userId)
        {
            try
            {
                var form = _db.Forms.FirstOrDefault(x => x.SiteCardId == Id);
                var comments = _db.Comments.Where(commet => commet.FormId == form.FormId);
                var siteCard = _db.SiteCards.FirstOrDefault(x => x.SiteCardId == Id);
                var questions = _db.Questions.Where(x => x.FormId == Id);
                return new FormDetailsViewModel()
                {
                    Form = form,
                    Comments = comments != null && comments.Count() > 0 ? comments.ToList() : null,
                    Category = Helpers.GetEnumDescription<Categories>(siteCard?.CategoryId ?? 1),
                    Name = siteCard.Name,
                    Status = Helpers.GetEnumDescription<FormStatus>(form?.Status ?? 1),
                    Questions = questions != null && questions.Count() > 0 ? questions.ToList() : null,
                };
            }
            catch (Exception e)
            {
                return null;
            }
        }


        public List<FormPdf> GetCompletedForms()
        {
            var formsPdfs = _db.FormPdfs.AsQueryable();
            if (formsPdfs != null && formsPdfs.Count() > 0)
            {
                return formsPdfs.ToList();
            }
            else
            {
                return null;
            }

        }

        public List<Comment> GetCommentByFormId(long Id)
        {
            var comments = _db.Comments.Where(commet => commet.FormId == Id);
            if (comments.Any())
            {
                return comments.ToList();
            }
            else
            {
                return null;
            }

        }
        public bool ApproveForm(long Id , bool Approved)
        {
            var form = _db.Forms.FirstOrDefault(commet => commet.FormId == Id);
            if (form != null )
            {

                if (Approved)
                {
                    form.Status =(int) FormStatus.Completed;
                    _db.SaveChanges();


                    return true;
                }
                else
                {
                    form.Status = (int)FormStatus.Rejected;
                    _db.SaveChanges();


                    return false;
                }
            }
            else
            {
                return false;
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
        public bool SaveForm(SaveFormModel model , string link)
        {
            using (DbContextTransaction transaction = _db.Database.BeginTransaction())
            {
                try
                {
                    var formPdf = new FormPdf
                    {
                        FormId = model.FormId,
                        PdfPath = model.PdfPath,
                        CreatedAt = DateTime.Now,
                        SubmitterId = model.UserId
                    };

                    _db.FormPdfs.Add(formPdf);
                    _db.SaveChanges();
                    transaction.Commit();
                    var users = _db.AspNetRoles.Where(x => x.Name == RoleNames.AppraisalManager)?.Select(y => y.AspNetUsers)?.SelectMany(t => t);
                    if (users.Any())
                    {
                        var formDesc = _db.Forms.FirstOrDefault(x => x.FormId == model.FormId)?.Description;


                        users.ToList().ForEach(x =>
                        {

                            EmailService.SendEmail(x.Email,
                                "A form has been submitted in ECAF",
                                $"{formDesc} has been submitted. Please click on this link to approve this form: <a href=\"{link}\">Approve Form</a>");
                        });

                       // users.ToList().ForEach(x => EmailService.SendEmail(x.Email, "A form have been submitted in ECAF", formDesc + " has been submitted, Please click on this link to Approve this form LINK"));
                    }





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
