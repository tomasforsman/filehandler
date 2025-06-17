using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.Configuration;

namespace FileHandler.Contracts.Configuration
{
    public static class ConfigurationValidator
    {
        public static ApplicationConfiguration GetValidatedConfiguration(IConfiguration configuration)
        {
            var appConfig = new ApplicationConfiguration();
            configuration.Bind("AppConfig", appConfig);

            // Validate the configuration
            var validationContext = new ValidationContext(appConfig);
            var validationResults = new List<ValidationResult>();
            
            if (!TryValidateObjectRecursively(appConfig, validationContext, validationResults))
            {
                var errors = string.Join("\n", validationResults.Select(vr => vr.ErrorMessage));
                throw new InvalidOperationException($"Configuration validation failed:\n{errors}");
            }

            return appConfig;
        }

        private static bool TryValidateObjectRecursively(object obj, ValidationContext validationContext, ICollection<ValidationResult> results)
        {
            bool isValid = Validator.TryValidateObject(obj, validationContext, results, true);

            var properties = obj.GetType().GetProperties()
                .Where(prop => prop.CanRead && !prop.GetIndexParameters().Any() && prop.PropertyType.IsClass && prop.PropertyType != typeof(string));

            foreach (var property in properties)
            {
                var value = property.GetValue(obj);
                if (value != null)
                {
                    var nestedContext = new ValidationContext(value);
                    isValid = TryValidateObjectRecursively(value, nestedContext, results) && isValid;
                }
            }

            return isValid;
        }
    }
}