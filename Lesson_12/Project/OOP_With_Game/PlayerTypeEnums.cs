using System.ComponentModel;

public enum PlayerTypeEnums
{
    [Description("A player type that specializes in combat and physical strength, wielding heavy weapons and armor. Warriors often serve as tanks, drawing enemy attacks and protecting their allies.")]
    Warrior = 1,
    [Description("A player type that specializes in magic and spellcasting, using elemental or arcane magic to inflict damage on enemies or heal allies. Mages often have low health and rely on their spells to deal damage or stay alive.")]
    Mage,
    [Description("A player type that specializes in stealth and agility, using deception and quick attacks to take down enemies. Rogues often have high critical hit rates and can deal large amounts of damage quickly.")]
    Rogue,
    [Description("A player type that specializes in healing and supporting their allies, using divine powers or magic to protect and heal their party members. Priests often have low combat skills, but make up for it with their support abilities.")]
    Priest
}

public class PlayerClass
{
    public const string Warrior =   "░██╗░░░░░░░██╗░█████╗░██████╗░██████╗░██╗░█████╗░██████╗░\n" +
                                    "░██║░░██╗░░██║██╔══██╗██╔══██╗██╔══██╗██║██╔══██╗██╔══██╗\n" +
                                    "░╚██╗████╗██╔╝███████║██████╔╝██████╔╝██║██║░░██║██████╔╝\n" +
                                    "░░████╔═████║░██╔══██║██╔══██╗██╔══██╗██║██║░░██║██╔══██╗\n" +
                                    "░░╚██╔╝░╚██╔╝░██║░░██║██║░░██║██║░░██║██║╚█████╔╝██║░░██║\n" +
                                    "░░░╚═╝░░░╚═╝░░╚═╝░░╚═╝╚═╝░░╚═╝╚═╝░░╚═╝╚═╝░╚════╝░╚═╝░░╚═╝";
    public static string Mage =>    "███╗░░░███╗░█████╗░░██████╗░███████╗\n" +
                                    "████╗░████║██╔══██╗██╔════╝░██╔════╝\n" +
                                    "██╔████╔██║███████║██║░░██╗░█████╗░░\n" +
                                    "██║╚██╔╝██║██╔══██║██║░░╚██╗██╔══╝░░\n" +
                                    "██║░╚═╝░██║██║░░██║╚██████╔╝███████╗\n" +
                                    "╚═╝░░░░░╚═╝╚═╝░░╚═╝░╚═════╝░╚══════╝";
    
    public static string Rogue{
        get {
            return  "██████╗░░█████╗░░██████╗░██╗░░░██╗███████╗\n" +
                    "██╔══██╗██╔══██╗██╔════╝░██║░░░██║██╔════╝\n" +
                    "██████╔╝██║░░██║██║░░██╗░██║░░░██║█████╗░░\n" +
                    "██╔══██╗██║░░██║██║░░╚██╗██║░░░██║██╔══╝░░\n" +
                    "██║░░██║╚█████╔╝╚██████╔╝╚██████╔╝███████╗\n" +
                    "╚═╝░░╚═╝░╚════╝░░╚═════╝░░╚═════╝░╚══════╝";
        }

    }   

    public static string Priest =  " ██████╗░██████╗░██╗███████╗░██████╗████████╗\n" +
                                   " ██╔══██╗██╔══██╗██║██╔════╝██╔════╝╚══██╔══╝\n" +
                                   " ██████╔╝██████╔╝██║█████╗░░╚█████╗░░░░██║░░░\n" +
                                   " ██╔═══╝░██╔══██╗██║██╔══╝░░░╚═══██╗░░░██║░░░\n" +
                                   " ██║░░░░░██║░░██║██║███████╗██████╔╝░░░██║░░░\n" +
                                   " ╚═╝░░░░░╚═╝░░╚═╝╚═╝╚══════╝╚═════╝░░░░╚═╝░░░";

}