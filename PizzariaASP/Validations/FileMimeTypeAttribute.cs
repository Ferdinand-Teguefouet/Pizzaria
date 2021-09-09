using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pizzeria.ASP.Validations
{
    public class FileMimeTypeAttribute: ValidationAttribute
    {
        private readonly string[] _mimeTypes;
        public FileMimeTypeAttribute(params string[] mimeTypes)
        {
            _mimeTypes = mimeTypes;
        }

        public override bool IsValid(object value)
        {
            IFormFile file = value as IFormFile;
            if (file is null) return true;
            return _mimeTypes.Contains(file.ContentType);
        }
    }
}
