using Microsoft.EntityFrameworkCore;
using SchemasForFarmer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchemasForFarmer.DataAccesslayer
{
    public class ViewSoldCropHistoryDao: IViewSoldCropHistoryDao
    {
        public bool AddCropHistoryDetail(ViewSoldCropHistory history)
        {
            bool status = false;

            try
            {
                using (var db = new AgricultureContext())
                {
                    db.ViewSoldCropHistory.Add(history);
                    status = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return status;
        }


        public List<ViewSoldCropHistory> FetchAllHistoryDetails()
        {
            List<ViewSoldCropHistory> businessDetails = null;
            try
            {
                using (var db = new AgricultureContext())
                {
                    DbSet<ViewSoldCropHistory> allHistoryDetails = db.ViewSoldCropHistory;
                    if (allHistoryDetails.Count() > 0)
                    {
                        businessDetails =
                            allHistoryDetails
                             .Select(
                                (ViewSoldCropHistory a) =>
                                     new ViewSoldCropHistory
                                     {
                                         Date = a.Date,
                                         CropName = a.CropName,
                                         Quantity = a.Quantity,
                                         Msp = a.Msp,
                                         SolidPrice = a.SolidPrice,
                                         UserId = a.UserId,
                                         TotalPrice = a.TotalPrice,

                                     }
                             )
                             .ToList<ViewSoldCropHistory>();

                    }
                }
                return businessDetails;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ViewSoldCropHistory FetchHistoryById(int id)
        {
            ViewSoldCropHistory businessDetails = null;
            try
            {
                using (var db = new AgricultureContext())
                {
                    DbSet<ViewSoldCropHistory> alldetails = db.ViewSoldCropHistory;
                    var matchingDetails = alldetails.Where(p => p.UserId == id);
                    if (matchingDetails != null && matchingDetails.Count() > 0)
                    {
                        ViewSoldCropHistory p = matchingDetails.First<ViewSoldCropHistory>();
                        businessDetails = new ViewSoldCropHistory
                        {

                            Date = p.Date,
                            CropName = p.CropName,
                            Quantity = p.Quantity,
                            Msp = p.Msp,
                            SolidPrice = p.SolidPrice,
                            UserId = p.UserId,
                            TotalPrice = p.TotalPrice,

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

        public bool InsertCropHistoryInfo(ViewSoldCropHistory p)
        {
            int result = 0;
            try
            {
                using (var db = new AgricultureContext())
                {
                    DbSet<ViewSoldCropHistory> allInfo = db.ViewSoldCropHistory;
                    ViewSoldCropHistory entityModelObject = new ViewSoldCropHistory
                    {
                        Date = p.Date,
                        CropName = p.CropName,
                        Quantity = p.Quantity,
                        Msp = p.Msp,
                        SolidPrice = p.SolidPrice,
                        UserId = p.UserId,
                        TotalPrice = p.TotalPrice,
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

        public bool InsertCropHistoryInfo(ViewSoldCropHistoryDao p)
        {
            throw new NotImplementedException();
        }

        List<ViewSoldCropHistoryDao> IViewSoldCropHistoryDao.FetchAllHistoryDetails()
        {
            throw new NotImplementedException();
        }

        ViewSoldCropHistoryDao IViewSoldCropHistoryDao.FetchHistoryById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
