using Cidades.API.DbContexts;
using Cidades.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cidades.API.Services
{
    public class ApiRepository : IApiRepository, IDisposable
    {
        private readonly ApiContext _context;

        public ApiRepository(ApiContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        #region CIDADES
        public void AddCidade(Cidade cidade)
        {
            if (cidade == null)
            {
                throw new ArgumentNullException(nameof(cidade));
            }

            // o repositório preenche o id 
            cidade.Id = Guid.NewGuid();

            foreach (var cliente in cidade.Clientes)
            {
                cliente.Id = Guid.NewGuid();
            }

            _context.Cidades.Add(cidade);
        }

        public bool CidadeExists(Guid cidadeId)
        {
            if (cidadeId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(cidadeId));
            }

            return _context.Cidades.Any(a => a.Id == cidadeId);
        }

        public Cidade GetCidade(Guid cidadeId)
        {
            if (cidadeId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(cidadeId));
            }

            return _context.Cidades.FirstOrDefault(a => a.Id == cidadeId);
        }

        public IEnumerable<Cidade> GetCidades(string nome)
        {
            if (string.IsNullOrEmpty(nome))
            {
                throw new ArgumentNullException(nameof(nome));
            }

            return _context.Cidades.Where(a => a.Nome.Contains(nome));
        }

        public IEnumerable<Cidade> GetCidadesPorEstado(string estado)
        {

            if (string.IsNullOrEmpty(estado))
            {
                throw new ArgumentNullException(nameof(estado));
            }

            return _context.Cidades.Where(a => a.Estado.Contains(estado))
                .OrderBy(a => a.Nome)
                .ToList();
        }

        public IEnumerable<Cidade> GetCidades(IEnumerable<Guid> cidadeIds)
        {
            throw new NotImplementedException();
        }

        #endregion CIDADES

        #region CLIENTES

        public void AddCliente(Guid cidadeId, Cliente cliente)
        {
            if (cidadeId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(cidadeId));
            }

            if (cliente == null)
            {
                throw new ArgumentNullException(nameof(cliente));
            }
            // sempre seta CidadeId para cidadeId passada
            cliente.CidadeId = cidadeId;
            _context.Clientes.Add(cliente);
        }

        public void DeleteCliente(Cliente cliente)
        {
            _context.Clientes.Remove(cliente);
        }

        public Cliente GetCliente(Guid cidadeId, Guid clienteId)
        {
            if (cidadeId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(cidadeId));
            }

            if (clienteId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(clienteId));
            }

            return _context.Clientes
              .Where(c => c.CidadeId == cidadeId && c.Id == clienteId).FirstOrDefault();
        }

        public Cliente GetCliente(Guid clienteId)
        {
            if (clienteId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(clienteId));
            }

            return _context.Clientes
              .Where(c => c.Id == clienteId).FirstOrDefault();
        }

        //public IEnumerable<Cliente> GetClientes(Guid cidadeId)
        //{
        //    throw new NotImplementedException();
        //}

        public IEnumerable<Cliente> GetClientes(Guid cidadeId, string nome)
        {
            if (string.IsNullOrEmpty(nome))
            {
                throw new ArgumentNullException(nameof(nome));
            }

            return _context.Clientes.Where(a => a.CidadeId == cidadeId && 
                a.NomeCompleto.Contains(nome))
                .OrderBy(a => a.NomeCompleto)
                .ToList();
        }

        public void UpdateCliente(Cliente cliente)
        {
            // sem código nessa implementação
        }

        #endregion CLIENTES


        #region CONTEXTO

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }

        /// <summary>
        /// DISPOSE
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // dispose resources when needed
            }
        }

        #endregion CONTEXTO
    }
}
