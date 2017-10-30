using System.Data.Entity;

namespace NovoBackend.Models.Contexto
{
    public class MeuNovoContexto : DbContext
    {
        public MeuNovoContexto() : base("strConn")
        {

        }

        public System.Data.Entity.DbSet<NovoBackend.Models.Dados> Dados { get; set; }
    }
}