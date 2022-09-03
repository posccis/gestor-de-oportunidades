using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciamentoDeOportunidades
{

    public class Usuario
    {
        [Key]
        public string EmailId { get; set; }

        public string Nome { get; set; }

        public RegioesEnum Regiao { get; set; }

        public ICollection<Oportunidade> ?Oportunidades { get; set; }



    }
}
