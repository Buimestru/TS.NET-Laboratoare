using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelDesignFirst_L1
{
    public partial class Album
    {
        public int AlbumId { get; set; }
        public string AlbumName { get; set; }
        public ICollection<Artist> Artists { get; set; }

    }
}
