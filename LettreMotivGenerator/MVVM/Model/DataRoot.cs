namespace LettreMotivGenerator.MVVM.Model;

public class DataRoot
{
    private Myself _myself;
    private Company _company;

    public Myself Myself { get; set; }
    public Company Company { get; set; }

    public DataRoot()
    {
        Myself = new Myself();
        Company = new Company("", null ,null, null);
    }
}