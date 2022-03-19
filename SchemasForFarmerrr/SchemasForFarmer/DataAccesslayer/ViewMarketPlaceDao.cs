using Microsoft.EntityFrameworkCore;
using SchemasForFarmer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using SchemasForFarmer.DataAccesslayer;
using SchemasForFarmer.BusinessAccessLayer;
using Microsoft.EntityFrameworkCore.Internal;

namespace SchemasForFarmer.DataAccesslayer
{
    public class ViewMarketPlaceDao : IViewmarketplace
    {
        /*public bool AddMarketPlaceDetail(ViewMarketPlace MarketDetails)
        {
            bool status = false;

            try
            {
                using (var db = new AgricultureContext())
                {
                    db.BidderWelcomePage.Add(MarketDetails);
                    status = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return status;
        }*/
        public List<ViewMarketPlace> FetchAllMarketDetails()
        {
            List<ViewMarketPlace> businessDetails = null;
            try
            {
                using (var db = new AgricultureContext())
                {
                    DbSet<ViewMarketPlace> allMarketPlaceDetails = db.ViewMarketPlace;
                    if (allMarketPlaceDetails.Count() > 0)
                    {
                        businessDetails =
                           allMarketPlaceDetails
                            .Select(
                               (ViewMarketPlace a) =>
                                    new ViewMarketPlace
                                    {
                                        CropName = a.CropName,
                                        CropType = a.CropType,
                                        BasePrice = a.BasePrice,
                                        CurrentBid = a.CurrentBid,
                                        UserId = a.UserId,

                                    }
                            )
                            .ToList<ViewMarketPlace>();

                    }
                }
                return businessDetails;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ViewMarketPlace FetchMarketDetailsById(int id)
        {
            ViewMarketPlace businessDetails = null;
            try
            {
                using (var db = new AgricultureContext())
                {
                    DbSet<ViewMarketPlace> alldetails = db.ViewMarketPlace;
                    var matchingDetails = alldetails.Where(p => p.UserId == id);
                    if (matchingDetails != null && matchingDetails.Count() > 0)
                    {
                        ViewMarketPlace p = matchingDetails.First<ViewMarketPlace>();
                        businessDetails = new ViewMarketPlace
                        {

                            CropName = p.CropName,
                            CropType = p.CropType,
                            BasePrice = p.BasePrice,
                            CurrentBid = p.CurrentBid,
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

        public bool InsertMarketPlaceInfo(ViewMarketPlace p)
        {
            int result = 0;
            try
            {
                using (var db = new AgricultureContext())
                {
                    DbSet<ViewMarketPlace> allInfo = db.ViewMarketPlace;
                    ViewMarketPlace entityModelObject = new ViewMarketPlace
                    {
                        CropName = p.CropName,
                        CropType = p.CropType,
                        BasePrice = p.BasePrice,
                        CurrentBid = p.CurrentBid,
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

        public bool InsertMarketPlaceInfo(ViewMarketPlaceDao p)
        {
            throw new NotImplementedException();
        }

        List<ViewMarketPlaceDao> IViewmarketplace.FetchAllMarketDetails()
        {
            throw new NotImplementedException();
        }

        ViewMarketPlaceDao IViewmarketplace.FetchMarketDetailsById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
