/*
The Abstract Factory Design Pattern is an extension of the Factory Method pattern. 
It provides an interface for creating families of related or dependent objects without specifying their concrete classes. 
This pattern is useful when a system should be independent of how its objects are created, composed, and represented, 
and it helps to enforce the consistency among objects.

Step-by-Step Implementation
Define Abstract Product Interfaces: These interfaces will be the base for all products that the factories will create.

Implement Concrete Products: These are the classes that implement the product interfaces.
Define Abstract Factory Interface: This interface will declare methods for creating abstract product objects.
Implement Concrete Factories: These classes will implement the abstract factory interface and create concrete product objects.

Client Code: The client will use the abstract factory to create product objects.

Example
Let's create an example where we have different types of GUI elements for different operating systems (Windows and Mac). 
Each OS will have its own factory to create its specific button and checkbox.
 */


// 1. Define Abstract Product Interfaces
public interface IButton
{
    void Paint();
}

public interface ICheckbox
{
    void Paint();
}


//2.Implement Concrete Products

// Windows Button
public class WindowsButton : IButton
{
    public void Paint()
    {
        Console.WriteLine("Rendering a button in Windows style.");
    }
}

// Windows Checkbox
public class WindowsCheckbox : ICheckbox
{
    public void Paint()
    {
        Console.WriteLine("Rendering a checkbox in Windows style.");
    }
}

// Mac Button
public class MacButton : IButton
{
    public void Paint()
    {
        Console.WriteLine("Rendering a button in Mac style.");
    }
}

// Mac Checkbox
public class MacCheckbox : ICheckbox
{
    public void Paint()
    {
        Console.WriteLine("Rendering a checkbox in Mac style.");
    }
}

//3. Define Abstract Factory Interface
public interface IGUIFactory
{
    IButton CreateButton();
    ICheckbox CreateCheckbox();
}


//4. Implement Concrete Factories
// Windows Factory
public class WindowsFactory : IGUIFactory
{
    public IButton CreateButton()
    {
        return new WindowsButton();
    }

    public ICheckbox CreateCheckbox()
    {
        return new WindowsCheckbox();
    }
}

// Mac Factory
public class MacFactory : IGUIFactory
{
    public IButton CreateButton()
    {
        return new MacButton();
    }

    public ICheckbox CreateCheckbox()
    {
        return new MacCheckbox();
    }
}

//5. Client Code

public class Application
{
    private readonly IButton _button;
    private readonly ICheckbox _checkbox;

    public Application(IGUIFactory factory)
    {
        _button = factory.CreateButton();
        _checkbox = factory.CreateCheckbox();
    }

    public void Paint()
    {
        _button.Paint();
        _checkbox.Paint();
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        // Change the factory type based on some configuration or runtime parameter
        IGUIFactory factory;

        string osType = "Windows"; // This could be read from a configuration file

        if (osType == "Windows")
        {
            factory = new WindowsFactory();
        }
        else
        {
            factory = new MacFactory();
        }

        var app = new Application(factory);
        app.Paint();
    }
}

