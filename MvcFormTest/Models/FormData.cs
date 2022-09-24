using System.ComponentModel.DataAnnotations;

namespace MvcFormTest.Models;

public class FormData
{
    public string Title { get; set; }
    [Required]
    public string Name { get; set; }
    [Range(18, 21)]
    public int Age { get; set; }
}