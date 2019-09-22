using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using GlassesUI.Entity;
using GlassesUI.Models;

namespace GlassesUI.Controllers
{
    public class HomeController : Controller
    {
        DataContext db = new DataContext();

        // GET: Home
        public ActionResult Index()
        {
            var urunler = db.Products.Where(i => i.IsHome == true && i.IsApproved == true)
                .Select(i => new ProductModel()
                {
                    Id = i.Id,
                    Name = i.Name.Length>50 ? i.Name.Substring(0,47)+"...":i.Name,
                    Description = i.Description.Length > 50 ? i.Description.Substring(0,47)+"...":i.Description,
                    Price = i.Price,
                    Stock = i.Stock,
                    Image = i.Image,
                    CategoryId = i.CategoryId

                }).ToList();

            return View(urunler);
        }

        public ActionResult Details(int id)
        {
            var detail = db.Products.FirstOrDefault(i => i.Id == id);
            return View(detail);
        }

        public ActionResult List(int ?id)
        {
            var urunler = db.Products.Where(i => i.IsApproved == true && i.IsHome == true)
                .Select(i => new ProductModel()
                {
                    Id = i.Id,
                    Name = i.Name.Length > 50 ? i.Name.Substring(0, 47) + "..." : i.Name,
                    Description = i.Description.Length > 50 ? i.Description.Substring(0, 47) + "..." : i.Description,
                    Price = i.Price,
                    Stock = i.Stock,
                    Image = i.Image ?? "1.jpg", // eğer rresim yüklenmezse default resim yüklemek için
                    CategoryId = i.CategoryId

                }).AsQueryable();

            if (id  != null)
            {
                urunler = urunler.Where(i => i.CategoryId == id);
            }
            return View(urunler.ToList());
        }


        public PartialViewResult GetCategories()
        {
            return PartialView(db.Categories.ToList());
        }
    }
}