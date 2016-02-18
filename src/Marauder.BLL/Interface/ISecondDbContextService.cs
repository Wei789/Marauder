using System.Linq;

namespace Marauder.BLL.Interface
{
    public interface ISecondDbContextService
    {
        IQueryable<string> GetAll();
    }
}
