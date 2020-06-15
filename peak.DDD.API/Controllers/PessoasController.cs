using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using peak.DDD.Domain.Helpers;

namespace peak.DDD.API.Controllers
{



    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("MyPolicy")]
    public class PessoasController : ControllerBase
    {
        List<KeyValuePair<int, string>> lista = new List<KeyValuePair<int, string>>();

        public PessoasController()
        {
            lista.Add(new KeyValuePair<int, string>(1, "João"));
            lista.Add(new KeyValuePair<int, string>(2, "Maria"));
            lista.Add(new KeyValuePair<int, string>(3, "Cleber"));
            lista.Add(new KeyValuePair<int, string>(4, "Alex"));
            lista.Add(new KeyValuePair<int, string>(5, "Mauricio"));
            lista.Add(new KeyValuePair<int, string>(6, "Baltazar"));
            lista.Add(new KeyValuePair<int, string>(7, "Bruno"));
            lista.Add(new KeyValuePair<int, string>(8, "Bruna"));
            lista.Add(new KeyValuePair<int, string>(9, "Cervero"));
            lista.Add(new KeyValuePair<int, string>(10, "Marcos"));
            lista.Add(new KeyValuePair<int, string>(11, "Mario"));
            lista.Add(new KeyValuePair<int, string>(12, "Luigi"));
            lista.Add(new KeyValuePair<int, string>(13, "Peach"));
            lista.Add(new KeyValuePair<int, string>(14, "Daisy"));
            lista.Add(new KeyValuePair<int, string>(15, "Thor"));
            lista.Add(new KeyValuePair<int, string>(16, "Bowser"));
            lista.Add(new KeyValuePair<int, string>(17, "Peter"));
            lista.Add(new KeyValuePair<int, string>(18, "Loiola"));
            lista.Add(new KeyValuePair<int, string>(19, "Nivea"));
            lista.Add(new KeyValuePair<int, string>(20, "Zezinho"));
        }

        [HttpGet]
        public ReturnServices Get()
        {
            ReturnServices retorno = new ReturnServices();
            string jsonString = JsonConvert.SerializeObject(lista, Formatting.None);
            retorno.Result = true;
            retorno.ErrorMessage = string.Empty;
            retorno.Dados = jsonString;

            return retorno;
        }

        [HttpGet("{valor}")]
        public ReturnServices Get(string valor)
        {
            ReturnServices retorno = new ReturnServices();
            Dictionary<int, string> procura = new Dictionary<int, string>();
            try
            {
                List<String> Dados = new SplitEntrada().SplitDados(valor);
                foreach (var ResultadoDados in Dados)
                {
                    for (int i = 0; i < lista.Count; i++)
                    {
                        if(lista[i].Key == int.Parse(ResultadoDados))
                        {
                            procura.Add(int.Parse(ResultadoDados), lista[i].Value);
                        }
                    }
                }
                string jsonString = JsonConvert.SerializeObject(procura, Formatting.None);
                retorno.Result = true;
                retorno.ErrorMessage = string.Empty;
                retorno.Dados = jsonString;

            } catch (Exception ex)
            {
                retorno.Result = false;
                retorno.ErrorMessage = $"Ocorreu um erro: {ex.Message}";
                retorno.Dados = string.Empty;
            }

            return retorno;
        }
        
    }
}