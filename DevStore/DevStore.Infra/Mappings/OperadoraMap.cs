using Agenda.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevStore.Infra.Mappings 
{
    public class OperadoraMap : EntityTypeConfiguration<Operadora>
    {
        public OperadoraMap()
        {
            ToTable("Operadora");

            HasKey(x => x.IDoperadora);

            Property(x => x.Nome).HasMaxLength(60).IsRequired();

            Property(x => x.preco).IsRequired();
        }
    }
}
