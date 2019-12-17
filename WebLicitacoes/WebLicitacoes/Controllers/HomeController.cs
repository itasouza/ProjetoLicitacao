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
            //ListarLicitacacao("SP");
            //ListarLicitacacao("SP","2");
            ListarLicitacacao("SP", null, "engenharia");
           // ListarLicitacacao(null,null, null, "3550308");

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }



        public IActionResult ListarLicitacacao(string estado = null, string pagina = null, string ConsultaPalavra = null, string IbgeMunicipio = null)
        {
            string url = null;
            string json;
            string complementoConsulta = null;


            //licitação por estado ou mais de 1 estado
            if (estado != null && pagina == null && ConsultaPalavra == null)
                complementoConsulta = "?uf=" + estado;

            //licitação por estado e página
            if (estado != null && pagina != null && ConsultaPalavra == null)
                complementoConsulta = "?uf=" + estado + "&pagina=" + pagina;

            //licitação por palavra chave e estado, pode ser mais de 1 estado
            if (estado != null && ConsultaPalavra != null && pagina == null)
                complementoConsulta= "?uf=" + estado + " & palavra_chave= " + ConsultaPalavra;

            //consulta por município usando o código ibge
            if (IbgeMunicipio != null && estado == null && pagina == null && ConsultaPalavra == null)
                complementoConsulta = "?municipio_ibge="+ IbgeMunicipio;

            url = @"https://alertalicitacao.com.br/api/v1/licitacoesAbertas/" + complementoConsulta;


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
