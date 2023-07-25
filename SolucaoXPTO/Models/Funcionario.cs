using System.ComponentModel.DataAnnotations;

namespace SolucaoXPTO.Models;

public class Funcionario
{
    [Key]
    [Required]
    public int Id { get; set; }
    [Required(ErrorMessage = "O nome do funcionario é obrigatório")]
    [StringLength(100)]
    public string Nome { get; set; }    
}
