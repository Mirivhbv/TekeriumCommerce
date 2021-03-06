using System.Threading.Tasks;
using TekeriumCommerce.Module.Shipping.Models;

namespace TekeriumCommerce.Module.Shipping.Services {
    public interface ICityService {
        Task Create (City city);

        Task Update (City city);

        Task Delete (long id);

        Task Delete (City city);
    }
}