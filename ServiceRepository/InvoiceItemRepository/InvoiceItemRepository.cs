using Champerof.Infra;
using Champerof.Models;
using Microsoft.Data.SqlClient;

namespace Champerof.ServiceRepository.InvoiceItemRepository
{
    public class InvoiceItemRepository : IInvoiceItemRepository
    {
        private readonly IRepositoryBase<InvoiceItems> _repositoryBase;

        public InvoiceItemRepository(IRepositoryBase<InvoiceItems> repositoryBase)
        {
            _repositoryBase = repositoryBase;
        }

        public async Task<PagedResult<InvoiceItems>> GetAll(int start, int length, string sortColumn, string sortColumnDir, string searchValue)
        {
            var result = _repositoryBase.ExecuteWithPagination(
                "sp_InvoiceItem_Get",
                null,
                start,
                length,
                sortColumn,
                sortColumnDir,
                searchValue
            );

            return await Task.FromResult(result);
        }

        public async Task<(bool IsSuccess, string Message, long Id, List<string> Extra)> AddOrUpdate(InvoiceItems model)
        {
            List<SqlParameter> oParams = new()
            {
                new SqlParameter("@ItemId", model.ItemId),
                new SqlParameter("@InvoiceId", model.InvoiceId ?? (object)DBNull.Value),
                new SqlParameter("@ServiceId", model.ServiceId ?? (object)DBNull.Value),
              //  new SqlParameter("@ItemType", model.ItemType ?? (object)DBNull.Value),
                new SqlParameter("@Description", model.Description ?? (object)DBNull.Value),
                new SqlParameter("@Quantity", model.Quantity ?? (object)DBNull.Value),
                new SqlParameter("@Rate", model.Rate ?? (object)DBNull.Value),
                new SqlParameter("@Amount", model.Amount ?? (object)DBNull.Value),
                new SqlParameter("@IsTaxable", model.IsTaxable ?? (object)DBNull.Value),
                new SqlParameter("@Operated_By", AppHttpContextAccessor.JwtUserId),
                new SqlParameter("@Action", model.ItemId == 0 ? "INSERT" : "UPDATE")
            };

            var result = _repositoryBase.ExecuteStoredProcedurenew("sp_InvoiceItem_Save", oParams, true);

            return await Task.FromResult(result);
        }

        public async Task<InvoiceItems?> GetById(long id)
        {
            var parameters = new[]
            {
                new SqlParameter("@ItemId", id)
            };

            var result = _repositoryBase.ExecuteSingle("sp_InvoiceItem_Get", parameters);

            return await Task.FromResult(result);
        }

        public async Task<(bool IsSuccess, string Message, long Id, List<string> Extra)> Delete(long id)
        {
            List<SqlParameter> parameters = new()
            {
                new SqlParameter("@ItemId", id),
                new SqlParameter("@Operated_By", AppHttpContextAccessor.JwtUserId)
            };

            var result = _repositoryBase.ExecuteStoredProcedurenew("sp_InvoiceItem_Delete", parameters, true);

            return await Task.FromResult(result);
        }
    }
}