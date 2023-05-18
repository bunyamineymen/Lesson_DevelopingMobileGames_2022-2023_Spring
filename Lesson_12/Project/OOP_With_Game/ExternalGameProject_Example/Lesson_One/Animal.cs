//? Can I override a virtual method without using the override keyword?

//No, you cannot override a virtual method without using the override keyword. 
//The override keyword is used to indicate that you are intentionally overriding a virtual method from the base class and provide a new implementation in the derived class.
//If you omit the override keyword, you will either hide the base class method (if the signatures are the same) or overload it (if the signatures are different). This can lead to unexpected behavior and errors.

//In this example, the Dog class overloads the MakeSound method from the Animal class by adding a string parameter. 
//However, this hides the base class method, which means that you cannot call it on an object of type Dog. 
//This can lead to confusion and errors.
//To avoid this problem, you should always use the override keyword when overriding a virtual method, and use the new keyword when hiding a base class method. 
//This will make your intention clear and help you catch any errors if the base class method changes or is removed.
public class Animal
{
    public virtual void MakeSound()
    {
        Console.WriteLine("Animal makes sound.");
    }
}

public class Dog : Animal
{
    public void MakeSound(string sound) // overloading the base class method
    {
        Console.WriteLine("Dog makes " + sound + ".");
    }
    public override void MakeSound() // overriding the base class method
    {
        Console.WriteLine("Dog barks.");
    }

}

public class Cat : Animal
{
    public override void MakeSound()
    {
        Console.WriteLine("Cat meows.");
    }
}

// test the code
class Program4
{
    static void Main(string[] args)
    {
        Animal a = new Dog();
        a.MakeSound(); // prints "Dog barks."
        //a.MakeSound("woof"); // error: no such method in Animal class

        Dog d = new Dog();
        d.MakeSound(); // prints Animal makes sound.
        d.MakeSound("woof"); // prints "Dog makes woof."
    
    }
}

/* 
Output:
    Animal makes sound.
    Dog barks.
    Dog makes woof.
*/

//---------------------------------------------------------------------------------------------------------------------------------------------------------------------
//? What is the difference between virtual and abstract methods?
//The difference between virtual and abstract methods is that virtual methods have an implementation in the base class and can be overridden in the derived class, while abstract methods do not have an implementation in the base class and must be overridden in the derived class.

//In this example, the Animal class has an abstract method called MakeSound that has no implementation and a virtual method called Eat that has a default implementation. 
//The Dog class inherits from the Animal class and overrides both methods to provide its own implementation. 
//This way, when you invoke the MakeSound or Eat method on an object of type Dog, you get the specific behavior of a dog.
public abstract class Animal2
{
    public abstract void MakeSound(); // no implementation, must be overridden

    public virtual void Eat() // default implementation, can be overridden
    {
        Console.WriteLine("Animal eats food.");
    }
}

public class Dog2 : Animal2
{
    public override void MakeSound() // must override the abstract method
    {
        Console.WriteLine("Dog barks.");
    }

    public override void Eat() // can override the virtual method
    {
        Console.WriteLine("Dog eats bone.");
    }
}

public class Cat2 : Animal2
{
    public override void MakeSound() // must override the abstract method
    {
        Console.WriteLine("Cat meows.");
    }
}

// test the code
class Program6
{
    static void Main(string[] args)
    {
        Animal2 a = new Dog2();
        a.MakeSound(); // prints "Dog barks."
        a.Eat(); // prints "Dog eats bone."

        Animal2 b = new Cat2();
        b.MakeSound(); // prints "Cat meows."
        b.Eat(); // prints "Animal eats food."
    }

}