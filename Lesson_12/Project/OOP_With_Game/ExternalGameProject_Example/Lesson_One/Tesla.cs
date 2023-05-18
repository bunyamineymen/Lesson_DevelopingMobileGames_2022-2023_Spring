//In OOP, classes are like a blueprint that defines variables, properties and methods common to all objects of a certain type. 
//An object is an instance of a class.

//Class Car defines what a car is class 
public class Car { 
    // Properties 
    string model; 
    string color; 
    int speed;

    // Constructor 
    public Car(string model, string color, int speed) { 
        this.model = model; 
        this.color = color; 
        this.speed = speed; 
    }

    // Methods
    public void start() { 
        Console.WriteLine(model + " is starting."); 
    }

    public void accelerate() { 
        speed += 10;
        Console.WriteLine(model + " is accelerating."); 
    }

    public void stop() { 
        speed = 0;
        Console.WriteLine(model + " is stopping."); 
    } 
}

public class ProgramTest { 
    public static void Main(string[] args) { 
        // Object Tesla is an instance of Car 
        Car tesla = new Car("Tesla Model S", "red", 200);
        // Calling methods of Tesla
        tesla.start();
        tesla.accelerate();
        tesla.stop();
    } 
}