using System.ComponentModel.DataAnnotations;

namespace E_Commerce_Web.Model
{
    public class Product
    {
        public int Id { get; set; }
        [Required (ErrorMessage ="Name is requred ")]
        [MaxLength (3,ErrorMessage ="length is not vaild")]
        public string Name { get; set; }
    }
}
