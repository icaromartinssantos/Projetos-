using System.ComponentModel.DataAnnotations.Schema;

namespace Agenda.Domain
{
    public class Operadora
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDoperadora { get; set; }

        public string Nome { get; set; }

        public int codigo { get; set; }

        public string categoria { get; set; }

        public decimal preco { get; set; }

        public override string ToString()
        {
            return this.Nome;
        }

    }
}