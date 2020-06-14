using peak.DDD.Domain.Entities;
using peak.DDD.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace peak.DDD.Application
{
    public class ClientesService : IClientesRepository
    {
        IClientesRepository repositorio;
        public ClientesService(IClientesRepository clientes)
        {
            this.repositorio = clientes;
        }

        public void Alterar(Clientes entidade)
        {
            if (entidade.Valida)
            {
                repositorio.Alterar(entidade);
            }
        }

        public void Excluir(int id)
        {
            repositorio.Excluir(id);
        }

        public void Incluir(Clientes entidade)
        {
            if (entidade.Valida)
            {
                repositorio.Incluir(entidade);
            }
        }

        public List<Clientes> Listar()
        {
            return repositorio.Listar();
        }

        public Clientes Obter(int id)
        {
            return repositorio.Obter(id);
        }
    }
}
