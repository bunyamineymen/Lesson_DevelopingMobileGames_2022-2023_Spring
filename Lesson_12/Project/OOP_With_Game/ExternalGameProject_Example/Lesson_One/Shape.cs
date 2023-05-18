//? Can i use same time interface and abstract class together ?


public interface IShape
{
    double Area(); // a contract for calculating the area of a shape
}

public abstract class Shape : IShape // an abstract class that implements the interface
{
    public int numberofSides { get; set; }

    public virtual double Area() // a virtual method that provides a default implementation
    {
        return 0;
    }
}

public class Circle : Shape // a concrete class that inherits from the abstract class
{
    private double _radius;
    public Circle(double radius)
    {
        _radius = radius;
    }
    public override double Area() // an override method that provides a specific implementation
    {
        return Math.PI * _radius * _radius;
    }
}