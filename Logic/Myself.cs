namespace Logic;

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

    public string LastName { get; set; }
    public string FirstName { get; set; }
    public string Email { get; set; }
    public string Street { get; set; }
    public string City { get; set; }
    public string ZipCode { get; set; }

    #endregion


    public override string ToString()
    {
        return $"{firstName} {lastName.ToUpper()} \n{street} \n{city}, {zipCode} \n{email}";
    }
}