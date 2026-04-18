using Champerof.Infra;
using Champerof.Models;

namespace Champerof.ServiceRepository.CompanyRepository
{
    public interface ICompanyRepository
    {
        Task<PagedResult<CompanyMaster>> GetAll(int start, int length, string sortColumn, string sortColumnDir, string searchValue);

        Task<(bool IsSuccess, string Message, long Id, List<string> Extra)> AddOrUpdate(CompanyMaster company);

        Task<CompanyMaster?> GetById(long id);

        Task<(bool IsSuccess, string Message, long Id, List<string> Extra)> Delete(long id);
    }
}
