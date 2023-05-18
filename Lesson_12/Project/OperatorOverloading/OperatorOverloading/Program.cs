namespace OperatorOverloading;

public class Program
{

    /*
        Hellooo, this lesson explains what is reference type and value type and how to overloading operators in C#. 

        In C#, there are two main types of data types: value types and reference types.

        Value types directly contain their data, and when you pass a value type to a method, a copy of the value is passed, so changes made to the value within the method do not affect the original value outside of it. 
        Examples of value types include: int, float, char, bool, struct, etc.
        Reference types, on the other hand, store a reference to the memory location where the data is stored, instead of the data itself. 
        When you pass a reference type to a method, it is passed by reference, which means that changes made to the value within the method will affect the original value outside of it. 
        Examples of reference types include: class, string, array, object, delegate, etc.

        What's mean Overloading ?

        Overloading in programming refers to the practice of creating multiple functions or methods with the same name but different parameters in the same scope. 
        This allows you to perform different actions based on the number or types of parameters passed to the function, providing more flexibility and improved readability. 
        It enables you to write more concise and maintainable code by reducing the number of functions you have to create and manage. Overloading is a commonly used feature in many programming languages, including C#, Java, and Python, among others.

    */


    static void Main(string[] args)
    {

        /*
            This bottom fuction purpose is to explain fundamental operator in C#.
        */
        
        SampleOperators();

        /*
            This bottom fuction purpose
            difference between value type and reference type(beffore overloading operators)
            SampleBeforeOverloadingPoint Function Output:
                Value of Number (before): 10
                Value of Number (after): 10
                Value of Point (before): 10, 20
                Value of Point (after): 30, 40
            As you can see, the value of the number variable remains unchanged after a call to the ChangeValue method, because number is a value type.
            On the other hand, the values of the point reference type are changed after a call to the ChangeReference method, because the method changes the instance of the Point class referenced by point.
        */
        
        SampleBeforeOverloadingPoint();

        /*
            This bottom fuction purpose is to explain how to overloading operators in C#.
            SampleAfterOverloadingPoint Function Output:
                Two Point Sum= (10, 10) + (20, 20) = (30, 30)
                Two Point Equal= (10, 10) == (10, 10) = True
                Two Point Equal= (10, 10) == (20, 20) = False
                p4 is true and greater than zero
            As you can see, after overriding some operators to the class type, which is a reference type, we can do the equality of 2 points and addition results.
        */
        SampleAfterOverloadingPoint();
    }

    static void SampleOperators(){

        /* Some examples of operator overloading 
            + - * /
            == != > < >= <=
            && || !  ?? ?
            += -= *= /=
            TRUE FALSE
        */

        // Example some operators are not overloading
        // Actually int type predefine in C# and it has already overloading + operator, so we just use it.
        int number1 = 1;
        int number2 = 2;

        int sumNumber = number1 + number2;
        int divideNumber = number1 / number2;
        int multiplyNumber = number1 * number2;
        int subtractNumber = number1 - number2;

        var equal = number1 == number2;
        var notEqual = number1 != number2;
        var greaterThan = number1 > number2;
        var lessThan = number1 < number2;
        var greaterThanOrEqual = number1 >= number2;
        var lessThanOrEqual = number1 <= number2;

        if(equal){
           // do something
        }
    }

    static void SampleBeforeOverloadingPoint(){
         // Declaring a value type variable
        int number = 10;
        Console.WriteLine("Value of Number (before): " + number);
        
        // Calling a method that changes the value of the variable
        ChangeValue(number);
        Console.WriteLine("Value of Number (after): " + number);

        // Declaring a reference type variable
        BeforeOverloadingPoint point = new BeforeOverloadingPoint (10, 20);
        Console.WriteLine("Value of Point (before): " + point.X + ", " + point.Y);

        // Calling a method that changes the value of the reference type
        ChangeReference(point);
        Console.WriteLine("Value of Point (after): " + point.X + ", " + point.Y);

        BeforeOverloadingPoint point2 = new BeforeOverloadingPoint (40, 15);

        var newPoint = new BeforeOverloadingPoint(point.X+ point2.X, point.Y + point2.Y);
        //var newPoint = point + point2;
        Console.WriteLine("Value of Point (after): " + newPoint.X + ", " + newPoint.Y);


    }

    static void ChangeValue(int value)
    {
        value = 20;
    }

    static void ChangeReference(BeforeOverloadingPoint reference)
    {
        reference.X = 30;
        reference.Y = 40;
    }

    static void SampleAfterOverloadingPoint()
    {
        // Create a new instance of the Point class
        AfterOverloadingPoint p1 = new AfterOverloadingPoint(10, 10);

        // Create a new instance of the Point class
        AfterOverloadingPoint p2 = new AfterOverloadingPoint(20, 20);

        // Add the two points together
        AfterOverloadingPoint p3 = p1 + p2;

        // Display the results
        Console.WriteLine($"Two Point Sum= ({p1.X}, {p1.Y}) + ({p2.X}, {p2.Y}) = ({p3.X}, {p3.Y})");

        AfterOverloadingPoint p4 = new AfterOverloadingPoint(10, 10);

        // Check if the two points are equal
        /*
         return false if we didn't overload the == operator (classes are reference types)
         Referace type means that the two variables point to the same object in memory.
        */
        Console.WriteLine($"Two Point Equal= ({p1.X}, {p1.Y}) == ({p4.X}, {p4.Y}) = {p1 == p4}"); 
        Console.WriteLine($"Two Point Equal= ({p1.X}, {p1.Y}) == ({p2.X}, {p2.Y}) = {p1 == p2}"); 


        if(p4) // check true
        {
            Console.WriteLine("p4 is true and greater than zero");
        }
        else
        {
            Console.WriteLine("p4 is false and NOT greater than zero");
        }

        Console.ReadLine();
    }

}