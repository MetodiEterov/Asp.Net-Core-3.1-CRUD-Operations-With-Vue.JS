using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AutoMapper;

using Entities.Contracts;
using Entities.DTOs;
using Entities.Models;

using Microsoft.AspNetCore.Mvc;

namespace AccountOwnerServer.Controllers
{
    /// <summary>
    /// OwnerController class responisble for handling all requests
    /// </summary>
    [Route("api/owner")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public OwnerController(ILoggerManager logger, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        /// <summary>
        /// CreateOwner method is responsible for the post requests to the service logic
        /// </summary>
        /// <param name="owner"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateOwner([FromBody] OwnerForCreationDto owner)
        {
            if (owner == null)
            {
                _logger.LogInfo("Owner object sent from client is null.");
                return BadRequest("Owner object is null");
            }

            if (!ModelState.IsValid)
            {
                _logger.LogError("Invalid owner object sent from client.");
                return BadRequest("Invalid model object");
            }

            var ownerEntity = _mapper.Map<Owner>(owner);
            _unitOfWork.Owner.CreateOwner(ownerEntity);

            await _unitOfWork.SaveAsync();
            var createdOwner = _mapper.Map<OwnerDto>(ownerEntity);

            return CreatedAtRoute("OwnerById", new { id = createdOwner.Id }, createdOwner);
        }

        /// <summary>
        /// DeleteOwner method is responsible for the delete requests to the service logic
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOwner(Guid id)
        {
            var owner = await _unitOfWork.Owner.GetOwnerByIdAsync(id);
            if (owner == null)
            {
                _logger.LogInfo($"Owner with id: {id}, hasn't been found in db.");
                return NotFound();
            }

            if (_unitOfWork.Account.AccountsByOwner(id).Any())
            {
                _logger.LogInfo(
                    $"Cannot delete owner with id: {id}. It has related accounts. Delete those accounts first");
                return BadRequest("Cannot delete owner. It has related accounts. Delete those accounts first");
            }

            _unitOfWork.Owner.DeleteOwner(owner);
            await _unitOfWork.SaveAsync();

            return NoContent();
        }

        /// <summary>
        /// GetAllOwners method read all owners from the service
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllOwners()
        {
            var owners = await _unitOfWork.Owner.GetAllOwnersAsync();
            var ownersResult = _mapper.Map<IEnumerable<OwnerDto>>(owners);

            return Ok(ownersResult);
        }

        [HttpGet("{id}", Name = "OwnerById")]
        public async Task<IActionResult> GetOwnerById(Guid id)
        {
            var owner = await _unitOfWork.Owner.GetOwnerByIdAsync(id);
            if (owner == null)
            {
                _logger.LogInfo($"Owner with id: {id}, hasn't been found in db.");
                return NotFound();
            }

            var ownerResult = _mapper.Map<OwnerDto>(owner);

            return Ok(ownerResult);
        }

        /// <summary>
        /// GetOwnerWithDetails method read details for specific user
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}/account")]
        public async Task<IActionResult> GetOwnerWithDetails(Guid id)
        {
            var owner = await _unitOfWork.Owner.GetOwnerWithDetailsAsync(id);
            if (owner == null)
            {
                _logger.LogInfo($"Owner with id: {id}, hasn't been found in db.");
                return NotFound();
            }

            var ownerResult = _mapper.Map<OwnerDto>(owner);

            return Ok(ownerResult);
        }

        /// <summary>
        /// UpdateOwner method, update entire record
        /// </summary>
        /// <param name="id"></param>
        /// <param name="owner"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOwner(Guid id, [FromBody] OwnerForUpdateDto owner)
        {
            if (owner == null)
            {
                _logger.LogInfo("Owner object sent from client is null.");
                return BadRequest("Owner object is null");
            }

            if (!ModelState.IsValid)
            {
                _logger.LogInfo("Invalid owner object sent from client.");
                return BadRequest("Invalid model object");
            }

            var ownerEntity = await _unitOfWork.Owner.GetOwnerByIdAsync(id);
            if (ownerEntity == null)
            {
                _logger.LogInfo($"Owner with id: {id}, hasn't been found in db.");
                return NotFound();
            }

            _mapper.Map(owner, ownerEntity);
            _unitOfWork.Owner.UpdateOwner(ownerEntity);
            await _unitOfWork.SaveAsync();

            return NoContent();
        }
    }
}
