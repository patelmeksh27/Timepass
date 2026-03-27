namespace Project.Utility;

public sealed class Envelope : Envelope<string>
{
    private Envelope(object? errorMessage) : base(null, errorMessage)
    {
    }

    public static Envelope<T> Ok<T>(T result)
    {
        return new Envelope<T>(result, null);
    }
    public static Envelope Ok()
    {
        return new Envelope(null);
    }

    public static Envelope ErrorMessage(object errorMessage)
    {
        return new Envelope(errorMessage);
    }
}
