using System.ComponentModel.DataAnnotations;

namespace CodeFirstApplication.Models
{
    public class ProductModel
    {
        [Key]
        public int IdProduct { set; get; }
        [MaxLength(50)] [Required]
        public string NameProduct { set; get; }
        [MaxLength(100)]
        public string DescriptionProduct { set; get; }
        public string ImageUrlProduct { get; set; }
        public int MemoryProduct { get; set; }
        public int StorageCapacityProduct { get; set; }
        [MaxLength(50)]
        public string ResolutionImageProduct { get; set; }
        public double PriceProduct { get; set; }
        public int CategoryId { get; set; }
        public CategoryModel Category { get; set; }
    }
}
