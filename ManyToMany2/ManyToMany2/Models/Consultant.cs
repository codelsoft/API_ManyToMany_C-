namespace ManyToMany2.Models
{
    public class Consultant
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public ICollection<ProjetConsultant>? ProjetConsultant { get; set; }
       
    }
}
