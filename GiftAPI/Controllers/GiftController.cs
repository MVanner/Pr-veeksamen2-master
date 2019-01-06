using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Entities;
using Entities.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Entities.DTO;
using Repositories;
using Contracts;

namespace GiftAPI.Controllers
{
//   1. En metode, der kan give en oversigt over alle gave objekter.
//   2. En metode, der kan returnere et bestemt gaveobjekt angivet med GiftNumber
//   3. En metode, der kan returnere gaver til henholdsvis pige eller dreng
//   4. En metode, der opretter et nyt gaveobjekt med angivelse de nødvendige data (Title, Description etc.)
    [Produces("application/xml", "application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class GiftController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GiftController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        // GET: api/Gift
        [HttpGet]
        public IEnumerable<Gift> Get()
        {
            return _unitOfWork.GiftRepository.GetAll();
        }

        [HttpGet("simple")]
        public IActionResult GetSimple()
        {
            return new ObjectResult(_mapper.Map<List<GiftDTO>>(_unitOfWork.GiftRepository.GetAll())); 
        }
        // GET: api/Gift/5
        [HttpGet("{id}")]
        public Gift Get(Guid id)
        {
            return _unitOfWork.GiftRepository.Get(id);
        }

        // POST: api/Gift
        [HttpGet("{boy}/{girl}")]
        public IEnumerable<Gift> GetByGender(bool boy, bool girl)
        {
            if (boy && !girl)
            {
                return _unitOfWork.GiftRepository.Find(x => x.BoyGift == true).ToList();
            }
            else if (girl && !boy)
            {
                  return _unitOfWork.GiftRepository.Find(x => x.GirlGift == true).ToList();
            }
            else
            {
                return _unitOfWork.GiftRepository.GetAll();
            }
        }

        // PUT: api/Gift/5
        [HttpPost]
        public IActionResult Create([FromBody] Gift gift)
        {
            gift.CreationDate = DateTime.Now;
            _unitOfWork.GiftRepository.Add(gift);
            _unitOfWork.Complete();
            return Ok();
        }
        [HttpPut]
        public IActionResult PutSimple(GiftDTO giftDTO)
        {
            if (ModelState.IsValid)
            {
                if (_unitOfWork.GiftRepository.Get(giftDTO.GiftNumber) is null)
                {
                    return NotFound();
                }

                var oldGift = _unitOfWork.GiftRepository.Get(giftDTO.GiftNumber);
                try
                {
                    oldGift.Title = giftDTO.Title;
                    oldGift.Description = giftDTO.Description;

                    _unitOfWork.Complete();
                    return Ok();
                }
                catch (Exception)
                {

                    return Conflict();
                }
            }
            else
            {
                return BadRequest();
            }
            
        }

        //[HttpPatch]
        //public IActionResult Patch(Gift gift)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        if (_)
        //        {

        //        }

                
        //    }
        //    else
        //    {
        //        return BadRequest();
        //    }
        //}

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var giftId = _unitOfWork.GiftRepository.Get(id);
            if (giftId == null)
            {
                return NotFound();
            }
            try
            {
                
                _unitOfWork.GiftRepository.Remove(giftId);
                _unitOfWork.Complete();
                return NoContent();
            }
            catch (Exception)
            {

                return Conflict();
            }
            
        }
    }
}
