using Champerof.Infra;
using Champerof.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Champerof.ServiceRepository.UserDemoRepository
{
    public class UserDemoRepository : IUserDemoRepository
    {
        private readonly IRepositoryBase<UserDemo> _repositoryBase;

        public UserDemoRepository(IRepositoryBase<UserDemo> repositoryBase)
        {
            _repositoryBase = repositoryBase;
        }


        public async Task<PagedResult<UserDemo>> GetAllUserDemo(
  int start,
  int length,
  string sortColumn,
  string sortColumnDir,
  string searchValue)

        {
            try
            {
                SqlParameter[] parameters = null;

                var pagedResult = _repositoryBase.ExecuteWithPagination(
                    "sp_UserDemo_Get",
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







        public async Task<UserDemo?> GetUserDemoById(long id)
        {
            try
            {
                var parameters = new[]
                {
         new SqlParameter("@UserId", id)
     };

                var result = _repositoryBase.ExecuteSingle(
                    "sp_UserDemo_Get",
                    parameters
                );

                return await Task.FromResult(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }




        //public async Task<List<UserDemoGetModel>> GetUserDemoById(long id)
        //{
        //    try
        //    {
        //        var parameters = new[]
        //        {
        //    new SqlParameter("@UserId", id)
        //};

        //        var result = _repositoryBase.ExecuteStoredProcedure<UserDemoGetModel>(
        //            "sp_UserDemo_Get",
        //            parameters
        //        );

        //        return await Task.FromResult(result.ToList());
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}


        public async Task<(bool IsSuccess, string Message, long Id, List<string> Extra)> AddOrUpdateUserDemo(UserDemo model)
        {
            try
            {
                List<SqlParameter> parameters = new();

                parameters.Add(new SqlParameter("@UserId", model.Id));
                parameters.Add(new SqlParameter("@UserName", model.UserName ?? (object)DBNull.Value));
                parameters.Add(new SqlParameter("@Password", model.Password ?? (object)DBNull.Value));
                parameters.Add(new SqlParameter("@Email", model.Email ?? (object)DBNull.Value));
                parameters.Add(new SqlParameter("@MobileNumber", model.MobileNumber ?? (object)DBNull.Value));

                parameters.Add(new SqlParameter("@Operated_By", AppHttpContextAccessor.JwtUserId));
                parameters.Add(new SqlParameter("@Action", model.Id == 0 ? "INSERT" : "UPDATE"));

                // ✅ File params
                parameters.Add(new SqlParameter("@FileName", model.FileName ?? (object)DBNull.Value));
                parameters.Add(new SqlParameter("@ContentType", model.ContentType ?? (object)DBNull.Value));
                parameters.Add(new SqlParameter("@FileSize", model.FileSize ?? (object)DBNull.Value));
                parameters.Add(new SqlParameter("@FileData", SqlDbType.VarBinary)
                {
                    Value = model.FileData ?? (object)DBNull.Value
                });

                var result = _repositoryBase.ExecuteStoredProcedurenew("sp_UserDemo_Save", parameters, true);

                return await Task.FromResult(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
