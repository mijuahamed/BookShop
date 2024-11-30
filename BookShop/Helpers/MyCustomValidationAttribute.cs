using System.ComponentModel.DataAnnotations;

namespace BookShop.Helpers
{
    public class MyCustomValidationAttribute:ValidationAttribute
    {
        public  MyCustomValidationAttribute(string text)
        {
            Text = text;
        }
        public string Text { get; set; }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                string data = value.ToString();
                if (data.Contains(Text))
                {
                    return ValidationResult.Success;
                }
            }
            return new ValidationResult(ErrorMessage ?? "Doesn't contain the desire data");
            
        }
    }
}
