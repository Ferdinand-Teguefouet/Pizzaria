using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzariaASP.services
{
    public interface IFileService
    {
        string AddFile(IFormFile file);
    }
}
