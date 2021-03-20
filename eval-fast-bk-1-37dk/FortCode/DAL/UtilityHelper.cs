using FortCode.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FortCode.DAL
{
    public class UtilityHelper : IutilsHelper
    {
        public UtilityHelper(IConfiguration configuration)
        {
            this.Connection_string = configuration.GetSection("ConnectionStrings").GetSection("DefaultConnection").Value;
        }
    }
}
