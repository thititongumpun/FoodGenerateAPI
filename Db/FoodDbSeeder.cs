using System;
using System.IO;
using System.Linq;
using FoodGenerateAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace FoodGenerateAPI.Db
{
    public class FoodDbSeeder
    {
        public static void Seed(IServiceProvider serviceProvider)
        {
            using (var context = new AppDbContext(serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>()))
            {
                if (context.Foods.Any())
                {
                    return;
                }

                context.Foods.AddRange(
                    new Food
                    {
                        FoodName = "Pizza",
                        ImageData = GetImage("pizza.png", "image/png")
                    },
                    new Food
                    {
                        FoodName = "KFC",
                        ImageData = GetImage("kfc.jpg", "image/jpg")
                    },
                    new Food
                    {
                        FoodName = "Som Tam",
                        ImageData = GetImage("somtam.jpg", "image/jpg")
                    },
                    new Food
                    {
                        FoodName = "Thai Basil",
                        ImageData = GetImage("thai-basil.jpg", "image/jpg")
                    },
                    new Food
                    {
                        FoodName = "Pad Thai",
                        ImageData = GetImage("padthai.jpg", "image/jpg")
                    },
                    new Food
                    {
                        FoodName = "Kang Keaw Wan",
                        ImageData = GetImage("keawwan.jpg", "image/jpg")
                    },
                    new Food
                    {
                        FoodName = "Bon Chon",
                        ImageData = GetImage("bonchon.jpg", "image/jpg")
                    },
                    new Food
                    {
                        FoodName = "Chicken Fried",
                        ImageData = GetImage("kaitod.jpg", "image/jpg")
                    },
                    new Food
                    {
                        FoodName = "Kang Som",
                        ImageData = GetImage("kangsom.jpg", "image/jpg")
                    },
                    new Food
                    {
                        FoodName = "Larb",
                        ImageData = GetImage("larb.jpg", "image/jpg")
                    },
                    new Food
                    {
                        FoodName = "Puk Boong",
                        ImageData = GetImage("pukboong.jpg", "image/jpg")
                    }
                );
                context.SaveChanges();
            }
        }

        private static string GetImage(string fileName, string fileType)
        {
            var path = Path.Combine(Environment.CurrentDirectory, "Db/Images", fileName);
            var imageBytes = File.ReadAllBytes(path);
            return $"data:{fileType};base64,{Convert.ToBase64String(imageBytes)}";
        }
    }
}