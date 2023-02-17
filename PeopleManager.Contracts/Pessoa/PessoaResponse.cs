namespace PeopleManager.Contracts.Pessoa;

public record PessoaResponse(Guid Id, 
                             string Nome, 
                             string Email);