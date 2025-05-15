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

    public string CompanyName { get => companyName; set => companyName = value; }
    public string? Street { get => street; set => street = value; }
    public string? City { get => city; set => city = value; }
    public string? ZipCode { get => zipCode; set => zipCode = value; }
    
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