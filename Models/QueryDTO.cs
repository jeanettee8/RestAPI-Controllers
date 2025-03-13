using Microsoft.EntityFrameworkCore;

namespace RestAPI_Controllers.Models;

public class QueryDTO
{
    public string? Breed { get; set; }
    public string? Country { get; set; }
    public string? BodyType { get; set; }
    public string? Coat { get; set; }
    public string? Pattern { get; set; }
public IQueryable<CatModel>QueryBuilder(IQueryable<CatModel> Cats) {
    var query = Cats.AsQueryable();
    if (!string.IsNullOrWhiteSpace(Breed)) query = query.Where(cat=>string.Equals(cat.Breed,Breed,StringComparison.InvariantCultureIgnoreCase));
    if (!string.IsNullOrWhiteSpace(Country)) query = query.Where(cat=>string.Equals(cat.Country,Country,StringComparison.InvariantCultureIgnoreCase));
    if (!string.IsNullOrWhiteSpace(BodyType)) query = query.Where(cat=>string.Equals(cat.BodyType, BodyType, StringComparison.InvariantCultureIgnoreCase));
    if (!string.IsNullOrWhiteSpace(Coat)) query = query.Where(cat=>string.Equals(cat.Coat,Coat,StringComparison.InvariantCultureIgnoreCase));
    if (!string.IsNullOrWhiteSpace(Pattern)) query = query.Where(cat=>string.Equals(cat.Pattern, Pattern,StringComparison.InvariantCultureIgnoreCase));
    return query;
}
    
}