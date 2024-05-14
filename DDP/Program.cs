using DecoratorDesignPattern.DDP;

//Step 1 : Main interface  
public interface IComponentPasswordReader
{
    string Read();
}


//Step 2 : Interface implementation
public class ComponentPasswordReader : IComponentPasswordReader
{
    public string Read()
    {
        return "This is a secure password !";
    }
}


//Step 3 : We need to have the date in persian calendar so we create a new component for that
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


//Step 4 : Check output result
public class CheckResult
{
    static void Main(string[] args)
    {
        IComponentPasswordReader componentPasswordReader = new ComponentPasswordReader();
        IComponentPasswordReader componentHashedPasswordReaderDecorator = new ComponentHashedPasswordReaderDecorator(componentPasswordReader);
        Console.WriteLine(componentHashedPasswordReaderDecorator.Read());
    }
}
