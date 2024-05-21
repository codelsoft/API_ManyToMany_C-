using AutoMapper;
using ManyToMany2.Interface;
using ManyToMany2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ManyToMany2.Dto;

namespace ManyToMany2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultantController : ControllerBase
    {
        private readonly IConsultant _consultantRepos;
        private readonly IMapper _mapper;

       public  ConsultantController(IConsultant consultantRepos, IMapper mapper) 
       {
            _consultantRepos = consultantRepos;
         _mapper = mapper;
       }

        [HttpGet]
        public ActionResult  Get() 
        {
            var consultants = _mapper.Map<List<ConsultantDto>>(_consultantRepos.GetConsultants());
            if(!ModelState.IsValid) 
            {
                return BadRequest(ModelState);
            }
            return Ok(consultants);
        }

        //Get Consult by Id
        [HttpGet("{id}")]
        public ActionResult Get(int id) 
        {
            if(id == 0) 
            {
                return BadRequest(ModelState);
            }

            var consultants = _mapper.Map<List<ConsultantDto>>(_consultantRepos.GetConsultants());
            
            return Ok(consultants.FirstOrDefault(x => x.Id == id)); 
        }

        [HttpPost]
        public ActionResult CraeateConsultant( int projetId, List<ConsultantDto> consultantDto) 
        {
            if (consultantDto == null)
                return BadRequest(ModelState);

         
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

             var consultantMap = _mapper.Map<List<Consultant>>(consultantDto);
           
            if (!_consultantRepos.CreateConsultant(projetId, consultantMap))
            {
                ModelState.AddModelError("", "Une Erreur s'est produite, les données ne sont sauvegardées ");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        //Update Consultant

        [HttpPut]
        public  ActionResult  UpdateConsultant(int consultantId, int projetId, ConsultantDto updateconsultdto) 
        {
          if(consultantId == 0 || updateconsultdto.Id != consultantId ) 
           {
                return BadRequest(ModelState);
           }

            if (!_consultantRepos.ConsultantExist(consultantId)) 
            {
              return NotFound();
            }
            if (!ModelState.IsValid) 
            {
             return BadRequest();
            }

            var consultantMapUpdate = _mapper.Map<Consultant>(updateconsultdto);
            
            if (!_consultantRepos.UpdateConsultants(projetId,consultantMapUpdate)) 
            {
                ModelState.AddModelError("", "Une Erreur s'est produite, les données ne sont sauvegardées ");
                return StatusCode(500, ModelState);
            }
           
            return NoContent(); 
        }

        //Delete consultant

        [HttpDelete("{id}")]
        public  ActionResult DeleteConsultants(int consultantId)
        {
           if(consultantId == 0) 
            {
                return BadRequest(ModelState);
            }
            
            var consultant =_consultantRepos.GetConsultants().FirstOrDefault(x=>x.Id == consultantId);
           if (consultant == null) 
            {
                return BadRequest();
            }


            var consultantMap = _mapper.Map<Consultant>(consultant);

             if(!_consultantRepos.DeleteConsultant(consultantMap)) 
              {
                ModelState.AddModelError("", "Une Erreur s'est produite, les données ne sont sauvegardées ");
                return StatusCode(500, ModelState);
            }

             return NoContent();

        }
    }
}
