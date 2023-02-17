 
namespace PeopleManager.Models
{
    public class Pessoa
    { 
        public Guid Id { get; set; } = Guid.NewGuid();
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public ICollection<Endereco> Endereco { get; set; }
        
 
        public Pessoa()
        {
        }
    }
}
