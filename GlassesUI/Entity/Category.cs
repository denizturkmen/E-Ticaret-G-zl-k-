using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GlassesUI.Entity
{
    public class Category
    {
        public int  Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        
        
        //Bir Category BİRDEN FAZLA Product olabilir
        public List<Product> Products { get; set; }


    }
}