using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.Models
{
    public class Strings
    {

        public string AddNewContact_title = "Add new Contact";
        public string EditContact_title = "Edit Contact";

        public Strings(Enumerations.Language language){

            switch (language) {
                case Enumerations.Language.it:
                    AddNewContact_title = "Crea Contatto";
                    EditContact_title = "Modifica Contatto";
                    break;
            }

        }

    }
}
