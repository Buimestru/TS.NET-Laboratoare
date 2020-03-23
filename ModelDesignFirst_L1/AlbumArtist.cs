using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelDesignFirst_L1
{
    public partial class AlbumArtist
    {
        public int Albums_AlbumId { get; internal set; }
        public int Artists_ArtistId { get; internal set; }
    }
}
