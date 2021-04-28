using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CtrlShiftH.Data.Entities
{
    public class AppUser : IdentityUser<Guid>
    {
        public string FacebookId { get; set; }
        public string GoogleId { get; set; }
    }
}
