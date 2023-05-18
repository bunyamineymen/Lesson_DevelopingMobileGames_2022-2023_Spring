// create an interface
interface IWeapon
{
    // interface property
    int Ammo { get; set; }

    // interface methods
    void Shoot();
    void Reload();
}

// create a class that implements the interface
class Pistol : IWeapon
{
    // constructor
    public Pistol(int ammo)
    {
        Ammo = ammo;
    }

    // implement the interface property
    public int Ammo { get; set; }

    // implement the interface methods
    public void Shoot()
    {
        Console.WriteLine("Pistol shoots");
        Ammo--;
    }

    public void Reload()
    {
        Console.WriteLine("Pistol reloads");
        Ammo = 10;
    }
}

// create another class that implements the interface
class Rifle : IWeapon
{
    // constructor
    public Rifle(int ammo)
    {
        Ammo = ammo;
    }

    // implement the interface property
    public int Ammo { get; set; }

    // implement the interface methods
    public void Shoot()
    {
        Console.WriteLine("Rifle shoots");
        Ammo--;
    }

    public void Reload()
    {
        Console.WriteLine("Rifle reloads");
        Ammo = 30;
    }
}

// create another class that implements the interface
class Shotgun : IWeapon
{
    // constructor
    public Shotgun(int ammo)
    {
        Ammo = ammo;
    }

    // implement the interface property
    public int Ammo { get; set; }

    // implement the interface methods
    public void Shoot()
    {
        Console.WriteLine("Shotgun shoots");
        Ammo--;
    }

    public void Reload()
    {
        Console.WriteLine("Shotgun reloads");
        Ammo = 8;
    }
}

// test the code
class Program3
{
    static void Main(string[] args)
    {
        // create objects of classes that implement the interface
        IWeapon p = new Pistol(10);
        IWeapon r = new Rifle(30);
        IWeapon s = new Shotgun(8);

        // call the interface methods and property
        p.Shoot();
        p.Reload();
        Console.WriteLine(p.Ammo);

        r.Shoot();
        r.Reload();
        Console.WriteLine(r.Ammo);

        s.Shoot();
        s.Reload();
        Console.WriteLine(s.Ammo);
        
    }
}

/*
Output:


Pistol shoots
Pistol reloads
10

Rifle shoots
Rifle reloads
30

Shotgun shoots
Shotgun reloads
8

*/