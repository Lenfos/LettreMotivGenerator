namespace LettreMotivGenerator.MVVM.Model;

public class DataRoot
{
    private Myself _myself;
    private Company _company;
    private string _filePath;
    private string _text;

    public Myself Myself { get => _myself; set => _myself = value; }
    public Company Company { get => _company; set => _company = value; }
    public string FilePath { get => _filePath; set => _filePath = value; }
    public string Text { get => _text; set => _text = value; }

    public DataRoot()
    {
        Myself = new Myself();
        Company = new Company("", null ,null, null);
        FilePath = "";
        Text = "";
    }
}