using Marauder.BLL.Interface;
using System.Web.Mvc;

namespace Marauder.Web.Controllers
{
    public class StoreController : Controller
    {
        private readonly IGenreService genreService;
        private readonly IAlbumService albumService;


        public StoreController(IGenreService genreService, IAlbumService albumService)
        {
            this.genreService = genreService;
            this.albumService = albumService;
        }

        // GET: Store
        public ActionResult Index()
        {
            var genres = this.genreService.GetAll();
            return View(genres);
        }

        // GET: /Store/Browse
        public ActionResult Browse(string genre)
        {
            return View(this.genreService.GetByGenre(genre));
        }

        // Get: /Store/Details
        public ActionResult Details(int id)
        {
            return View(this.albumService.GetById(id));
        }
    }
}