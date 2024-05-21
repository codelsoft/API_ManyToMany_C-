namespace ManyToMany2.Models
{
    public class ProjetConsultant
    {
        public int ProjetId { get; set; }
        public int ConsultantId { get; set; }

        public Projet? Projet { get; set; }
        public  Consultant?  Consultant { get; set;}



    }
}
