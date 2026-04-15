using Champerof.Infra;
using Champerof.Models;
using Microsoft.AspNetCore.Mvc;
using Champerof.Infra;

namespace Champerof.ServiceRepository.MenuRepository
{
    public interface IMenuRepository
    {
        Task<PagedResult<Menu>> GetAllMenu(
            int start, int length, string sortColumn, string sortColumnDir, string searchValue);

        Task<(bool IsSuccess, string Message, long Id, List<string> Extra)> AddOrUpdateMenu(Menu menu);

        Task<Menu?> GetMenuById(long id);

        Task<(bool IsSuccess, string Message, long Id, List<string> Extra)> DeleteByMenuId(long id);
    }
}
