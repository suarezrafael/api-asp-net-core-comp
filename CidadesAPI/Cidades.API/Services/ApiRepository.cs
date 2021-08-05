using Cidades.API.DbContexts;
using Cidades.API.Entities;
using Cidades.API.ResourcesParameters;
using Microsoft.EntityFrameworkCore;
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

        public IEnumerable<Cidade> GetCidades()
        {
            return _context.Cidades.ToList<Cidade>();
        }

        //Consultar cidade pelo nome
        //Consultar cidade pelo estado
        public IEnumerable<Cidade> GetCidades(CidadesResourceParameters cidadesResourceParameters)
        {
            if (cidadesResourceParameters == null)
            {
                throw new ArgumentNullException(nameof(cidadesResourceParameters));
            }

            if (string.IsNullOrWhiteSpace(cidadesResourceParameters.Nome) && 
                string.IsNullOrWhiteSpace(cidadesResourceParameters.Estado))
            {
                return GetCidades();
            }

            var collection = _context.Cidades as IQueryable<Cidade>;

            if (!string.IsNullOrWhiteSpace(cidadesResourceParameters.Nome))
            {
                var nome = cidadesResourceParameters.Nome.Trim();
                collection = collection.Where(a => a.Nome == nome);
            }

            if (!string.IsNullOrWhiteSpace(cidadesResourceParameters.Estado))
            {

                var estado = cidadesResourceParameters.Estado.Trim();
                collection = collection.Where(a => a.Estado.Contains(estado) );
            }

            return collection.ToList();
        }

        #endregion CIDADES





        #region CLIENTES

        public void AddCliente(Cliente cliente)
        {
            if (cliente == null)
            {
                throw new ArgumentNullException(nameof(cliente));
            }
            _context.Clientes.Add(cliente);
        }

        public void DeleteCliente(Cliente cliente)
        {
            _context.Clientes.Remove(cliente);
        }

        public Cliente GetCliente(Guid clienteId)
        {
            if (clienteId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(clienteId));
            }

            return _context.Clientes.Include( c => c.Cidade)
              .Where(c => c.Id == clienteId).FirstOrDefault();
        }

        public IEnumerable<Cliente> GetClientes(ClientesResourceParameters clientesResourceParameters)
        {
            if (clientesResourceParameters == null)
            {
                throw new ArgumentNullException(nameof(clientesResourceParameters));
            }

            var nomeCompleto = "";

            var collection = _context.Clientes.Include(c => c.Cidade) as IQueryable<Cliente>;

            if (!string.IsNullOrWhiteSpace(clientesResourceParameters.NomeCompleto))
            {
                nomeCompleto = clientesResourceParameters.NomeCompleto.Trim();
                collection = collection.Where(a => a.NomeCompleto.Contains(nomeCompleto));
            }
            
            return collection.ToList();
        }

        public IEnumerable<Cliente> GetClientes()
        {
            return _context.Clientes.ToList<Cliente>();
        }

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

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // descartar recursos quando necessário
            }
        }

        #endregion CONTEXTO
    }
}
