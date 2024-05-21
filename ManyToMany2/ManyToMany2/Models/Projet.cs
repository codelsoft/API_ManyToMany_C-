namespace ManyToMany2.Models
{
    public class Projet
    {
        public int Id  { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }

        public ICollection<ProjetConsultant>? ProjetConsultant { get; set; }
    }
}
