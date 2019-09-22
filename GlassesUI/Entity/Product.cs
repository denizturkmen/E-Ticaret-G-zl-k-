using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GlassesUI.Entity
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public double Price { get; set; }
        //public DateTime DateOfJoining { get; set; }
        public int Stock { get; set; }
        public bool IsHome { get; set; }
        public bool IsApproved { get; set; }

        //urun hesaplatmayı ayrlıyaca indirim filan olanı

        //Foreign Key
        public int CategoryId { get; set; }

        //Navigation Properties yabi product category field erişmek için
        //BİR product BİR Category AİT
        public Category Category { get; set; }

    }
}