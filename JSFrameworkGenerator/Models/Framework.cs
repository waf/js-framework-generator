using System;
using System.Collections.Generic;
using System.Text;

namespace StandaloneApp.JSFrameworkGenerator.Models
{
    public class Framework
    {
        public Framework(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public string Name { get; }
        public string Description { get; }
    }
}
