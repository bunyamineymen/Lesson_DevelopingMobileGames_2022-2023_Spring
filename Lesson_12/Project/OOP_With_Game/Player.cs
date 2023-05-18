public class Player : Character
{
    public int Level { get; set; } = 1;
    public PlayerTypeEnums playerType { get; set; }
    // Add any enemy-specific properties or methods here
    public Player(string name) : base(name)
    {
    }

    public override void Voice()
    {
        Console.WriteLine("Hello, my name is " + this.Name + " and I am a " + Enum.GetName(typeof(PlayerTypeEnums), this.playerType));
    }

    protected override string CheckName(string name)
    {
        base.CheckName(name);

        if (name.Length < 6)
        {
            throw new ArgumentException("Name must be at least 6 characters long");
        }
        
        if (name.Length > 20)
        {
            throw new ArgumentException("Name must be at most 20 characters long");
        }

        if (!name.All(char.IsLetter))
        {
            throw new ArgumentException("Name must contain only letters");
        }

        return name;
    }


}