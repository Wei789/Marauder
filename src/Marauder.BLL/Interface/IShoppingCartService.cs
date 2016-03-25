using Marauder.BLL.ViewModels;
using Marauder.DAL.Models;
using System.Web;

namespace Marauder.BLL.Interface
{
    public interface IShoppingCartService
    {
        ShoppingCartViewModel GetCart(HttpContextBase context);
        void AddToCart(AlbumViewModel album);
        string getAlbumName(int id);
        int RemoveFromCart(int id);
    }
}
