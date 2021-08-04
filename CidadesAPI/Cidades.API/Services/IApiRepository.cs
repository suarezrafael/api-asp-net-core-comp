using Cidades.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cidades.API.Services
{
    public interface IApiRepository
    {
        // CLIENTES
        //IEnumerable<Cliente> GetClientes(Guid cidadeId);

        Cliente GetCliente(Guid cidadeId, Guid clienteId);
        //Consultar cliente pelo nome
        IEnumerable<Cliente> GetClientes(string nome);
        //Consultar cliente pelo Id
        Cliente GetCliente(Guid clienteId);
        //Cadastrar cliente
        void AddCliente(Guid cidadeId, Cliente cliente);
        //Alterar o nome do cliente
        void UpdateCliente(Cliente cliente);
        //Remover cliente
        void DeleteCliente(Cliente cliente);
        
        // CIDADES
        Cidade GetCidade(Guid cidadeId);
        //Consultar cidade pelo nome
        IEnumerable<Cidade> GetCidades(string nome);
        //Consultar cidade pelo estado
        IEnumerable<Cidade> GetCidadesPorEstado(string estado);
        IEnumerable<Cidade> GetCidades(IEnumerable<Guid> cidadeIds);
        //Cadastrar cidade
        void AddCidade(Cidade cidade);
        bool CidadeExists(Guid cidadeId);
        bool Save();
    }
}
