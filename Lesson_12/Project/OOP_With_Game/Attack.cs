public class Attack<T> where T : Character, ICharacter
{
    public T Attacker { get; set; }
    public T Target { get; set; }

    public Attack(T attacker, T target)
    {
        this.Attacker = attacker;
        this.Target = target;
    }
    
    /*  
        ***** METHOD OVERLOADING *****
        * Overloading is when you have multiple methods in the same scope, with the same name but different signatures.
        * This method is used to calculate the damage dealt by the attacker to the target.
        * The damage is calculated by subtracting the target's defense from the attacker's strength.
        * If the damage is less than 0, the damage is set to 0.
        * The target's health is then reduced by the damage.
    */
    public int AttackCharacter(int baseDamage)
    {
        // Calculate the actual damage based on the attacker's strength, the target's defense, and other factors
        var actualDamage = Math.Max(baseDamage - Target.Defense, 0);
        Target.TakeDamage(actualDamage);
        return actualDamage;
    }

    public int AttackCharacter()
    {
        // Calculate the actual damage based on the attacker's strength, the target's defense, and other factors
        var actualDamage = Math.Max(Convert.ToInt32((Attacker.Strength - (Target.Defense * 0.75))), 0);
        Target.TakeDamage(actualDamage);
        return actualDamage;
    }

}