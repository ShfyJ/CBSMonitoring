using CBSMonitoring.DTOs;
using System.ComponentModel.DataAnnotations;

namespace CBSMonitoring.Helpers
{
    public static class ValidationResultExtensions
    {
        public static List<ValidationError> ToValidationErrors(this IEnumerable<ValidationResult> validationResults)
        {
            var errors = new List<ValidationError>();

            foreach (var validationResult in validationResults)
            {
                if (validationResult.MemberNames.Any())
                {
                    foreach (var memberName in validationResult.MemberNames)
                    {
                        errors.Add(new ValidationError(memberName, validationResult.ErrorMessage));
                    }
                }
                else
                {
                    // Handle ValidationResult without member names
                    errors.Add(new ValidationError(string.Empty, validationResult.ErrorMessage));
                }
            }

            return errors;
        }
    }
}
