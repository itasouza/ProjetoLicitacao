using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebLicitacoes.Models
{
    public class RootObject
    {
        public int totalErros { get; set; }
        public string totalLicitacoes { get; set; }
        public int paginas { get; set; }
        public int licitacoesPorPagina { get; set; }
        public List<Licitaco> licitacoes { get; set; }
        public List<object> erros { get; set; }
    }
}
