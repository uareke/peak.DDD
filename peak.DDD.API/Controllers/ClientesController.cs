using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using peak.DDD.Application;
using peak.DDD.Domain.Entities;
using peak.DDD.Domain.Helpers;
using peak.DDD.Domain.Interfaces;
using peak.DDD.Repository.Context;
using peak.DDD.Repository.Repository;

namespace peak.DDD.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private ClientesService appService;
        ReturnServices retorno = new ReturnServices();

        public ClientesController(SistemaContext _context)
        {
            var rep = new ClientesRepository(_context);
            appService = new ClientesService(rep);

        }


        // GET: api/Clientes
        [HttpGet]
        public IEnumerable<Clientes> Get()
        {
            return appService.Listar();
        }

        // GET: api/Clientes/5
        [HttpGet("{id}", Name = "GetClientes")]
        public Clientes Get(int id)
        {
            return appService.Obter(id);
        }

        // POST: api/Clientes
        [HttpPost]
        public ReturnServices Post([FromBody] Clientes dados)
        {
            try
            {
                appService.Incluir(dados);
                retorno.Result = true;
                retorno.ErrorMessage = string.Empty;
            }
            catch (Exception ex)
            {
                retorno.Result = false;
                retorno.ErrorMessage = $"Erro ao tentar incluir um cliente{ex.Message}";
            }
            return retorno;
        }

        // PUT: api/Clientes/5
        [HttpPut("{id}")]
        public ReturnServices Put(int id, [FromBody] Clientes dados)
        {
            try
            {
                appService.Alterar(dados);
                retorno.Result = true;
                retorno.ErrorMessage = string.Empty;
            } catch (Exception ex)
            {
                retorno.Result = false;
                retorno.ErrorMessage = $"Erro ao tentar editar um cliente {ex.Message}";
            }
            return retorno;
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ReturnServices Delete(int id)
        {
            try
            {
                appService.Excluir(id);
                retorno.Result = true;
                retorno.ErrorMessage = string.Empty;
            } catch (Exception ex)
            {
                retorno.Result = false;
                retorno.ErrorMessage = $"Erro ao tentar excluir o cliente {ex.Message}";
            }
            return retorno;
        }
           
    }
}
