using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using SchemasForFarmer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchemasForFarmer.DataAccesslayer
{
    public class PlaceSellRequestDao: IPlaceSellRequestDao
    {
        public bool AddSellRequestDetails(PlaceSellRequest data)
        {
            bool status = false;

            try
            {
                using (var db = new AgricultureContext())
                {
                    db.PlaceSellRequest.Add(data);
                    status = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return status;
        }

        public List<PlaceSellRequest> FetchAllRequestDetails()
        {
            List<PlaceSellRequest> businessDetails = null;
            try
            {
                using (var db = new AgricultureContext())
                {
                     DbSet<PlaceSellRequest> allRequestDetails = db.PlaceSellRequest;
                    if (allRequestDetails.Count() > 0)
                    {
                        businessDetails =
                            allRequestDetails
                             .Select(
                                (PlaceSellRequest a) =>
                                     new PlaceSellRequest
                                     {
                                         CropName = a.CropName,
                                         CropType = a.CropType,
                                         FertilizerType = a.FertilizerType,
                                         Quantity = a.Quantity,
                                         SoilPhCertificate = a.SoilPhCertificate,
                                         UserId = a.UserId,

                                     }
                             )
                             .ToList<PlaceSellRequest>();

                    }
                }
                return businessDetails;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public PlaceSellRequest FetchDetailsById(int id)
        {
            PlaceSellRequest businessDetails = null;
            try
            {
                using (var db = new AgricultureContext())
                {
                    DbSet<PlaceSellRequest> alldetails = db.PlaceSellRequest;
                    var matchingData = alldetails.Where(p => p.UserId == id);
                    if (matchingData != null && matchingData.Count() > 0)
                    {
                        PlaceSellRequest p = matchingData.First<PlaceSellRequest>();
                        businessDetails = new PlaceSellRequest
                        {

                            CropName = p.CropName,
                            CropType = p.CropType,
                            FertilizerType = p.FertilizerType,
                            Quantity = p.Quantity,
                            SoilPhCertificate = p.SoilPhCertificate,
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
        public bool InsertSellRequestInfo(PlaceSellRequest p)
        {
            int result = 0;
            try
            {
                using (var db = new AgricultureContext())
                {
                    DbSet<PlaceSellRequest> allInfo = db.PlaceSellRequest;
                    PlaceSellRequest entityModelObject = new PlaceSellRequest
                    {
                        CropName = p.CropName,
                        CropType = p.CropType,
                        FertilizerType = p.FertilizerType,
                        Quantity = p.Quantity,
                        SoilPhCertificate = p.SoilPhCertificate,
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

        public bool InsertSellRequestInfo(PlaceSellRequestDao p)
        {
            throw new NotImplementedException();
        }

        List<PlaceSellRequestDao> IPlaceSellRequestDao.FetchAllRequestDetails()
        {
            throw new NotImplementedException();
        }

        PlaceSellRequestDao IPlaceSellRequestDao.FetchDetailsById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
