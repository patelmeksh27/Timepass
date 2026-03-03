// using System.Runtime.InteropServices;

public interface IMessageService
{
    string GetMessage();
}

public class MessageService : IMessageService
{
    public string GetMessage()
    {
        return "Dependency Injection Working!";
    }
}