using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ThreadInMotion.Library.SharedModels.Models
{
    public class Member
    {
        [DisplayName("Ad-Soyad")]
        [StringLength(maximumLength: 100, MinimumLength = 5, ErrorMessage = "Ad-Soyad 5 karakterden kısa olamaz")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Ad-Soyad alanı zorunludur")]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Lütfen geçerli bir ad-soyad yazınız")]
        public string FullName { get; set; }
    }
}
