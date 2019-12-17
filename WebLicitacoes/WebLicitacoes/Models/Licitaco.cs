using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebLicitacoes.Models
{
    public class Licitaco
    {
        public string id_licitacao { get; set; }
        public string titulo { get; set; }
        public string municipio_IBGE { get; set; }
        public string uf { get; set; }
        public string orgao { get; set; }
        public string abertura_datetime { get; set; }
        public string objeto { get; set; }
        public string link { get; set; }
        public string linkExterno { get; set; }
        public string municipio { get; set; }
        public string abertura { get; set; }
        public string aberturaComHora { get; set; }
        public string id_tipo { get; set; }
        public string tipo { get; set; }
    }
}
