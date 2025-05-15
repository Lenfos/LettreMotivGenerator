namespace LettreMotivGenerator.MVVM.Model;

public class Myself
{
    #region Attributes

    private string lastName = "";
    private string firstName = "";
    private string email = "";
    private string street = "";
    private string city = "";
    private string zipCode = "";

    #endregion

    #region Properties

    public string LastName { get => lastName; set => lastName = value; }
    public string FirstName { get => firstName; set => firstName = value; }
    public string Email { get => email; set => email = value; }
    public string Street { get => street; set => street = value; }
    public string City { get => city; set => city = value; }
    public string ZipCode { get => zipCode; set => zipCode = value; }

    #endregion


    public override string ToString()
    {
        return $"{firstName} {lastName.ToUpper()} \n{street} \n{city}, {zipCode} \n{email}";
    }
}