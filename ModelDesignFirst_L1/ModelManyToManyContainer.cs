using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelDesignFirst_L1
{
    public partial class ModelManyToManyContainer: DbContext
    {
        public ModelManyToManyContainer()
        : base("name=Model1Container")
        { }

        protected override void OnModelCreating(
       DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }

        public virtual DbSet<Album> Albums { get; set; }
        public virtual DbSet<Artist> Artists { get; set; }
        public virtual DbSet<AlbumArtist> AlbumArtists { get; set; }
    }
}
