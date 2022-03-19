using System;
using SchemasForFarmer.DataAccesslayer;
using SchemasForFarmer.BusinessAccessLayer;
using SchemasForFarmer.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SchemasForFarmer.DataAccesslayer
{
    public class CropDetail : ICropDetail
    {
       
        public bool InsertCrop(CropType crop)
        {
            int result = 0;
            try
            {
                using var db = new AgricultureContext();
                {
                    DbSet<CropType> allcrop = db.CropType;
                    CropType cropType = new CropType
                    {
                        CropTypeId = crop.CropTypeId,
                        CropType1 = crop.CropType1


                    };
                    allcrop.Add(cropType);
                    result = db.SaveChanges();
                }
                return result > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
     

        public bool InsertCropType(CropDetail crop)
        {
            throw new NotImplementedException();
        }
    }
}
