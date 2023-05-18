public class NonPlayer : Character
{
    public NPCTypeEnums Type { get; set; }
    public NonPlayer(string name) : base(name)
    {

    }


    public override void Voice()
    {
       Console.WriteLine("Hello, my name is " + this.Name + " and I am a " + Enum.GetName(typeof(NPCTypeEnums), this.Type));
    }

}