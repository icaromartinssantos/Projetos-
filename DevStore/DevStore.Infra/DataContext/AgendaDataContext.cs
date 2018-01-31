using Agenda.Domain;
using DevStore.Infra.Mappings;
using System;
using System.Data.Entity;

namespace Agenda.Infra.DataContext
{
    public class AgendaDataContext : DbContext
    {
        public AgendaDataContext() 
            : base("AgendaConnectionString")
        {
            Database.SetInitializer<AgendaDataContext>(new AgendaDataContextInitializer());
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;

        }

        public DbSet<Contato> contato { get; set; }
        public DbSet<Operadora> operadora { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ContatoMap());
            modelBuilder.Configurations.Add(new OperadoraMap());
            base.OnModelCreating(modelBuilder);
        }

    }

    public class AgendaDataContextInitializer : DropCreateDatabaseIfModelChanges<AgendaDataContext>
    {
        protected override void Seed(AgendaDataContext context)
        {
          

            context.operadora.Add(new Operadora {IDoperadora = 1, Nome = "OI", codigo = 14, categoria = "celular", preco = 2 });
            context.operadora.Add(new Operadora { IDoperadora = 2, Nome = "VIVO", codigo = 15, categoria = "celular", preco = 1 });
            context.operadora.Add(new Operadora { IDoperadora = 3, Nome = "TIM", codigo = 41, categoria = "celular", preco = 3 });
            context.operadora.Add(new Operadora { IDoperadora = 4, Nome = "EMBRATEL", codigo = 65, categoria = "celular", preco = 4 });
            context.operadora.Add(new Operadora { IDoperadora = 5, Nome = "GVT", codigo = 23, categoria = "celular", preco = 5 });
            context.SaveChanges();

            context.contato.Add(new Contato { IDcontato = 1, Nome = "Pedro", Telefone = "9999-9999", Data = DateTime.Now, IDoperadora = 1 });
            context.contato.Add(new Contato { IDcontato = 2, Nome = "Jorge", Telefone = "9235-8688", Data = DateTime.Now, IDoperadora = 2 });
            context.contato.Add(new Contato { IDcontato = 3, Nome = "Mario", Telefone = "9999-3488", Data = DateTime.Now, IDoperadora = 3 });
            context.contato.Add(new Contato { IDcontato = 4, Nome = "Clara", Telefone = "9934-8588", Data = DateTime.Now, IDoperadora = 4 });
            context.SaveChanges();

            base.Seed(context);
        }
    }
}
