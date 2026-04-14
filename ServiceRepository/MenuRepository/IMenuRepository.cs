using CommonForReact.Infra;
using CommonForReact.Models;
using Microsoft.AspNetCore.Mvc;
using CommonForReact.Infra;

namespace CommonForReact.ServiceRepository.MenuRepository
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
