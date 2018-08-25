using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.Models
{
    public class County
    {
        public string Name {get; set; }
        public string CountryCode { get; set; }
        public string Number { get; set; }

        public string Path {
            get {
                return "../Assets/Images/" + CountryCode.ToUpper() + ".png";
            }
        }


    }
}
