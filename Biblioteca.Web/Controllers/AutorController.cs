using BibliotecaSebasez.Models;
using BibliotecaSebasez.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace Biblioteca.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        private readonly IRepository<Autor> _repository;
        private readonly ILogger<AutorController> _logger;
        public AutorController(IRepository<Autor> repository, ILogger<AutorController> logger)
        {
            _repository = repository;
            _logger = logger;
        }
        // GET: api/Autor
        [HttpGet]
        public IEnumerable<Autor> Get()
        {
            try
            {
                return _repository.GetAll();
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex.Message);
                return new List<Autor>();
            }
        }

        // GET: api/Autor/5
        [HttpGet("{id}")]
        public Autor Get(int id)
        {
            try
            {
                return _repository.FindId(id);
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex.Message);
                return new Autor();
            }
        }

        // POST: api/Autor
        [HttpPost]
        public int Post([FromBody] Autor entity)
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

        // PUT: api/Autor/5
        [HttpPut("{id}")]
        public Autor Put(int id, [FromBody]Autor entity)
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
                return new Autor();
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
