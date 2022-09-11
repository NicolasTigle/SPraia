using Microsoft.EntityFrameworkCore;

namespace Fiap.SPraia.UI.Models
{
    public class DenunciaContexto : DbContext
    {
        public DbSet<Denuncia> Denuncia  { get; set; }

        public DenunciaContexto(DbContextOptions<DenunciaContexto> options) : base(options)
        {

        }
    }
}
