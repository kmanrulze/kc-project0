﻿using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApp.Library.Objects
{
    class Manager
    {
        public string firstName { get; set; }
        public string lastName { get; set; }

        public void SetFirstName(string name)
        {
            this.firstName = name; 
        }
        public void SetLastName(string name)
        {
            this.lastName = name;
        }
    }
}