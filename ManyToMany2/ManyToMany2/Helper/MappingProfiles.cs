using ManyToMany2.Dto;
using ManyToMany2.Models;
using AutoMapper;

namespace ManyToMany2.Helper
{
    public class MappingProfiles :Profile
    {

        public MappingProfiles() 
        {
          CreateMap<Consultant, ConsultantDto>();
          CreateMap<ConsultantDto, Consultant>();

          

            CreateMap<Projet, ProjetDto>();
          CreateMap<ProjetDto, Projet>();
        }    
    }
}
