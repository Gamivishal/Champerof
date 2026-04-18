using Champerof.Infra;
using Champerof.Models;

namespace Champerof.ServiceRepository.TermsRepository
{
    public interface ITermsRepository
    {
        Task<PagedResult<TermsAndConditions>> GetAllTerms(int start, int length, string sortColumn, string sortColumnDir, string searchValue);

        Task<(bool IsSuccess, string Message, long Id, List<string> Extra)> AddOrUpdateTerms(TermsAndConditions terms);

        Task<TermsAndConditions?> GetTermsById(long id);

        Task<(bool IsSuccess, string Message, long Id, List<string> Extra)> DeleteTerms(long id);
    }
}
