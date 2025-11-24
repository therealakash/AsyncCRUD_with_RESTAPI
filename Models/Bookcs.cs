using System.ComponentModel.DataAnnotations;

namespace AsyncCRUD.Models
{
    public class Book
    {
        [Key]
        public int BookId {  get; set; }

        [MaxLength(25)]
        [MinLength(6,ErrorMessage ="title must more than 6")]
        public string Title { get; set; }

        public int AuthorId {  get; set; }

        [Required(ErrorMessage ="must enter it ")]
        public string Isbn {  get; set; }
    }
}
