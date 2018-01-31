using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Agenda.Domain
{
    [Serializable]
    public class Contato
    {
        public Contato()
        {
            this.Data = DateTime.Now;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDcontato { get; set; }

        public string Nome { get; set; }

        public string Telefone { get; set; }

        public DateTime Data { get; set; }

        public int IDoperadora { get; set; }

        public virtual Operadora operadora { get; set; }

        public override string ToString()
        {
            return this.Nome;
        }
    }
}
