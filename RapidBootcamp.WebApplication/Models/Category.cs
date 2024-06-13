using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RapidBootcamp.WebApplication.Models
{
    public class Category
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CategoryId { get; set; }

        // data anotation for CategoryName
        [Required]
        [StringLength(255)]
        public string CategoryName { get; set; }

        // navigation property (one to many / one category, many products) ** Check Models.Product
        public IEnumerable<Product>? Products { get; set; }
    }
}
