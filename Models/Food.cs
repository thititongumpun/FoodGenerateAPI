using System.ComponentModel.DataAnnotations;

namespace FoodGenerateAPI.Models
{
    public class Food
    {
        [Key]
        public int Id { get; set; }
        public string FoodName { get; set; }
        public int Liked { get; set; } = 0;
        public string ImageData {get;set;}
    }
}