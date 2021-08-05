using Cidades.API.Entities;
using Cidades.API.ResourcesParameters;
using System;
using System.Collections.Generic;

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

        //Consultar cliente pelo nome
        IEnumerable<Cliente> GetClientes(ClientesResourceParameters clientesResourceParameters);

        //Consultar cliente pelo Id
        Cliente GetCliente(Guid clienteId);

        //Cadastrar cliente
        void AddCliente(Cliente cliente);

        //Alterar o nome do cliente
        void UpdateCliente(Cliente cliente);

        //Remover cliente
        void DeleteCliente(Cliente cliente);

        #endregion CLIENTES
    }
}
