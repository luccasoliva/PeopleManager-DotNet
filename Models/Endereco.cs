namespace PeopleManager.Models;

public class Endereco
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Logradouro { get; set; }
    public string Bairro { get; set; }
    public string CidadeEstado { get; set; }
    public Boolean isPrincipal { get; set; }
    public Guid PessoaId { get; set; }
    public Pessoa Pessoa { get; set; }
    
    
    public Endereco()
    {
    }
}