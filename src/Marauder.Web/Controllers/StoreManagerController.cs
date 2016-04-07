using Marauder.BLL.Interface;
using Marauder.BLL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Marauder.Web.Controllers
{
    public class StoreManagerController : Controller
    {
        private readonly IAlbumService albumService;
        private readonly IGenreService genreService;
        private readonly IArtistService artistService;

        public StoreManagerController(
            IAlbumService albumService,
            IGenreService genreService,
            IArtistService artistService)
        {
            this.albumService = albumService;
            this.genreService = genreService;
            this.artistService = artistService;
        }

        // GET: StoreManager
        public ActionResult Index()
        {
            return View(this.albumService.GetAll());
        }

        // GET: StoreManager/Details/5
        public ActionResult Details(int id)
        {
            AlbumViewModel album = this.albumService.GetById(id);
            return View(album);
        }

        // GET: StoreManager/Create
        public ActionResult Create()
        {
            PrepareDropdownList();

            return View();
        }

        // POST: StoreManager/Create
        [HttpPost]
        public ActionResult Create(AlbumViewModel albumViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    this.albumService.Create(albumViewModel);
                    this.albumService.Save();
                    return RedirectToAction("Index");
                }

                PrepareDropdownList(albumViewModel);
                return View(albumViewModel);
            }
            catch
            {
                return RedirectToAction("Create");
            }
        }

        // GET: StoreManager/Edit/5
        public ActionResult Edit(int id)
        {
            AlbumViewModel album = this.albumService.GetById(id);

            PrepareDropdownList(album);

            return View(album);
        }

        // POST: StoreManager/Edit/5
        [HttpPost]
        public ActionResult Edit(AlbumViewModel album)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    this.albumService.Update(album);
                    this.albumService.Save();
                    return RedirectToAction("Index");
                }

                return RedirectToAction("Edit");
            }
            catch
            {
                return RedirectToAction("Edit");
            }
        }

        // GET: StoreManager/Delete/5
        public ActionResult Delete(int id)
        {
            AlbumViewModel album = this.albumService.GetById(id);
            return View(album);
        }

        // POST: StoreManager/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                this.albumService.Delete(id);
                this.albumService.Save();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        private void PrepareDropdownList(AlbumViewModel album = null)
        {
            var GenreList = this.genreService.GetAll();
            var ArtistList = this.artistService.GetAll();
            if (album == null)
            {
                ViewBag.GenreId = new SelectList(GenreList, "GenreId", "Name");
                ViewBag.ArtistId = new SelectList(ArtistList, "ArtistId", "Name");
            }
            else
            {
                ViewBag.GenreId = new SelectList(GenreList, "GenreId", "Name", album.GenreId);
                ViewBag.ArtistId = new SelectList(ArtistList, "ArtistId", "Name", album.ArtistId);
            }
        }
    }
}
