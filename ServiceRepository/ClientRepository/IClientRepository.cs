using Champerof.Infra;
using Champerof.Models;

namespace Champerof.ServiceRepository.ClientRepository
{
    public interface IClientRepository
    {
        Task<PagedResult<Clients>> GetAllClients(int start, int length, string sortColumn, string sortColumnDir, string searchValue);
        Task<(bool IsSuccess, string Message, long Id, List<string> Extra)> AddOrUpdateClient(Clients client);
        Task<Clients?> GetClientById(long id);
        Task<(bool IsSuccess, string Message, long Id, List<string> Extra)> DeleteClient(long id);
    }
}
