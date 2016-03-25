using AutoMapper;
using AutoMapper.QueryableExtensions;
using DAL.Repository;
using Marauder.BLL.Interface;
using Marauder.BLL.ViewModels;
using Marauder.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Marauder.BLL.Service
{
    public class ShoppingCartService : IShoppingCartService
    {
        public const string CartSessionKey = "CartId";
        string ShoppingCartId { get; set; }
        private readonly IUnitOfWork unitOfWork;

        public ShoppingCartService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public ShoppingCartViewModel GetCart(HttpContextBase context)
        {
            this.ShoppingCartId = this.GetCartId(context);
            List<CartViewModel> result = this.unitOfWork.Repository<Cart>().Get(x => x.CartId == ShoppingCartId).Project().To<CartViewModel>().ToList();
            return Mapper.Map<List<CartViewModel>, ShoppingCartViewModel>(result);
        }

        public void AddToCart(AlbumViewModel album)
        {
            // Get the matching cart and album instances
            Cart cartItem = this.unitOfWork.Repository<Cart>().Get(x => x.CartId == this.ShoppingCartId && x.AlbumId == album.AlbumId).SingleOrDefault();

            if (cartItem == null)
            {
                cartItem = new Cart
                {
                    AlbumId = album.AlbumId,
                    CartId = this.ShoppingCartId,
                    Count = 1,
                    DateCreated = DateTime.Now
                };
                this.unitOfWork.Repository<Cart>().Create(cartItem);
            }
            else
            {
                cartItem.Count++;
                this.unitOfWork.Repository<Cart>().Update(cartItem);
            }
            this.unitOfWork.Save();
        }

        public int RemoveFromCart(int id)
        {
            Cart cartItem = this.unitOfWork.Repository<Cart>().Get(x => x.CartId == this.ShoppingCartId && x.RecordId == id).Single();

            int itemCount = 0;

            if (cartItem != null)
            {
                if (cartItem.Count > 1)
                {
                    cartItem.Count--;
                    itemCount = cartItem.Count;
                }
                else
                {
                    this.unitOfWork.Repository<Cart>().Delete(cartItem);
                }

                this.unitOfWork.Save();
            }
            return itemCount;
        }

        public string getAlbumName(int id)
        {
            return this.unitOfWork.Repository<Cart>().Get(x => x.RecordId == id).Single().Album.Title;
        }

        //We're using HttpContextBase to allow access to cookies.
        private string GetCartId(HttpContextBase context)
        {
            if (context.Session[CartSessionKey] == null)
            {
                if (!string.IsNullOrWhiteSpace(context.User.Identity.Name))
                {
                    context.Session[CartSessionKey] = context.User.Identity.Name;
                }
                else
                {
                    // Generate a new random GUID using System.Guid class
                    Guid tempCartId = Guid.NewGuid();
                    // Send tempCartId back to client as a cookie
                    context.Session[CartSessionKey] = tempCartId.ToString();
                }
            }
            return context.Session[CartSessionKey].ToString();
        }
    }
}
