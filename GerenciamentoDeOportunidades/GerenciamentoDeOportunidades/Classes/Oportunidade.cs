using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciamentoDeOportunidades
{
    [Table("Oportunidades")]
    public class Oportunidade
    {
        public int Id { get; set; }
        public string CNPJ { get; set; }
        public string Nome { get; set; }
        public string RazaoSocial { get; set; }
        public float ValorMonetario { get; set; }
        public string DescricaoDeAtividades { get; set; }
        public string CodEstadoIBGE { get; set; }
    }
}
