﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.ViewModels
{
    public class ContactListViewModel : Base.NotifyPropertyBase
    {
        public List<Models.Person> People { get; set; }
    }
}
