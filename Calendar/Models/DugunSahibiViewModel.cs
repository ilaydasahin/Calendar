using WeddingCalendar.Data.Entity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeddingCalendar.Models
{
    public class DugunSahibiViewModel
    {
        public AppUser User { get; set; }
        public IEnumerable<AppUser> Organizators { get; set; }
        public List<SelectListItem> OrganizatorsSelectList { get; internal set; }
    }
}
