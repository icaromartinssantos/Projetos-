using Agenda.Domain;
using System.Data.Entity.ModelConfiguration;

namespace DevStore.Infra.Mappings
{
    public class ContatoMap : EntityTypeConfiguration<Contato>
    {
        public ContatoMap()
        {
            ToTable("Contato");

            HasKey(x => x.IDcontato);
            Property(x => x.Nome).HasMaxLength(60).IsRequired();
            Property(x => x.Data).IsRequired();

          
        }
    }
}
