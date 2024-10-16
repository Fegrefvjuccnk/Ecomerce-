using System.ComponentModel.DataAnnotations;

namespace Talbat.Repostory.DtoMAPPER
{
    public class BasketItemDtos
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        public string PictureUrl { get; set; }
        [Required]
        [Range(1.0,double.MaxValue,ErrorMessage ="must be contain price")]
        public decimal Price { get; set; }
        [Required]
        [Range(1,int.MaxValue,ErrorMessage ="must be one item at the latest!!")]
        public int Quntity { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public string Brand { get; set; }
    }
}