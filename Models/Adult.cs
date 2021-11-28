using System.ComponentModel.DataAnnotations;

namespace Assigment3WebApiDatabase.Models {
public class Adult : Person {
    [Required]
    public Job JobTitle { get; set; }
}
}