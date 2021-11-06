namespace SafeboardWebApi.Services.Scanner
{
    public interface IScanner
    {
        string[] Scan(string directoryPath);
    }
}