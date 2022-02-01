using System.ComponentModel.DataAnnotations;

namespace Web.Shared.Attributes
{
    public class MandatoryAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            return !(value is bool) || (bool) value;
        }

        // public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata,
        //     ControllerContext context)
        // {
        //     ModelClientValidationRule rule = new ModelClientValidationRule
        //     {
        //         ErrorMessage = FormatErrorMessage(metadata.GetDisplayName()),
        //         ValidationType = "mandatory"
        //     };
        //     yield return rule;
        // }

        public override string FormatErrorMessage(string name)
        {
            // if (string.IsNullOrWhiteSpace(ErrorMessage))
            return null;
            // return MrCMSApplication.Get<IStringResourceProvider>().GetValue(name + "is required", ErrorMessage);
        }
    }
}