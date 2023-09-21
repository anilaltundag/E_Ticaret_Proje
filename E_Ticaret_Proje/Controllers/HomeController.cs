using E_Ticaret_Proje.Entity;
using E_Ticaret_Proje.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_Ticaret_Proje.Controllers
{
    public class HomeController : Controller
    {
        DataContext _context = new DataContext();

        // GET: Home
        public ActionResult Index()
        {

            var urunler = _context.Products.Where(i => i.IsApproved)
                .Select(i => new ProductModel()
            {
                Id = i.Id,
                Name = i.Name,
                Description = i.Description.Length > 150 ? i.Description.Substring(0,149) + "..." : i.Description,
                Price = i.Price,
                Stock = i.Stock,
                Image = i.Image,
                CategoryId = i.CategoryId,
                CategoryName = i.Category.Name,
                AuthorName = i.Author.Name
                //Author = i.Author
            }).ToList();

            return View(urunler);
        }
        public ActionResult Details(int id)
        {
            var product = _context.Products.Where(i => i.Id == id).FirstOrDefault();

            var author = _context.Authors.Where(i => i.Id == product.AuthorId).FirstOrDefault(); // Sadece istenileni aldık Load'a gerek kalmamış oldu

            product.Author = author;
            //_context.Authors.Load(); // Author tablosunu komple yükle

            return View(product); 
        }
        public ActionResult List()
        {
            var urunler = _context.Products.Where(i => i.IsApproved)
                .Select(i => new ProductModel()
                {
                    Id = i.Id,
                    Name = i.Name,
                    Description = i.Description.Length > 150 ? i.Description.Substring(0, 149) + "..." : i.Description,
                    Price = i.Price,
                    Stock = i.Stock,
                    Image = i.Image,
                    AuthorId = i.AuthorId,
                    Author = i.Author,
                    CategoryId = i.CategoryId,
                    CategoryName = i.Category.Name,
                    AuthorName = i.Author.Name
                }).ToList();

            return View(urunler);
        }

        public ActionResult AuthorList()
        {
            var yazarlar = _context.Authors
                .Select(i => new AuthorModel()
                {
                    Id = i.Id,
                    Name = i.Name,
                    Description = i.Description.Length > 150 ? i.Description.Substring(0, 149) + "..." : i.Description,
                    Image = i.Image,
                }).ToList();

            return View(yazarlar);
        }

        public ActionResult AuthorDetails(int id)
        {
            return View(_context.Authors.Where(i => i.Id == id).FirstOrDefault());
        }
    }
}