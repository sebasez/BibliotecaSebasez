using BibliotecaSebasez.Data;
using BibliotecaSebasez.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace BibliotecaSebasez.Repository
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        private readonly BibliotecaDbContext _context;

        public Repository(BibliotecaDbContext context)
        {
            _context = context;
        }

        public T Add(T entity)
        {
            _context.Set<T>().Add(entity);
            return entity;
        }

        public IEnumerable<T> Buscar(QueryEntity<T> parametrosBusqueda)
        {
            Expression<Func<T, bool>> whereTrue = x => true;
            var where = (parametrosBusqueda.Where == null) ? whereTrue : parametrosBusqueda.Where;
            return _context.Set<T>().Where(where).OrderBy(o => o.Id).ToList();
        }

        public void Delete(int id)
        {
            var entity = _context.Set<T>().FirstOrDefault(f => f.Id == id);
            _context.Set<T>().Remove(entity);
        }

        public T FindId(int? id)
        {
            return _context.Set<T>().Find(id.Value);
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public int Save()
        {
            return _context.SaveChanges();
        }

        public T Update(int id, T entity)
        {
            if (id == entity.Id)
            {
                _context.Update(entity);
                return entity;
            }
            return null;
        }
    }
}
