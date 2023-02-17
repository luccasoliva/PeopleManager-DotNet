namespace PeopleManager.Contracts.Endereco;

public record EnderecoResponse(Guid Id,
                              string Logradouro,
                              string Bairro,
                              string CidadeEstado,
                              Boolean IsPrincipal);