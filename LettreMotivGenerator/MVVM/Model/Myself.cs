namespace LettreMotivGenerator.MVVM.Model;

public class Myself
{
    #region Attributes

    private string lastName = "Vanhove";
    private string firstName = "Pierre";
    private string email = "vanhove.pierre@proton.me";
    private string street = "87 Avenue Waldeck Rochet";
    private string city = "Saint Vallier";
    private string zipCode = "71230";

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