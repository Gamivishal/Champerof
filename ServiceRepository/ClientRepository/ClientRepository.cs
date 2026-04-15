using Champerof.Infra;
using Champerof.Models;
using Microsoft.Data.SqlClient;

namespace Champerof.ServiceRepository.ClientRepository
{
    public class ClientRepository : IClientRepository
    {
        private readonly DataContext _context;
        private readonly IRepositoryBase<Clients> _repositoryBase;

        public ClientRepository(DataContext context, IRepositoryBase<Clients> repositoryBase)
        {
            _context = context;
            _repositoryBase = repositoryBase;
        }

        public async Task<PagedResult<Clients>> GetAllClients(
            int start,
            int length,
            string sortColumn,
            string sortColumnDir,
            string searchValue)
        {
            SqlParameter[] parameters = null;

            var result = _repositoryBase.ExecuteWithPagination(
                "sp_Client_Get",
                parameters,
                start,
                length,
                sortColumn,
                sortColumnDir,
                searchValue
            );
            return await Task.FromResult(result);
        }

        public async Task<(bool IsSuccess, string Message, long Id, List<string> Extra)> AddOrUpdateClient(Clients client)
        {
            List<SqlParameter> oParams = new()
            {
                new SqlParameter("@ClientId", client.ClientId),
                new SqlParameter("@ClientName", client.ClientName ?? (object)DBNull.Value),
                new SqlParameter("@CompanyName", client.CompanyName ?? (object)DBNull.Value),
                new SqlParameter("@Email", client.Email ?? (object)DBNull.Value),
                new SqlParameter("@Phone", client.Phone ?? (object)DBNull.Value),
                new SqlParameter("@GSTNumber", client.GSTNumber ?? (object)DBNull.Value),
                new SqlParameter("@Address", client.Address ?? (object)DBNull.Value),
                new SqlParameter("@Operated_By", AppHttpContextAccessor.JwtUserId),
                new SqlParameter("@Action", client.ClientId == 0 ? "INSERT" : "UPDATE")
            };

            var result = _repositoryBase.ExecuteStoredProcedurenew("sp_Client_Save", oParams, true);

            return await Task.FromResult(result);
        }

        public async Task<Clients?> GetClientById(long id)
        {
            var parameters = new[]
            {
                new SqlParameter("@ClientId", id)
            };

            var result = _repositoryBase.ExecuteSingle("sp_Client_Get", parameters);

            return await Task.FromResult(result);
        }

        public async Task<(bool IsSuccess, string Message, long Id, List<string> Extra)> DeleteClient(long id)
        {
            List<SqlParameter> parameters = new()
            {
                new SqlParameter("@ClientId", id),
                new SqlParameter("@Operated_By", AppHttpContextAccessor.JwtUserId)
            };

            var result = _repositoryBase.ExecuteStoredProcedurenew("sp_Client_Delete", parameters, true);

            return await Task.FromResult(result);
        }
    }
}