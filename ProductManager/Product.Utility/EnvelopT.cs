namespace Project.Utility;

public class Envelope<T>
{
    public T? Data { get; }

    public object? Error { get; }        

    public DateTime TimeGenerated { get; }

    protected internal Envelope(T? result, object? errorMessage)
    {
        Data = result;
        Error = errorMessage;            
        TimeGenerated = DateTime.UtcNow;
    }        
}
