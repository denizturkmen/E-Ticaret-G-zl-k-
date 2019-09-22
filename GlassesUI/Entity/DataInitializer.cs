using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GlassesUI.Entity
{
    public class DataInitializer :DropCreateDatabaseIfModelChanges<DataContext>
    {
        protected override void Seed(DataContext context)
        {

            var kategoriler = new List<Category>()
            {
                new Category(){Name="Erkek",Description = "Erkek Gozlük"},
                new Category(){Name="Kadın",Description = "Kadın Gozlük"},
                new Category(){Name="Unisex",Description = "Unisex Gozlük"},
            };

            foreach (var kategori in kategoriler)
            {
                context.Categories.Add(kategori);
            }

            context.SaveChanges();

            var urunler = new List<Product>()
            {
                new Product(){Name="Tommy Hilfiger",Description = "Erkek Gözlük Tommy Hilfiger 1572/S J5G 50 Tommy HilfigerTommy HilfigerTommy HilfigerTommy HilfigerTommy HilfigerTommy Hilfiger",Image="a1.png",IsApproved=true,IsHome=true,Price=600.0,Stock=5,CategoryId=1},
                new Product(){Name="Tommy Hilfiger",Description = "Erkek Gözlük Tommy Hilfiger 1572/S J5G 50 Tommy HilfigerTommy HilfigerTommy HilfigerTommy HilfigerTommy HilfigerTommy Hilfiger",Image="a2.png",IsApproved=false,IsHome=false,Price=800.0,Stock=5,CategoryId=2},
                new Product(){Name="Tommy Hilfiger",Description = "Erkek Gözlük Tommy Hilfiger 1572/S J5G 50 Tommy HilfigerTommy HilfigerTommy HilfigerTommy HilfigerTommy HilfigerTommy Hilfiger",Image="a1.png",IsApproved=true,IsHome=false,Price=400.0,Stock=5,CategoryId=3},
                new Product(){Name="Tommy Hilfiger",Description = "Erkek Gözlük Tommy Hilfiger 1572/S J5G 50 Tommy HilfigerTommy HilfigerTommy HilfigerTommy HilfigerTommy HilfigerTommy Hilfiger",Image="a2.png",IsApproved=true,IsHome=true,Price=300.0,Stock=5,CategoryId=1},
                new Product(){Name="Tommy Hilfiger",Description = "Erkek Gözlük Tommy Hilfiger 1572/S J5G 50 Tommy HilfigerTommy HilfigerTommy HilfigerTommy HilfigerTommy HilfigerTommy Hilfiger",Image="a1.png",IsApproved=false,IsHome=true,Price=600.0,Stock=5,CategoryId=2},
                new Product(){Name="Tommy Hilfiger",Description = "Erkek Gözlük Tommy Hilfiger 1572/S J5G 50 Tommy HilfigerTommy HilfigerTommy HilfigerTommy HilfigerTommy HilfigerTommy Hilfiger",Image="a2.png",IsApproved=true,IsHome=true,Price=9800.0,Stock=5,CategoryId=3},
                new Product(){Name="Tommy Hilfiger",Description = "Erkek Gözlük Tommy Hilfiger 1572/S J5G 50 Tommy HilfigerTommy HilfigerTommy HilfigerTommy HilfigerTommy HilfigerTommy Hilfiger",Image="a1.png",IsApproved=true,IsHome=true,Price=6400.0,Stock=5,CategoryId=1},
                new Product(){Name="Tommy Hilfiger",Description = "Erkek Gözlük Tommy Hilfiger 1572/S J5G 50 Tommy HilfigerTommy HilfigerTommy HilfigerTommy HilfigerTommy HilfigerTommy Hilfiger",Image="a2.png",IsApproved=true,IsHome=true,Price=3200.0,Stock=5,CategoryId=1},
            };

            foreach (var urun in urunler)
            {
                context.Products.Add(urun);
            }

            context.SaveChanges();

            base.Seed(context);
        }
    }
}