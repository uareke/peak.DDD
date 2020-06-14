using Microsoft.EntityFrameworkCore;
using peak.DDD.Domain.Entities;
using peak.DDD.Domain.Interfaces;
using peak.DDD.Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace peak.DDD.Repository.Repository
{
    public class ClientesRepository : IClientesRepository, IDisposable
    {

        private readonly SistemaContext _context;

        public ClientesRepository(SistemaContext context)
        {
            _context = context;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public void Alterar(Clientes entidade)
        {
            var original = _context.Clientes.Find(entidade.Id);
            original.nome = entidade.nome;
            original.cpf = entidade.cpf;
            original.modified = DateTime.Now;
            _context.SaveChanges();
        }

 

        public void Excluir(int id)
        {
            var original = _context.Clientes.Find(id);
            _context.Remove(original);
            _context.SaveChanges();
        }

        public void Incluir(Clientes entidade)
        {
            var original = _context.Clientes.Add(entidade);
            _context.SaveChanges();
        }

        public List<Clientes> Listar()
        {
            return _context.Clientes.ToList();
        }

        public Clientes Obter(int id)
        {
            return _context.Clientes.Find(id);
        }
    }
}
