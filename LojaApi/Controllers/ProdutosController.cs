using LojaApi.Entities; 
using LojaApi.Repositories; 
using Microsoft.AspNetCore.Mvc;

namespace LojaApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutosController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<Produto>> GetAll()
        {
            var produto = ProdutoRepository.GetAll();
            return Ok(produto);
        }

        [HttpGet("{id}")]
        public ActionResult<Produto> GetById(int id)
        {
            var produto = ProdutoRepository.GetById(id);
            if (produto == null)
            {
                return NotFound();
            }
            return Ok(produto);
        }

        [HttpPost]
        public ActionResult<Produto> Add(Produto novoProduto)
        {
            if (string.IsNullOrWhiteSpace(novoProduto.Descricao))
            {
                return BadRequest("A descrição do produto é obrigatório.");
            }

            if (novoProduto.Valor <= 0)
            {
                return BadRequest("O valor do produto é obrigatório.");
            }

            if (novoProduto.Estoque <= 0)
            {
                return BadRequest("O estoque do produto é obrigatório.");
            }

            var produtoCriado = ProdutoRepository.Add(novoProduto);

            return CreatedAtAction(nameof(GetById), new { id = produtoCriado.Id }, produtoCriado);
        }

        [HttpPut("{id}")]
        public ActionResult<Produto> Update(int id, Produto produtoAtualizado)
        {
            if (string.IsNullOrWhiteSpace(produtoAtualizado.Descricao))
            {
                return BadRequest("A descrição do produto é obrigatório para atualização.");
            }

            var produto = ProdutoRepository.Update(id, produtoAtualizado);

            if (produto == null)
            {
                return NotFound();
            }

            return Ok(produto);
        } 
        
        [HttpDelete("{id}")] 
        public IActionResult Delete(int id)
        { 
            var sucesso = ProdutoRepository.Delete(id); 

            if (!sucesso) 
            { 
                return NotFound(); 
            } 

            return NoContent();  
        }
    }
}