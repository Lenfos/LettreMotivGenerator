namespace LettreMotivGenerator.MVVM.Model;

public class Company
{
    #region Attributes

    private string companyName = "";
    private string? street;
    private string? city;
    private string? zipCode;

    #endregion

    #region Properties

    public string CompanyName { get; set; }
    public string? Street { get; set; }
    public string? City { get; set; }
    public string? ZipCode { get; set; }
    
    #endregion

    public Company(string companyName, string? street, string? city, string? zipCode)
    {
        this.CompanyName = companyName;
        this.Street = street;
        if (city != null && zipCode != null)
        {
            this.City = city;
            this.ZipCode = zipCode;
        }
        
    }

    public override string ToString()
    {
        return $"{companyName}\n{(street != null ? $"{street}\n" : "")}{(city != null ? $"{city}, " : "")}{(zipCode != null ? $"{zipCode}" : "")}";
    }
}