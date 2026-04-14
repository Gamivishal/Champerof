using CommonForReact.Infra;
using CommonForReact.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace CommonForReact.ServiceRepository.PropertyRepository
{
    public class PropertyRepository : IPropertyRepository
    {
        private readonly IRepositoryBase<Property> _repository;

        public PropertyRepository(IRepositoryBase<Property> repository)
        {
            _repository = repository;
        }

        public async Task<PagedResult<Property>> GetAllProperty(
  int start,
  int length,
  string sortColumn,
  string sortColumnDir,
  string searchValue)

        {
            try
            {
                SqlParameter[] parameters = null;

                var pagedResult = _repository.ExecuteWithPagination(
                    "sp_Property_Get",
                    parameters,
                    start,
                    length,
                    sortColumn,
                    sortColumnDir,
                    searchValue
                );

                return await Task.FromResult(pagedResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //-----------------------------------
        // SAVE PROPERTY
        //-----------------------------------
        public async Task<(bool IsSuccess, string Message, long Id, List<string> Extra)> SaveProperty(Property model)
        {
            List<SqlParameter> parameters = new();

            parameters.Add(new SqlParameter("@PropertyId", model.Id));
            parameters.Add(new SqlParameter("@Title", model.Title ?? (object)DBNull.Value));
            parameters.Add(new SqlParameter("@Description", model.Description ?? (object)DBNull.Value));
            parameters.Add(new SqlParameter("@Price", model.Price ?? (object)DBNull.Value));
            parameters.Add(new SqlParameter("@Address", model.Address ?? (object)DBNull.Value));
            parameters.Add(new SqlParameter("@Action", model.Id == 0 ? "INSERT" : "UPDATE"));

            var result = _repository.ExecuteStoredProcedurenew(
                "sp_Property_Save",
                parameters,
                true
            );

            return await Task.FromResult(result);
        }

        //-----------------------------------
        // SAVE IMAGE
        //-----------------------------------
        public async Task SavePropertyImage(Property model)
        {
            List<SqlParameter> parameters = new();

            parameters.Add(new SqlParameter("@PropertyId", model.Id));
            parameters.Add(new SqlParameter("@FileName", model.FileName ?? (object)DBNull.Value));
            parameters.Add(new SqlParameter("@ContentType", model.ContentType ?? (object)DBNull.Value));
            parameters.Add(new SqlParameter("@FileSize", model.FileSize ?? (object)DBNull.Value));

            parameters.Add(new SqlParameter("@FileData", SqlDbType.VarBinary)
            {
                Value = model.FileData ?? (object)DBNull.Value
            });

            _repository.ExecuteStoredProcedurenew(
                "sp_PropertyImage_Save",
                parameters,
                true
            );

            await Task.CompletedTask;
        }

        //-----------------------------------
        // DELETE IMAGE
        //-----------------------------------
        public async Task DeletePropertyImage(int imageId)
        {
            List<SqlParameter> parameters = new();

            parameters.Add(new SqlParameter("@ImageId", imageId));

            _repository.ExecuteStoredProcedurenew(
                "sp_PropertyImage_Delete",
                parameters,
                true
            );

            await Task.CompletedTask;
        }

        //-----------------------------------
        // GET IMAGES
        //-----------------------------------
        public async Task<List<PropertyImage>> GetPropertyImages(int propertyId)
        {
            var parameters = new List<SqlParameter>
    {
        new SqlParameter("@PropertyId", propertyId)
    };

            var dt = _repository.ExecuteStoredProcedureDataTable(
                "sp_PropertyImage_GetByPropertyId", // use correct SP
                parameters
            );

            var list = new List<PropertyImage>();

            foreach (DataRow row in dt.Rows)
            {
                list.Add(new PropertyImage
                {
                    Id = Convert.ToInt32(row["Id"]),
                    PropertyId = Convert.ToInt32(row["PropertyId"]),
                    FileName = row["FileName"]?.ToString(),
                    ContentType = row["ContentType"]?.ToString(),
                    ImageData = row["ImageData"] as byte[],
                    CreatedAt = row["CreatedAt"] as DateTime?
                });
            }

            return await Task.FromResult(list);
        }





        public async Task<Property?> GetPropertyById(long id)
        {
            try
            {
                var parameters = new[]
                {
         new SqlParameter("@PropertyId", id)
     };

                var result = _repository.ExecuteSingle(
                    "sp_Property_Get",
                    parameters
                );

                return await Task.FromResult(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}




        //public async Task<(bool IsSuccess, string Message, long Id, List<string> Extra)> SaveProperty(Property model)
        //{
        //    try
        //    {
        //        List<SqlParameter> parameters = new();

        //        parameters.Add(new SqlParameter("@PropertyId", model.Id));
        //        parameters.Add(new SqlParameter("@Title", model.Title ?? (object)DBNull.Value));
        //        parameters.Add(new SqlParameter("@Description", model.Description ?? (object)DBNull.Value));
        //        parameters.Add(new SqlParameter("@Price", model.Price ?? (object)DBNull.Value));
        //        parameters.Add(new SqlParameter("@Address", model.Address ?? (object)DBNull.Value));

        //        // File
        //        parameters.Add(new SqlParameter("@FileName", model.FileName ?? (object)DBNull.Value));
        //        parameters.Add(new SqlParameter("@ContentType", model.ContentType ?? (object)DBNull.Value));
        //        parameters.Add(new SqlParameter("@FileSize", model.FileSize ?? (object)DBNull.Value));
        //        parameters.Add(new SqlParameter("@FileData", SqlDbType.VarBinary)
        //        {
        //            Value = model.FileData ?? (object)DBNull.Value
        //        });

        //        parameters.Add(new SqlParameter("@Operated_By", 1)); // replace with your auth
        //        parameters.Add(new SqlParameter("@Action", model.Id == 0 ? "INSERT" : "UPDATE"));

        //        var result = _repository.ExecuteStoredProcedurenew(
        //            "sp_Property_Save",
        //            parameters,
        //            true
        //        );

        //        return await Task.FromResult(result);

        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }
        //}
   // }
//}
