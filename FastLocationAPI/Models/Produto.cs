namespace FastLocationAPI.Models;
public class Produto
{
    public int ProdutoId { get; set; }
    public string? NfcId { get; set; }
    public string? Codigo { get; set; }
    public string? Nome { get; set; }
    public string? Descricao { get; set; }
    public int Quantidade { get; set; }
    public DateTime DataCadastro { get; set; }
    public DateTime DataAtualizacao { get; set; }
    public string? Localizacao { get; set; }
    public string? Responsavel { get; set; }
    public bool Calibragem { get; set; }
    public bool Ativo { get; set; }
}
