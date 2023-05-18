//The difference between static and dynamic polymorphism is that static polymorphism is resolved at compile time, while dynamic polymorphism is resolved at run time. 
//Static polymorphism means that the compiler knows which method to call based on the method signature and the type of the object at compile time. 
//Dynamic polymorphism means that the compiler does not know which method to call until the program is running and the type of the object is determined. 
//For example, in C#, static polymorphism is achieved using method overloading and operator overloading, whereas dynamic polymorphism is achieved using method overriding. 
//Method overloading means that you can have multiple methods with the same name but different parameters in the same class. Operator overloading means that you can redefine the behavior of an operator for a custom class. 
//Method overriding means that you can redefine the behavior of a method inherited from a base class in a derived class.


// Static polymorphism using method overloading
class Calculator
{
    public int Add(int x, int y) // a method that adds two integers
    {
        return x + y;
    }

    public double Add(double x, double y) // a method that adds two doubles
    {
        return x + y;
    }
}

// Static polymorphism using operator overloading
class Complex
{
    public double Real { get; set; } // a property that stores the real part of a complex number
    public double Imaginary { get; set; } // a property that stores the imaginary part of a complex number

    public Complex(double real, double imaginary) // a constructor that initializes a complex number
    {
        Real = real;
        Imaginary = imaginary;
    }
    public static Complex operator +(Complex c1, Complex c2) // an operator that adds two complex numbers
    {
        return new Complex(c1.Real + c2.Real, c1.Imaginary + c2.Imaginary);
    }

    public override string ToString() // a method that returns a string representation of a complex number
    {
        return $"{Real} + {Imaginary}i";
    }

    public static void Main()
    {
        // Static polymorphism using method overloading
        Calculator calculator = new Calculator();
        int sum1 = calculator.Add(1, 2);
        double sum2 = calculator.Add(1.0, 2.0);

        // Static polymorphism using operator overloading
        Complex c1 = new Complex(1.0, 2.0);
        Complex c2 = new Complex(3.0, 4.0);
        Complex sum3 = c1 + c2;
        Console.WriteLine(sum3); // output: 4 + 6i
    }
}

// Dynamic polymorphism using method overriding, it is runtime polymorphism.
class Animall
{
    public virtual void MakeSound() // a virtual method that can be overridden in derived classes
    {
        Console.WriteLine("Animal makes sound");
    }
}

class Dogg : Animall
{
    public override void MakeSound() // an override method that redefines the behavior of the base class method
    {
        Console.WriteLine("Dog barks");
    }
}

//In this example, the Calculator class uses static polymorphism by overloading the Add method with different parameters. 
//The Complex class uses static polymorphism by overloading the + operator to add two complex numbers. 
//The Animal and Dog classes use dynamic polymorphism by overriding the MakeSound method to provide different sounds for different animals.