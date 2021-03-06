using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrackingSystemAPI.DTO;
using TrackingSystemAPI.Models;
using TrackingSystemAPI.Repositories.MileStoneRepositories;

namespace TrackingSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MileStonesController : ControllerBase
    {
        private readonly IMileStoneRepository _mileStoneRepository;

        public MileStonesController(IMileStoneRepository mileStoneRepository)
        {
            _mileStoneRepository = mileStoneRepository;
        }


        // GET: api/MileStones
        [HttpGet]
        public IEnumerable<MileStoneDTO> GetMileStoneDTO()
        {
            return _mileStoneRepository.GetAll();
        }

        // GET: api/MileStones/5
        [HttpGet("{id}")]
        public ActionResult <MileStoneDTO> GetMileStoneDTO(int id)
        {
            var mileStoneDTO = _mileStoneRepository.GetById(id);

            if (mileStoneDTO == null)
            {
                return NotFound();
            }

            return mileStoneDTO;
        }
        [HttpGet]
        [Route("GetMileStonesByProjectId/{ProjectId}")]
        public IEnumerable<MileStoneDTO> GetMileStonesByProjectId(int ProjectId)
        {
            return _mileStoneRepository.GetMileStonesByProjectId(ProjectId);
        }
        // PUT: api/MileStones/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public  IActionResult PutMileStoneDTO(int id, MileStoneDTO mileStoneDTO)
        {
            if (id != mileStoneDTO.Id)
            {
                return BadRequest();
            }

            _mileStoneRepository.Update(mileStoneDTO);

            try
            {
                _mileStoneRepository.Save();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                string message = ex.Message;
            }

            return NoContent();
        }

        //update by id
        [HttpPut("{id}")]
        [Route("PutmilestonesDTOByProjectId/{id}")]
        public IActionResult PutmilestonesDTOByProjectId(int id, List<MileStoneDTO> mileStoneDTOs)
        {


            _mileStoneRepository.UpdateByProjectId(id, mileStoneDTOs);

            try
            {
                _mileStoneRepository.Save();


            }
            catch (DbUpdateConcurrencyException ex)
            {
                string message = ex.Message;
            }

            return Ok();
        }

        // POST: api/MileStones
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
       
        public ActionResult<MileStoneDTO> PostMileStoneDTO(List<MileStoneDTO> mileStoneDTO)
        {
            _mileStoneRepository.Add(mileStoneDTO);
            _mileStoneRepository.Save();

            return CreatedAtAction("GetMileStoneDTO", new { id = mileStoneDTO.Count() }, mileStoneDTO);
        }
        // DELETE: api/MileStones/5
        [HttpDelete("{id}")]
        public ActionResult<MileStoneDTO> DeleteMileStoneDTO(int id)
        {
            var mileStoneDTO =_mileStoneRepository.Find(id);
            if (mileStoneDTO == null)
            {
                return NotFound();
            }

            _mileStoneRepository.Delete(id);
            _mileStoneRepository.Save();
            return Ok();
        }

        
    }
}
