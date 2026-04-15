using Champerof.Infra;
using Champerof.Models;

namespace Champerof.ServiceRepository.UserDemoRepository
{
    public interface IUserDemoRepository
    {
        Task<(bool IsSuccess, string Message, long Id, List<string> Extra)> AddOrUpdateUserDemo(UserDemo model);

        Task<PagedResult<UserDemo>> GetAllUserDemo(int start, int length, string sortColumn, string sortColumnDir, string searchValue);

        Task<UserDemo?> GetUserDemoById(long id);
    }
}
