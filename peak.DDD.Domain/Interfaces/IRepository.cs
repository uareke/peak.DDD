using peak.DDD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace peak.DDD.Domain.Interfaces
{
    public interface IRepository<T> where T: EntityBase
    {
        /// <summary>
        ///INterface para inserir os dados no banco de dados
        /// </summary>
        /// <param name="entidade"></param>
        void Incluir(T entidade);
        /// <summary>
        /// Interface para modificar os dados no banco de dados
        /// </summary>
        /// <param name="entidade"></param>
        void Alterar(T entidade);
        /// <summary>
        /// Interface para excluir um dado do banco de dados
        /// </summary>
        /// <param name="id"></param>
        void Excluir(int id);
        /// <summary>
        /// Interface para listar todos os registros
        /// </summary>
        /// <returns></returns>
        List<T> Listar();
        /// <summary>
        /// Interface para mostrare um unico registro no banco de dados
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T Obter(int id);
        
    }
}
