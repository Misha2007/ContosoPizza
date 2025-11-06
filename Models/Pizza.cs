using System.ComponentModel.DataAnnotations;       
using System.ComponentModel.DataAnnotations.Schema;  


namespace ContosoPizza.Models;

public class Pizza
{
    [Key]
    [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
    public int? Id { get; set; }
    [Required] 
    public string? Name { get; set; }
    [Required]
    public bool IsGlutenFree { get; set; }
}