using AutoMapper;
using PeopleManager.Contracts.Endereco;
using PeopleManager.Contracts.Pessoa;
using PeopleManager.Models;

namespace PeopleManager.Mapper;

public class Core : Profile
{
    
public Core()
    {
        PessoaMap();
        EnderecoMap();
    }
    
    private void PessoaMap()
    {
        CreateMap<PessoaRequest, Pessoa>();
        CreateMap<Pessoa, PessoaResponse>();
    }
    
     private void EnderecoMap()
    {
        CreateMap<EnderecoRequest, Endereco>();
        CreateMap<Endereco, EnderecoResponse>();
    }
}