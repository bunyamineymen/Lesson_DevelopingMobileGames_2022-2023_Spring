using System.Reflection;

public abstract class Character : ICharacter
{
    private string name = string.Empty;
    public int Health { get; private set; } = 100;
    public int Defense { get; set; } = 1;
    public int Strength { get; set; } = 10;

    protected Character(string name)
    {
        this.Name = name;
    }

    public void TakeDamage(int damage)
    {
        this.Health = Math.Max(this.Health - damage, 0);
    }

    public void Heal(int health)
    {
        this.Health = Math.Min(this.Health + health, 100);
    }

    public string Name
    {
        get { return this.name; }
        private set 
        { 
            this.name  = this.CheckName(value);
        }
    }
    
    public abstract void Voice();

    protected virtual string CheckName(string name){

        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Name cannot be null or empty");
        }

        return name;
    }

    /// <summary>
    /// The CharacterFactory class has a static method called CreateCharacter() that returns an object of the type of character requested by the client. 
    /// The client can request any type of character that inherits from the Character class by passing the character type as a generic parameter to the CreateCharacter() method.
    /// The method uses reflection to create an instance of the requested character type using the Activator.CreateInstance() method. 
    /// It then checks if the created instance is of the requested type and returns it if it is. If it’s not, it throws an exception.
    /// The where T : Character constraint on the generic parameter ensures that only types that inherit from the Character class can be used as a generic parameter.
    /// </summary>
    public class CharacterFactory
    {
        public static T CreateCharacter<T>(string name) where T : Character
        {
            try
            {
                var result = Activator.CreateInstance(typeof(T), name);
                if (result is T)
                {
                    return (T)result;
                }
                else
                {
                    throw new ArgumentException("Invalid type");
                }

            }
            catch (Exception e)
            {
                throw new Exception("Failed to create character", e);
            }
        }

        public static Character CreateCharacter(string name, Type type)
        {
            switch (type.Name)
            {
                case "Player":
                    return new Player(name);
                case "NonPlayer":
                    return new NonPlayer(name);
                default:
                    throw new ArgumentException("Invalid type");
            }
        }

    }

}



