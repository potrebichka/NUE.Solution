using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace WebApp2.Models
{
   public class PhoneNumberCheckViewModel
   {
        public string ReservationId {get;set;}
        public string AreaCode {get;set;}
        [Required(ErrorMessage = "Phone Number is needed.")]  
        [Display(Name = "Phone")]  
        [DataType(DataType.PhoneNumber)]  
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Invalid Phone number")]  

        public string PhoneNumberRaw { get; set; }
        public string ValidPhone {get;set;}
   }
}