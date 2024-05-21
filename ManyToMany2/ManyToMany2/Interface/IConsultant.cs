using ManyToMany2.Dto;
using ManyToMany2.Models;

namespace ManyToMany2.Interface
{
    public interface IConsultant
    {
        ICollection<Consultant> GetConsultants();
        Consultant  GetConsultantById(int id);

       
        bool CreateConsultant(int projetId, List<Consultant> consultant);

        bool UpdateConsultants(int projectId,Consultant consultant);

        bool DeleteConsultant(Consultant consultant);

        bool ConsultantExist(int consultantId);
        bool Save();
        
    }
}
