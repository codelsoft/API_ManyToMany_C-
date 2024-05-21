using ManyToMany2.Data;
using ManyToMany2.Dto;
using ManyToMany2.Interface;
using ManyToMany2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;

namespace ManyToMany2.Repository
{
    public class ConsultantRepos : IConsultant
    {

        private readonly   PCContext _context;

        public ConsultantRepos(PCContext context) 
        {
            _context = context;
        }


        public Consultant  GetConsultantById(int id)
        {
            Consultant ? consultant = new Consultant();
            if (id == 0)
            {
                return consultant;
            }
            consultant = _context.Consultants.Where(c => c.Id == id).FirstOrDefault();
           
            return consultant;
        }

        public bool CreateConsultant(int projetId, List<Consultant> consultants)
        {
            var projetconsultantEntity =  _context.Projets.Where(p => p.Id == projetId).FirstOrDefault();
            bool res = false;
            foreach (var c in consultants)
            {

                ProjetConsultant projetConsultant = new ProjetConsultant()

                {
                    Projet = projetconsultantEntity,
                    Consultant = c
                };

                _context.Add(projetConsultant);
                _context.Add(c);


                res= Save();
            }

            return res;
           
        }

        public bool UpdateConsultants(int projectId, Consultant consultants)
        {
            _context.Update(consultants);
            return Save();
        }



        public ICollection<Consultant> GetConsultants()
        {
            var consultants = _context.Consultants.ToList();  
            return consultants;
        }

        public bool DeleteConsultant(Consultant consultant)
        {
           
            _context.Remove(consultant);
            return Save();

        }


        public bool ConsultantExist (int consultantId) 
        {
          var  Consultant = _context.Consultants.FirstOrDefault(x=>x.Id == consultantId);    
          if (Consultant == null) 
            {
                return false;
            }
            return true;
        }
        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool DeleteConsultant(int projectId)
        {
            throw new NotImplementedException();
        }
    }
}
