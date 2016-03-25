using Marauder.BLL.Interface;
using Marauder.BLL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Marauder.Web.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IShoppingCartService shoppingCartService;
        private readonly IAlbumService albumService;

        public ShoppingCartController(
            IShoppingCartService shoppingCartService,
            IAlbumService albumService)
        {
            this.shoppingCartService = shoppingCartService;
            this.albumService = albumService;
        }
        // GET: ShoppingCart
        public ActionResult Index()
        {
            ShoppingCartViewModel viewModel = this.shoppingCartService.GetCart(this.HttpContext);
            return View(viewModel);
        }

        public ActionResult AddToCart(int id)
        {
            this.shoppingCartService.GetCart(this.HttpContext);
            AlbumViewModel addedAlbum = this.albumService.GetById(id);
            this.shoppingCartService.AddToCart(addedAlbum);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult RemoveFromCart(int id)
        {
            ShoppingCartViewModel viewModel = this.shoppingCartService.GetCart(this.HttpContext);
            // Get the name of the album to display confirmation
            string albumName = this.shoppingCartService.getAlbumName(id);
            // Remove from cart
            int itemCount = this.shoppingCartService.RemoveFromCart(id);

            // Display the confirmation message
            ShoppingCartRemoveViewModel results = new ShoppingCartRemoveViewModel
            {
                Message = Server.HtmlEncode(albumName) +
                    " has been removed from your shopping cart.",
                CartTotal = viewModel.CartTotal,
                CartCount = viewModel.CartItems.Count,
                ItemCount = itemCount,
                DeleteId = id
            };
            return Json(results);
        }
    }
}