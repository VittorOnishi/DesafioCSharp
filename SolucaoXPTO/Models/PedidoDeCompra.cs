using System.ComponentModel.DataAnnotations;

namespace SolucaoXPTO.Models;

public class PedidoDeCompra
{
    [Key]
    [Required]
    public int Id { get; set; }
    [Required(ErrorMessage = "O numero do pedido é obrigatório")]
    [StringLength(20)]
    public string Numero { get; set; }
    [Required(ErrorMessage = "A quantidade de produtos é obrigatória")]
    public int QtdeProdutos { get; set;}
    List<Produto> Produtos { get; set; }
    Funcionario Funcionario { get; set; }   

}
