using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BnE.EducationVest.Application.Users.ViewModels
{
    public class TermAndOptinResponseViewModel
    {
        public string Text { get; set; }
        public List<OptinResponseViewModel> Optins{ get; set; }
    }
    public class OptinResponseViewModel
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public bool Checked { get; set; }
    }
}
