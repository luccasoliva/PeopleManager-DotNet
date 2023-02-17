namespace PeopleManager.Contracts.Pessoa;

public record CreatePessoaRequest(
    string Nome,
    string Email
);