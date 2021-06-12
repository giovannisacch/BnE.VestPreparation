using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BnE.EducationVest.Application.Users.ViewModels
{
    public class UserMenusViewModel
    {
        public IEnumerable<MenuViewModel> Menus { get; set; }
        public string ImageUrl { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public bool TermsWasAccepted { get; set; }
    }
    public class MenuViewModel
    {
        public string Key { get; set; }
        public string Label { get; set; }
        public bool Selected { get; set; }
    }
}
