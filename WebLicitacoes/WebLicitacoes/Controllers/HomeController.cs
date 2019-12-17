using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebLicitacoes.Models;

namespace WebLicitacoes.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            ListarLicitacacao("SP",1, "engenharia", "3550308");
            //ListarLicitacacao("SP,BA", 1, "engenharia");
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }



        public IActionResult ListarLicitacacao(string estado, int pagina, string ConsultaPalavra, string IbgeMunicipio)
        {
            string url = null;
            string json;

            if (string.IsNullOrEmpty(estado))
            {
                estado = "SP";
            }

            //licitação por estado
            if(estado != null)
               // url = @"https://alertalicitacao.com.br/api/v1/licitacoesAbertas/?uf=" + estado;

            //licitação por estado e página
            if (estado != null && pagina > 0)
             //   url = @"https://alertalicitacao.com.br/api/v1/licitacoesAbertas/?uf=" + estado + " &pagina = " + pagina;

            //licitação por palavra chave e estado, pode ser mais de 1 estado
            if (estado != null && ConsultaPalavra != null)
             //   url = @"https://alertalicitacao.com.br/api/v1/licitacoesAbertas/?uf=" + estado + " &palavra_chave = " + ConsultaPalavra;

            //consulta por município usando o código ibge
            if (IbgeMunicipio != null)
                url = @"https://alertalicitacao.com.br/api/v1/licitacoesAbertas/?municipio_ibge="+ IbgeMunicipio;


            using (WebClient wc = new WebClient())
            {
                wc.Headers["Cookie"] = "security=true";
                json = wc.DownloadString(url);
            }

            RootObject resultadoRoot = JsonConvert.DeserializeObject<RootObject>(json);
            string totalLicitacoes = resultadoRoot.totalLicitacoes;
            int paginas = resultadoRoot.paginas;
            int licitacoesPorPagina = resultadoRoot.licitacoesPorPagina;


            return View();
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
