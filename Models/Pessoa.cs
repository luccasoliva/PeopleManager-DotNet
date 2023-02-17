 
namespace PeopleManager.Models
{
    public class Pessoa
    { 
        public Guid Id { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public ICollection<Endereco> Enderecos { get; set; }
        
 
        
    }
}
