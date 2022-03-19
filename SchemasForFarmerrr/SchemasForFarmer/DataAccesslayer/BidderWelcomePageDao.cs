using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SchemasForFarmer.Models;
using SchemasForFarmer.DataAccesslayer;

namespace SchemasForFarmer.DataAccesslayer
{
    public class BidderWelcomePageDao : IBidderWelcomePageDao
    {

        public bool AddBidderDetail(BidderWelcomePage bidder)
        {
            bool status = false;

            try
            {
                using (var db = new AgricultureContext())
                {
                    db.BidderWelcomePage.Add(bidder);
                    status = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return status;
        }

        public List<BidderWelcomePage> FetchAllDetails()
        {
            List<BidderWelcomePage> businessDetails = null;
            try
            {
                using (var db = new AgricultureContext())
                {
                    DbSet<BidderWelcomePage> allBidderDetails = db.BidderWelcomePage;
                    if (allBidderDetails.Count() > 0)
                    {
                        businessDetails =
                            allBidderDetails
                             .Select(
                                (BidderWelcomePage a) =>
                                     new BidderWelcomePage
                                     {
                                         CropName = a.CropName,
                                         CropType = a.CropType,
                                         BasePrice = a.BasePrice,
                                         CurrentBid = a.CurrentBid,
                                         Bidamount = a.Bidamount,
                                         UserId = a.UserId,

                                     }
                             )
                             .ToList<BidderWelcomePage>();

                    }
                }
                return businessDetails;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public BidderWelcomePage FetchDetailsById(int id)
        {
            BidderWelcomePage businessDetails = null;
            try
            {
                using (var db = new AgricultureContext())
                {
                    DbSet<BidderWelcomePage> alldetails = db.BidderWelcomePage;
                    var matchingDetails = alldetails.Where(p => p.UserId == id);
                    if (matchingDetails != null && matchingDetails.Count() > 0)
                    {
                        BidderWelcomePage p = matchingDetails.First<BidderWelcomePage>();
                        businessDetails = new BidderWelcomePage
                        {

                            CropName = p.CropName,
                            CropType = p.CropType,
                            BasePrice = p.BasePrice,
                            CurrentBid = p.CurrentBid,
                            Bidamount = p.Bidamount,
                            UserId = p.UserId,

                        };
                    }
                }
                return businessDetails;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public bool InsertBidderInfo(BidderWelcomePage p)
        {
            int result = 0;
            try
            {
                using (var db = new AgricultureContext())
                {
                    DbSet<BidderWelcomePage> allInfo = db.BidderWelcomePage;
                    BidderWelcomePage entityModelObject = new BidderWelcomePage
                    {
                        CropName = p.CropName,
                        CropType = p.CropType,
                        BasePrice = p.BasePrice,
                        CurrentBid = p.CurrentBid,
                        Bidamount = p.Bidamount,
                        UserId = p.UserId,

                    };
                    allInfo.Add(entityModelObject);
                    result = db.SaveChanges();
                }
                return result > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool InsertBidderInfo(BidderWelcomePageDao p)
        {
            throw new NotImplementedException();
        }

        List<BidderWelcomePageDao> IBidderWelcomePageDao.FetchAllDetails()
        {
            throw new NotImplementedException();
        }

        BidderWelcomePageDao IBidderWelcomePageDao.FetchDetailsById(int id)
        {
            throw new NotImplementedException();
        }
    }
}