using Cidades.API.Entities;
using Cidades.API.ResourcesParameters;
using Cidades.API.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CidadesAPITest
{
    public class ApiRepositoryFake : IApiRepository
    {
        private readonly List<Cidade> _cidade;
        private readonly List<Cliente> _cliente;

        public ApiRepositoryFake()
        {
            _cidade = new List<Cidade>()
            {

                new Cidade() { Id = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35"), Nome = "Alegrete", Estado = "RS"}
            };

            _cliente = new List<Cliente>()
            {

                new Cliente() { Id = Guid.Parse("5b1c2b4d-48c7-402a-80c3-cc796ad49c6b"), NomeCompleto = "Rafael Vieira Suarez", Cidade = new Cidade(){ Id = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35"), Nome = "Alegrete", Estado = "RS"}}
            };
        }
        static Guid GeraId()
        {
            return Guid.NewGuid();
        }
    
        //
        public void AddCidade(Cidade cidade)
        {
            cidade.Id = GeraId();
            _cidade.Add(cidade);
        }

        public bool CidadeExists(Guid cidadeId)
        {
            return true;
        }

        public Cidade GetCidade(Guid cidadeId)
        {
            return _cidade.Where(a => a.Id == cidadeId)
                .FirstOrDefault();
        }

        public IEnumerable<Cidade> GetCidades(CidadesResourceParameters cidadesResourceParameters)
        {
            return _cidade.Where(c=>c.Nome.Contains(cidadesResourceParameters.Nome) || c.Estado.Equals(cidadesResourceParameters.Estado));
        }

        #region CLIENTE

        public void AddCliente(Cliente cliente)
        {
            cliente.Id = GeraId();
            _cliente.Add(cliente);
        }

        public Cliente GetCliente(Guid clienteId)
        {
            return _cliente.Where(a => a.Id == clienteId)
            .FirstOrDefault();
        }

        public IEnumerable<Cliente> GetClientes(ClientesResourceParameters clientesResourceParameters)
        {
            return _cliente.Where(c => c.NomeCompleto.Contains(clientesResourceParameters.NomeCompleto));

        }

        public void DeleteCliente(Cliente cliente)
        {
            var item = _cliente.First(a => a.Id == cliente.Id);
            _cliente.Remove(item);
        }

        public bool Save()
        {
           return true;
        }

        public void UpdateCliente(Cliente cliente)
        {
            Cliente clienteUpdate = this.GetCliente(cliente.Id);

        }

        #endregion CLIENTE
    }
}
