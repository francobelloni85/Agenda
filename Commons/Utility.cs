using Agenda.Enumerations;
using Agenda.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.Commons
{
    public sealed class GetDescriptions
    {
        private static Strings instance = null;

        private GetDescriptions() { }

        public static Strings Instance {
            get {
                if (instance == null)
                {
                    instance = new Strings(Language.en);
                }
                return instance;
            }
        }
    }
}
