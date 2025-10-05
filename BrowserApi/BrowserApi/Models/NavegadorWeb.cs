using System.ComponentModel.DataAnnotations;

namespace BrowserApi.Models;

public class NavegadorWeb
{
    [Key]
    public long Id { get; set; }
    [Required(ErrorMessage = "O campo nome e obrigatorio!")]
    public string Nome { get; set; }
    public string VersaoAtual { get; set; }
    public string MotorRenderizacao { get; set; }
    public string BaseCodigo { get; set; }
    public string Fornecedor { get; set; }
}
