using System.ComponentModel.DataAnnotations;

namespace FastLocationAPI.Models;
public class Produto
{
    [Key]
    public int ProdutoId { get; set; }
    [StringLength(40)]
    public string? NfcId { get; set; }
    [StringLength(10)]
    public string? Codigo { get; set; }
    [Required]
    [StringLength(100)]
    public string? Nome { get; set; }
    [StringLength(300)]
    public string? Descricao { get; set; }
    public int Quantidade { get; set; }
    public DateTime DataCadastro { get; set; }
    public DateTime DataAtualizacao { get; set; }
    [StringLength(30)]
    public string? Localizacao { get; set; }
    [StringLength(100)]
    public string? Responsavel { get; set; }
    public bool Calibragem { get; set; }
    public bool Ativo { get; set; }
}
