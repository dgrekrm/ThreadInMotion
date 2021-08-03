using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ThreadInMotion.Library.SharedModels.Models
{
    public class Book
    {
        [DisplayName("Kitap Adı")]
        [StringLength(maximumLength: 100, MinimumLength = 2, ErrorMessage = "Kitap adı 2 karakterden kısa olamaz")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Kitap Adı alanı zorunludur")]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Lütfen geçerli bir kitap adı yazınız")]
        public string Name { get; set; }
        [DisplayName("Yazar")]
        [StringLength(maximumLength: 100, MinimumLength = 2, ErrorMessage = "Yazar adı 2 karakterden kısa olamaz")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Yazar Adı alanı zorunludur")]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Lütfen geçerli bir yazar adı yazınız")]
        public string Author { get; set; }
        [DisplayName("Isbn")]
        [StringLength(maximumLength: 13, MinimumLength = 13, ErrorMessage = "Isbn 13 karakter olmalıdır")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Isbn alanı zorunludur")]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Lütfen geçerli bir Isbn yazınız")]
        public string Isbn { get; set; }
        public bool IsAvailable { get; set; }
        public int Id { get; set; }
    }
}
