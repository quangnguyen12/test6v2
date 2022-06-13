using System.ComponentModel.DataAnnotations;

namespace test6.Models
{
    public class ProductInfo
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public string origin { get; set; }
        [Required]
        public string Describe { get; set; }

    }
}
