using System.ComponentModel.DataAnnotations;

namespace RestAPI_Controllers.Models;

public class CatModel
{
    [Key]
    public int CatId {get; set;}
    [MaxLength(64)]
    public string Breed {get; set;}
    [MaxLength(255)]
    public string Country {get; set;}
    [MaxLength(64)]
    public string BodyType {get; set;}
    [MaxLength(64)]
    public string Coat {get; set;}
    [MaxLength(64)]
    public string Pattern {get; set;}

}
