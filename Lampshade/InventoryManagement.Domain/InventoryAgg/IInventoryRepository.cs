using _0_Framwork.Domain;
using InventoryManagementApplication.Contract.Inventory;
using System.Linq.Expressions;

namespace InventoryManagement.Domain.InventoryAgg
{
    public interface IInventoryRepository : IRepository<long, Inventory>
    {
        EditInventory GetDetails(long id);
        Inventory GetBy( long ProductId);
        List<InventoryViewModel> Search(InventorySearchModel searchModel);
       
    }
}
