﻿
using BarbeariaABC.API.Repositories;
using BarbeariaABC.API.Repositories.Exceptions;
using BarbeariaABC.Models;
using Microsoft.AspNetCore.Mvc;


namespace BarbeariaABC.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AtendimentosController : ControllerBase
    {
        private readonly IAtendimentoRepository _repo;
        private readonly ILogger<AtendimentosController> _logger;

        public AtendimentosController(IAtendimentoRepository repo, ILogger<AtendimentosController> logger)
        {
            _repo = repo;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var objs = await _repo.GetAllAsync();
                return Ok(objs);
            }
            catch (RepositoryException ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving all clients.");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while retrieving all clients.");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var obj = await _repo.GetByIdAsync(id);
                if (obj == null)
                {
                    return NotFound();
                }
                return Ok(obj);
            }
            catch (RepositoryException ex)
            {
                _logger.LogError(ex, $"An error occurred while retrieving the client with ID {id}.");
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred while retrieving the client with ID {id}.");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add(Atendimento obj)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                await _repo.AddAsync(obj);
                return CreatedAtAction(nameof(GetById), new { id = obj.Id }, obj);
            }
            catch (RepositoryException ex)
            {
                _logger.LogError(ex, "An error occurred while adding a new client.");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while adding a new client.");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Atendimento obj)
        {
            if (id != obj.Id)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                await _repo.UpdateAsync(obj);
                return NoContent();
            }
            catch (RepositoryException ex)
            {
                _logger.LogError(ex, "An error occurred while updating the client.");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while updating the client.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _repo.DeleteAsync(id);
                return NoContent();
            }
            catch (RepositoryException ex)
            {
                _logger.LogError(ex, $"An error occurred while deleting the client with ID {id}.");
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred while deleting the client with ID {id}.");
            }
        }
    }
}
