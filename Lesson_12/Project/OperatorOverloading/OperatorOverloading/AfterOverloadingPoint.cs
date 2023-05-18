
using System.Numerics;

public class AfterOverloadingPoint : IAdditionOperators<AfterOverloadingPoint, AfterOverloadingPoint, AfterOverloadingPoint>, 
                                        IEqualityOperators<AfterOverloadingPoint, AfterOverloadingPoint, bool>
{
    public int X { get; set; }
    public int Y { get; set; }

    public AfterOverloadingPoint(int x, int y)
    {
        X = x;
        Y = y; 
    }

    //The reason functions are static is that we don't need to create an instance of the class to use this method.

    /*
        The + operator is used to add two numbers together. 
        In this case, we are adding two points together. 
        The + operator is overloaded to add the X and Y values of the two points together.
    */
    
    public static AfterOverloadingPoint operator +(AfterOverloadingPoint p1, AfterOverloadingPoint p2)
    {
        return new AfterOverloadingPoint(p1.X + p2.X, p1.Y + p2.Y);
    }

    /*
        Some operators are bidirectional. For example, the == operator checks that two objects are equal, while the != operator checks that two objects are not equal. 
        Therefore, to redefine the == operator, you have to redefine the != operator.
    */
    public static bool operator ==(AfterOverloadingPoint? p1, AfterOverloadingPoint? p2)
    {
        if (p1 is null || p2 is null)
        {
            return false;
        }
        return p1.X == p2.X && p1.Y == p2.Y;
        
    }

    public static bool operator !=(AfterOverloadingPoint? p1, AfterOverloadingPoint? p2)
    {
        if (p1 is null || p2 is null)
        {
            return false;
        }

        return p1.X != p2.X || p1.Y != p2.Y;
        //return !(p1.X == p2.X && p1.Y == p2.Y); // same as above

    }

    /* We can also overload true and false operator, but we need to it's not enough to do one, we have to do both. 
    Because if we only overload true operator, then we can't use false operator. These are pair operators
    */
    public static bool operator true(AfterOverloadingPoint p1) => p1.X > 0 && p1.Y > 0;

    public static bool operator false(AfterOverloadingPoint p1) => p1.X < 0 && p1.Y <= 0;

    public override bool Equals(object? obj)
    {
        return base.Equals(obj);
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}

