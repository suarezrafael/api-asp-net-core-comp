using Cidades.API.Entities;
using Cidades.API.ResourcesParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cidades.API.Services
{
    public interface IApiRepository
    {
        #region CIDADES
        Cidade GetCidade(Guid cidadeId);

        //Consultar cidade pelo nome
        //Consultar cidade pelo estado
        IEnumerable<Cidade> GetCidades(CidadesResourceParameters cidadesResourceParameters);

        //Cadastrar cidade
        void AddCidade(Cidade cidade);

        bool CidadeExists(Guid cidadeId);

        #endregion CIDADES


        #region CONTEXTO

        bool Save();

        #endregion CONTEXTO


        #region CLIENTES
        Cliente GetCliente(Guid cidadeId, Guid clienteId);

        //Consultar cliente pelo nome
        IEnumerable<Cliente> GetClientes(ClientesResourceParameters clientesResourceParameters);

        //@@ Revisar com analista se para acessar clientes deve passar por cidades
        IEnumerable<Cliente> GetClientes(Guid cidadeId, ClientesResourceParameters clientesResourceParameters);
        
        //Consultar cliente pelo Id
        Cliente GetCliente(Guid clienteId);

        //Cadastrar cliente
        void AddCliente(Cliente cliente);

        //@@ Revisar com analista se para acessar clientes deve passar por cidades
        void AddCliente(Guid cidadeId, Cliente cliente);

        //Alterar o nome do cliente
        void UpdateCliente(Cliente cliente);

        //Remover cliente
        void DeleteCliente(Cliente cliente);

        #endregion CLIENTES
    }
}
