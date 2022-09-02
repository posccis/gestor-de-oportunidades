using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciamentoDeOportunidades
{
    [Table("Usuarios")]

    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        [Index(IsUnique = true)]
        public string Email { get; set; }

        public string Nome { get; set; }

        public RegioesEnum Regiao { get; set; }

        public ICollection<Oportunidade> Oportunidades { get; set; }



    }
}
