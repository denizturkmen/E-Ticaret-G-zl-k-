using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GlassesUI.Entity;
using GlassesUI.Models;

namespace GlassesUI.Controllers
{
    public class CartController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Cart
        public ActionResult Index()
        {
            return View(GetCart());
        }
        //Veritabanı eklemek için
        public ActionResult AddToCart(int Id)
        {
            var product = db.Products.FirstOrDefault(i => i.Id == Id);
            if (product != null)
            {
                GetCart().AddProduct(product,1);
            }

            return RedirectToAction("Index");
        }

        public ActionResult RemoveFromCart(int Id)
        {
            var product = db.Products.FirstOrDefault(i => i.Id == Id);
            if (product != null)
            {
                GetCart().DeleteProduct(product);
            }

            return RedirectToAction("Index");
        }


        private Cart GetCart()
        {
            var cart = (Cart) Session["Cart"];
            if (cart == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }

            return cart;
        }

        public PartialViewResult Summary()
        {
            return PartialView(GetCart());
        }

        [HttpGet]
        public ActionResult Checkout()
        {
            return View(new ShippingDetails());
        }

        [HttpPost]
        public ActionResult Checkout(ShippingDetails entity)
        {

            var cart = GetCart();

            if (cart.CartLines.Count == 0)
            {
                //sepette ürün olamdan tıklandığındaki hata
                ModelState.AddModelError("UrunYok","Sepetinizde ürün bulunmamaktadır");
            }
           
            if (ModelState.IsValid)
                {
                    //siparişi veritabanı kayıt et
                    //cartı sıfırla
                    saveOrder(cart, entity);
                    cart.Clear(); // sessiondaki cartı sıfırlıyor
                    return View("Completed");

                }
                else
                {
                    return View(entity);
                }
           
        }

        private void saveOrder(Cart cart, ShippingDetails entity)
        {
            var order = new Order();

            order.OrderNumber ="A"+ (new Random()).Next(11111,99999).ToString();
            order.Total = cart.Total();
            order.OrderDate = DateTime.Now;
            order.OrderState = EnumOrderState.Waiting;
            order.Username = User.Identity.Name;

          //  order.Username = entity.Username;
            order.AdresBasligi = entity.AdresBasligi;
            order.Adres = entity.Adres;
            order.Sehir = entity.Sehir;
            order.Semt = entity.Semt;
            order.Mahalle = entity.Mahalle;
            order.PostaKodu = entity.PostaKodu;

            order.OrderLines = new List<OrderLine>();

            foreach (var pr in cart.CartLines)
            {
                OrderLine orderline = new OrderLine();
                orderline.Quantity = pr.Quantity;
                orderline.Price = pr.Product.Price * pr.Quantity;
                orderline.ProductId = pr.Product.Id;

                order.OrderLines.Add(orderline);
            }

            db.Orders.Add(order);
            db.SaveChanges();
        }
    }
}