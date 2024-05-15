using DecoratorDesignPattern.DDP;


public interface IComponentPasswordReader
{
    string Read();
}


public class ComponentPasswordReader : IComponentPasswordReader
{
    public string Read()
    {
        return "This is a secure password !";
    }
}


public class ComponentHashedPasswordReaderDecorator : IComponentPasswordReader
{
    private readonly IComponentPasswordReader _componentPasswordReader;
    public ComponentHashedPasswordReaderDecorator(IComponentPasswordReader componentPasswordReader)
    {
        _componentPasswordReader = componentPasswordReader;
    }
    public string Read()
    {
        return PasswordManager.HashUserPassword(_componentPasswordReader.Read());
    }
}


public class CheckResult
{
    static void Main(string[] args)
    {
        IComponentPasswordReader componentPasswordReader = new ComponentPasswordReader();
        IComponentPasswordReader componentHashedPasswordReaderDecorator = new ComponentHashedPasswordReaderDecorator(componentPasswordReader);
        Console.WriteLine(componentHashedPasswordReaderDecorator.Read());
    }
}
