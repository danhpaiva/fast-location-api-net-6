using FastLocationAPI.Context;
using FastLocationAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FastLocationAPI.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProdutosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Produto>> Get()
        {
            var produtos = _context.Produtos.ToList();
            if (produtos is null)
            {
                return NotFound();
            }
            return produtos;
        }

        [HttpGet("{id:int}", Name = "ObterProduto")]
        public ActionResult<Produto> Get(int id)
        {
            var produto = _context.Produtos.FirstOrDefault(p => p.ProdutoId == id);
            if (produto is null)
            {
                return NotFound($"Produto com o id {id} não encontrado...");
            }
            return produto;
        }

        [HttpPost]
        public ActionResult Post(Produto produto)
        {
            if (produto is null)
                return BadRequest();

            _context.Produtos.Add(produto);
            _context.SaveChanges();

            return new CreatedAtRouteResult("ObterProduto",
                new { id = produto.ProdutoId }, produto);
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Produto produto)
        {
            if (id != produto.ProdutoId)
            {
                return BadRequest();
            }

            _context.Entry(produto).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(produto);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var produto = _context.Produtos.FirstOrDefault(p => p.ProdutoId == id);
            //var produto = _context.Produtos.Find(id);

            if (produto is null)
            {
                return NotFound($"Produto com o id {id} não localizado...");
            }
            _context.Produtos.Remove(produto);
            _context.SaveChanges();

            return Ok(produto);
        }

        [HttpGet("nfc/buscar/{nfcId}", Name = "ObterProdutoPorNfcId")]
        public ActionResult<Produto> GetProdutoPorPorNfcId(string nfcId)
        {
            var produto = _context.Produtos.FirstOrDefault(p => p.NfcId == nfcId);
            if (produto is null)
            {
                return NotFound($"Produto com a nfcId {nfcId} não encontrado...");
            }
            return produto;
        }

        [HttpPost("nfc/criar/{nfcId}", Name = "CriarProdutoPorNfcId")]
        public ActionResult PostNfc(Produto produto)
        {
            if (produto is null)
                return BadRequest();

            _context.Produtos.Add(produto);
            _context.SaveChanges();

            return new CreatedAtRouteResult("CriarProduto",
                new { nfcId = produto.NfcId }, produto);
        }

        [HttpPut("nfc/atualizar/{nfcId}", Name = "AtualizarProdutoPorNfcId")]
        public ActionResult PutNfc(string nfcId, Produto produto)
        {
            if (nfcId != produto.NfcId)
            {
                return BadRequest();
            }

            _context.Entry(produto).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(produto);
        }


        [HttpDelete("nfc/deletar/{nfcId}")]
        public ActionResult DeleteByNfc(string nfcId)
        {
            var produto = _context.Produtos.FirstOrDefault(p => p.NfcId == nfcId);
            //var produto = _context.Produtos.Find(id);

            if (produto is null)
            {
                return NotFound($"Produto com o NFC {nfcId} não localizado...");
            }
            _context.Produtos.Remove(produto);
            _context.SaveChanges();

            return Ok(produto);
        }

        [HttpGet("codigo/buscar/{codigo}", Name = "ObterProdutoPorCodigo")]
        public ActionResult<Produto> GetProdutoPorCodigo(string codigo)
        {
            var produto = _context.Produtos.FirstOrDefault(p => p.Codigo == codigo);
            if (produto is null)
            {
                return NotFound($"Produto com o código {codigo} não encontrado...");
            }
            return produto;
        }

        [HttpDelete("codigo/deletar/{codigo}")]
        public ActionResult DeleteByCode(string codigo)
        {
            var produto = _context.Produtos.FirstOrDefault(p => p.Codigo == codigo);
            //var produto = _context.Produtos.Find(id);

            if (produto is null)
            {
                return NotFound($"Produto com o NFC {codigo} não localizado...");
            }
            _context.Produtos.Remove(produto);
            _context.SaveChanges();

            return Ok(produto);
        }
    }
}
