using Microsoft.EntityFrameworkCore;

namespace Fiap.SPraia.UI.Models
{
    public class UsuarioContexto : DbContext
    {
        public DbSet<Usuario> Usuario { get; set; }

        public UsuarioContexto(DbContextOptions<UsuarioContexto> options) : base(options)
        {

        }
    }
}
