using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laborator1
{
    public class Event
    {
        public string Name { get; set; }
        public int Value { get; set; }
        public Event(string name, int value)
        {
            Name = name;
            Value = value;
        }
    }
}
