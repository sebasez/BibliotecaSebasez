using BibliotecaSebasez.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaSebasez.Repository
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();

        T FindId(int? id);

        T Add(T entity);

        T Update(int id, T entity);

        int Save();

        void Delete(int id);

        IEnumerable<T> Buscar(QueryEntity<T> parametrosBusqueda);
    }
}
