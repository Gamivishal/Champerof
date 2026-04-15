using Champerof.Infra;
using Champerof.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Champerof.Infra;

namespace Champerof.ServiceRepository.MenuAccessRepository
{

    public interface IMenuAccessRepo
    {
        Task<List<MenuAccessDto>> GetMenuAccessAsync();
    }

    public class MenuAccessRepo : IMenuAccessRepo
    {
        private readonly DataContext _context;

        public MenuAccessRepo(DataContext context)
        {
            _context = context;
        }

        public async Task<List<MenuAccessDto>> GetMenuAccessAsync()
        {
            try
            {
                var userId = AppHttpContextAccessor.JwtUserId;
                // FromSqlInterpolated is cleaner and parameterized properly
                var result = await _context.Set<MenuAccessDto>().FromSqlInterpolated($"EXEC dbo.sp_MenuAccess {userId}").ToListAsync();

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
