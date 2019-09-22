using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GlassesUI.Entity
{
    //varitabanı kayıt için
    public class Order
    {
        public int Id { get; set; }
        public string OrderNumber { get; set; }
        public double Total { get; set; }
        public DateTime OrderDate { get; set; }
        public EnumOrderState OrderState { get; set; }

        public string Username { get; set; }
        public string AdresBasligi { get; set; }
        public string Adres { get; set; }
        public string Sehir { get; set; }
        public string Semt { get; set; }
        public string Mahalle { get; set; }
        public string PostaKodu { get; set; }

        public virtual List<OrderLine> OrderLines { get; set; }
    }

    //tamamlanmış kayıt
    public class OrderLine
    {
        public int Id { get; set; }
        public int OrderId { get; set; } //foreignKey 
        public virtual Order Order { get; set; } // lazy loading için

        public int Quantity { get; set; }
        //ürününü fiyatı güncellenemebilir
        public double Price { get; set; }

        public int ProductId { get; set; }
        public virtual Product Product { get; set; } // lazy loading için




    }
}