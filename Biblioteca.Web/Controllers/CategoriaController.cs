using BibliotecaSebasez.Models;
using BibliotecaSebasez.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace Biblioteca.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly IRepository<Categoria> _repository;
        private readonly ILogger<CategoriaController> _logger;
        public CategoriaController(IRepository<Categoria> repository, ILogger<CategoriaController> logger)
        {
            _logger = logger;
            _repository = repository;
        }
        // GET: api/Categoria
        [HttpGet]
        public IEnumerable<Categoria> GetCategoria()
        {
            try
            {
                return _repository.GetAll();
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex.Message);
                return new List<Categoria>();
            }
        }

        // GET: api/Categoria/5
        [HttpGet("{id}")]
        public Categoria Get(int id)
        {
            try
            {
                return _repository.FindId(id);
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex.Message);
                return new Categoria();
            }
        }

        // POST: api/Categoria
        [HttpPost]
        public int Post([FromBody] Categoria entity)
        {
            try
            {
                _repository.Add(entity);
                return _repository.Save();
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex.Message);
                return 0;
            }
        }

        // PUT: api/Categoria/5
        [HttpPut("{id}")]
        public Categoria Put(int id, [FromBody] Categoria entity)
        {
            try
            {
                _repository.Update(id, entity);
                _repository.Save();
                return entity;
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex.Message);
                return new Categoria();
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            try
            {
                _repository.Delete(id);
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex.Message);
            }
        }
    }
}
