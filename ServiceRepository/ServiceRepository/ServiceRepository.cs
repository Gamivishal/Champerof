using Champerof.Infra;
using Champerof.Models;
using Microsoft.Data.SqlClient;

namespace Champerof.ServiceRepository.ServiceRepository
{
    public class ServiceRepository : IServiceRepository
    {

        private readonly DataContext _context;
        private readonly IRepositoryBase<Services> _repositoryBase;

        public ServiceRepository(DataContext context, IRepositoryBase<Services> repositoryBase)
        {
            _context = context;
            _repositoryBase = repositoryBase;
        }

        public async Task<PagedResult<Services>> GetAllServices(
            int start,
            int length,
            string sortColumn,
            string sortColumnDir,
            string searchValue)
        {
            SqlParameter[] parameters = null;

            var result = _repositoryBase.ExecuteWithPagination(
                "sp_Service_Get",
                parameters,
                start,
                length,
                sortColumn,
                sortColumnDir,
                searchValue
            );

            return await Task.FromResult(result);
        }

        public async Task<(bool IsSuccess, string Message, long Id, List<string> Extra)> AddOrUpdateService(Services service)
        {
            List<SqlParameter> oParams = new()
            {
                new SqlParameter("@ServiceId", service.ServiceId),
                new SqlParameter("@ServiceName", service.ServiceName ?? (object)DBNull.Value),
                new SqlParameter("@DefaultPrice", service.DefaultPrice ?? (object)DBNull.Value),
                new SqlParameter("@Description", service.Description ?? (object)DBNull.Value),
                new SqlParameter("@Operated_By", AppHttpContextAccessor.JwtUserId),
                new SqlParameter("@Action", service.ServiceId == 0 ? "INSERT" : "UPDATE")
            };

            var result = _repositoryBase.ExecuteStoredProcedurenew("sp_Service_Save", oParams, true);

            return await Task.FromResult(result);
        }

        public async Task<Services?> GetServiceById(long id)
        {
            var parameters = new[]
            {
                new SqlParameter("@ServiceId", id)
            };

            var result = _repositoryBase.ExecuteSingle("sp_Service_Get", parameters);

            return await Task.FromResult(result);
        }

        public async Task<(bool IsSuccess, string Message, long Id, List<string> Extra)> DeleteService(long id)
        {
            List<SqlParameter> parameters = new()
            {
                new SqlParameter("@ServiceId", id),
                new SqlParameter("@Operated_By", AppHttpContextAccessor.JwtUserId)
            };

            var result = _repositoryBase.ExecuteStoredProcedurenew("sp_Service_Delete", parameters, true);

            return await Task.FromResult(result);
        }
    }
}
