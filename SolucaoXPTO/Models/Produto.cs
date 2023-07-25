using System.ComponentModel.DataAnnotations;

namespace SolucaoXPTO.Models;

public class Produto
{
    [Key]
    [Required]
    public int Id { get; set; }

    [Required(ErrorMessage = "A Descricao do produto é obrigatória")]
    [StringLength(100)]
    public string Descricao { get; set; }

    List<PedidoDeCompra> Pedidos { get; set; }
}
