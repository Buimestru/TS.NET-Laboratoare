using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laborator1
{
    public class ExportEvent
    {
        public EventHandler<Event> OnChange = delegate { };

        public void Raise()
        {
            OnChange(this, new Event("Test", 22));
        }
    }
}
