using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BibliotecaSebasez.Models;
using BibliotecaSebasez.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Biblioteca.Web.Controllers
{
    [Route("api/[controller]")]
    public class LibroController : Controller
    {
        private readonly IRepository<Libro> _repository;
        private readonly ILogger<CategoriaController> _logger;

        public LibroController(IRepository<Libro> repository,ILogger<CategoriaController> logger)
        {
            _repository = repository;
            _logger = logger;
        }
        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<Libro> Get()
        {
            try
            {
                return _repository.GetAll();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new List<Libro>();
            }
        }

        [Route("api/buscar/{term}")]
        public IEnumerable<Libro> Buscar(string term)
        {
            try
            {
                var parametros = new QueryEntity<Libro>();
                parametros.Where = x => x.NombreLibro.Contains(term) || x.Autor.Nombre.Contains(term) || x.Categoria.Nombre.Contains(term);
                return _repository.Buscar(parametros);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new List<Libro>();
            }
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public Libro Get(int id)
        {
            try
            {
                return _repository.FindId(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new Libro();
            }
        }

        // POST api/<controller>
        [HttpPost]
        public int Post([FromBody]Libro entity)
        {
            try
            {
                _repository.Add(entity);
                return _repository.Save();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return 0;
            }
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public Libro Put(int id, [FromBody]Libro entity)
        {
            try
            {
                _repository.Update(id, entity);
                _repository.Save();
                return entity;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new Libro();
            }
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            try
            {
                _repository.Delete(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
        }
    }
}
