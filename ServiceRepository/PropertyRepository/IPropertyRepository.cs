using CommonForReact.Infra;
using CommonForReact.Models;

namespace CommonForReact.ServiceRepository.PropertyRepository
{
    public interface IPropertyRepository
    {


        Task<PagedResult<Property>> GetAllProperty(int start, int length, string sortColumn, string sortColumnDir, string searchValue);
        Task<(bool IsSuccess, string Message, long Id, List<string> Extra)> SaveProperty(Property model);
        Task SavePropertyImage(Property model);
        Task DeletePropertyImage(int imageId);
        Task<List<PropertyImage>> GetPropertyImages(int propertyId);

        Task<Property?> GetPropertyById(long id);
    }
}
