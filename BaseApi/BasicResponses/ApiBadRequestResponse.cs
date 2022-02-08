using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BaseApi.Api.BasicResponses
{
    public class ApiBadRequestResponse : ApiResponse

    {
        public ApiBadRequestResponse(ValidationResult results)
            : base(400)
        {
            if (results.IsValid)
            {
                throw new ArgumentException("ModelState must be invalid", nameof(results));
            }

            Errors = results.Errors.Select(e => $"Property { e.PropertyName} is not valid. { e.ErrorMessage }");
        }

        public IEnumerable<string> Errors { get; set; }
    }
}