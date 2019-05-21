using System.Data.Entity;

namespace Contatos.Models
{
    public class ContatoDbContext: DbContext
    {
        public DbSet<Contato> Contatos { get; set; }
    }
}