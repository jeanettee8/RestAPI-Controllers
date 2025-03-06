using System;

namespace RestAPI_Controllers.Models;

public class CatModelDTO
{
    public string Breed {get; set;} = string.Empty;
    public string Country {get; set;} = string.Empty;
    public string BodyType {get; set;} = string.Empty;
    public string Coat {get; set;} = string.Empty;
    public string Pattern {get; set;} = string.Empty;
    public CatModel MapToCatModel() {
        return new CatModel() {
            Breed=Breed,
            Country=Country,
            BodyType=BodyType,
            Coat=Coat,
            Pattern=Pattern,
        };
    }
}
