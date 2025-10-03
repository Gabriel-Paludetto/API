using LojaApi.Entities; 
using LojaApi.Repositories; 
using Microsoft.AspNetCore.Mvc; 
 
namespace LojaApi.Controllers 
{ 
    [ApiController] // Indica que esta classe é um Controlador de API (sem Views) 
    [Route("api/[controller]")] // Define a rota base: 'api/Clientes' 
    public class ClientesController : ControllerBase // Herda de ControllerBase (padrão para APIs) 
    { 
        // ---------------------------------------------------- 
        // 1. GET - Ler Recursos 
        // ---------------------------------------------------- 
         
        // Endpoint: GET api/Clientes 
        [HttpGet]  
        public ActionResult<List<Cliente>> GetAll() 
        { 
            var clientes = ClienteRepository.GetAll(); 
            // 200 OK - Sucesso 
            return Ok(clientes);  
        } 
 
        // Endpoint: GET api/Clientes/{id} 
        // O {id} é um parâmetro de rota 
        [HttpGet("{id}")]  
        public ActionResult<Cliente> GetById(int id) 
        { 
            var cliente = ClienteRepository.GetById(id); 
 
            if (cliente == null) 
            { 
                // 404 Not Found - Recurso não encontrado 
                return NotFound(); 
            } 
 
            // 200 OK - Sucesso 
            return Ok(cliente);  
        } 
 
        // ---------------------------------------------------- 
        // 2. POST - Criar Recurso 
        // ----------------------------------------------------          
        // Endpoint: POST api/Clientes 
        [HttpPost]  
        public ActionResult<Cliente> Add(Cliente novoCliente)  
        { 
            // Validação simples (o ideal é fazer validações mais complexas) 
            if (string.IsNullOrWhiteSpace(novoCliente.Nome)) 
            { 
                // 400 Bad Request - Erro no cliente (dados inválidos) 
                return BadRequest("O nome do cliente é obrigatório.");  
            } 
 
            var clienteCriado = ClienteRepository.Add(novoCliente); 
 
            // 201 Created - Novo recurso criado com sucesso 
            // Retorna o recurso criado e a URL para acessá-lo (boa prática REST) 
            return CreatedAtAction(nameof(GetById), new { id = clienteCriado.Id }, clienteCriado);  
        } 
 
        // ---------------------------------------------------- 
        // 3. PUT - Atualizar/Substituir Recurso (Completo) 
        // ---------------------------------------------------- 
         
        // Endpoint: PUT api/Clientes/{id} 
        [HttpPut("{id}")] 
        public ActionResult<Cliente> Update(int id, Cliente clienteAtualizado) 
        { 
            // Validação de entrada 
            if (string.IsNullOrWhiteSpace(clienteAtualizado.Nome)) 
            { 
                 return BadRequest("O nome do cliente é obrigatório para atualização.");  
            } 
             
            var cliente = ClienteRepository.Update(id, clienteAtualizado); 
 
            if (cliente == null) 
            { 
                // 404 Not Found - Tentou atualizar algo que não existe 
                return NotFound(); 
            } 
 
            // 200 OK - Sucesso (Recurso substituído) 
            return Ok(cliente);  
        } 
 
        // ---------------------------------------------------- 
        // 4. DELETE - Excluir Recurso 
        // ---------------------------------------------------- 
         
        // Endpoint: DELETE api/Clientes/{id} 
        [HttpDelete("{id}")] 
        public IActionResult Delete(int id) // Usamos IActionResult pois não retornaremos um objeto Cliente 
        { 
            var sucesso = ClienteRepository.Delete(id); 
 
            if (!sucesso) 
            { 
                // 404 Not Found - Tentou deletar algo que não existe 
                return NotFound(); 
            } 
 
            // 204 No Content - Sucesso, mas não há corpo de resposta (padrão REST para DELETE) 
            return NoContent();  
        } 
    } 
} 