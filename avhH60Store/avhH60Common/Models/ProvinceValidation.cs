using System.ComponentModel.DataAnnotations;

namespace avhH60Common.Models
{
    internal class ProvinceValidation : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is string selectedProvince)
            {
                return Validation.ValidateProvince(Customer.GetProvincesList(), selectedProvince);
            }
            return false;
        }
    }
}
