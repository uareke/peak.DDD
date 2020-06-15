using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using peak.DDD.Domain.Entities;
using peak.DDD.Domain.Helpers;

namespace peak.DDD.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("MyPolicy")]
    public class FinancController : ControllerBase
    {

        [HttpPost]
        public ReturnServices Post([FromBody] Calculo calc)
        {
            ReturnServices retorno = new ReturnServices();
            try
            {
                decimal resultado = (calc.Parcelas * calc.Valor) * 1.05m;
                retorno.Result = true;
                retorno.ErrorMessage = string.Empty;
                retorno.Dados = resultado.ToString();
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