using ECAF.INFRASTRUCTURE.Enums;
using ECAF.INFRASTRUCTURE.Models;
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

        private readonly  ECAFEntities _db;

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

    }
}
