using System;
using LojaApi.Data;
using LojaApi.Entities;
using LojaApi.Repositories.Interfaces;

namespace LojaApi.Repositories;

public class ClienteDBRepository : IClienteRepository 
    { 
        private readonly LojaContext _context; 
 
        public ClienteDBRepository(LojaContext context) 
        { 
            _context = context; 
        } 
 
        public List<Cliente> ObterTodos() 
        { 
            return _context.Clientes.ToList(); 
        } 
 
        public Cliente? ObterPorId(int id) 
        { 
            return _context.Clientes.FirstOrDefault(c => c.Id == id); 
        } 
 
        public Cliente Adicionar(Cliente novoCliente) 
        { 
            _context.Clientes.Add(novoCliente); 
            _context.SaveChanges();  
            return novoCliente;  
        } 
 
        public Cliente? Atualizar(int id, Cliente clienteAtualizado) 
        { 
            // O serviço já carregou e alterou a entidade. O repositório apenas persiste.  
            _context.Clientes.Update(clienteAtualizado); 
            _context.SaveChanges(); 
            return clienteAtualizado; 
        } 
 
        public bool Remover(int id) 
        { 
            var clienteParaDeletar = ObterPorId(id); 
            if (clienteParaDeletar == null) return false; 
 
            _context.Clientes.Remove(clienteParaDeletar); 
            _context.SaveChanges(); 
            return true; 
        } 
    }
