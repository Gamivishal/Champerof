using Champerof.Infra;
using Champerof.Models;

namespace Champerof.ServiceRepository.ServiceRepository
{
    public interface IServiceRepository
    {
        Task<PagedResult<Services>> GetAllServices(int start, int length, string sortColumn, string sortColumnDir, string searchValue);
        Task<(bool IsSuccess, string Message, long Id, List<string> Extra)> AddOrUpdateService(Services service);
        Task<Services?> GetServiceById(long id);
        Task<(bool IsSuccess, string Message, long Id, List<string> Extra)> DeleteService(long id);
    }
}
