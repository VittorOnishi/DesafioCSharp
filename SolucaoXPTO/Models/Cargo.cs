using System.ComponentModel.DataAnnotations;


namespace SolucaoXPTO.Models;

public class Cargo
{
    [Key]
    [Required]
    public int Id { get; set; }
    [Required(ErrorMessage = "O nome do cargo é obrigatório")]
    [StringLength(20)]
    public string Nome { get; set; }
}
