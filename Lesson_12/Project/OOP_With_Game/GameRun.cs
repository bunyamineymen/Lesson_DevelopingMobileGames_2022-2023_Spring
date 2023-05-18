using System;
using System.Collections;
using System.Threading;

public class GameRun
{
    Player? character1;
    NonPlayer? bankCharacter;
    NonPlayer? villagerCharacter;

    public void Run()
    {
        Console.BackgroundColor = ConsoleColor.Black;
        Console.Clear();
        // Greetings to the world of OOP
        Console.WriteLine("Welcome to the game!");
        Loading();
        CreateNPC();
        //Character Creation Screen

        character1  = CharacterCreation() as Player;

        //Character Select Screen

        character1.playerType = CharacterSelection();


        Console.WriteLine("Your character's name is " + character1.Name + " and they are a " + Enum.GetName(typeof(PlayerTypeEnums), character1.playerType));

        Console.WriteLine("Press any key to start the game!");

        Console.ReadKey();

        Loading(15);

        Loading(loadingText: "Loading Game");

        // Game Loop
        GameLoop();


    }

    private void GameLoop(){
        while (true)
        {
            // Display the game menu
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("1. Play Game");
            Console.WriteLine("2. Exit Game");
            Console.WriteLine("Please select an option:");
            var option = Console.ReadLine();

            // Process the user's input
            if (option == "1")
            {
                // Start the game
                Loading(loadingText:"Starting the game...");
                //Add console loading animation
                character1?.Voice();
                bankCharacter?.Voice();
                villagerCharacter?.Voice();

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
            else if (option == "2")
            {
                // Exit the game
                Console.WriteLine("Exiting the game...");
                break;
            }
            else
            {
                // Invalid input
                Console.WriteLine("Invalid input. Please try again.");
            }

        }
    }
    private void Loading(int iterNumber = 10, int waitTimeMiliseconds = 100, string loadingText = "Loading..."){
        Console.WriteLine(loadingText);

        // Define the spinner characters to animate
        char[] spinnerChars = { '|', '/', '-', '\\' };
        
        // Simulate loading with spinner animation
        for (int i = 0; i < iterNumber; ++i)
        {
            Console.Write(spinnerChars[i % spinnerChars.Length]);
            Thread.Sleep(waitTimeMiliseconds); // pause for a short period to slow down animation
            Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop); // move the cursor back to overwrite the previous character
        }
         
    }
    private Character CharacterCreation(){
        Console.WriteLine("Please enter a name for your character:");
        var name = Console.ReadLine() ?? "Player1";
        //return Character.CharacterFactory.CreateCharacter(name,typeof(Player));
        return Character.CharacterFactory.CreateCharacter<Player>(name);
    }
    private PlayerTypeEnums CharacterSelection(){
        Console.WriteLine("Character Class Selection");
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine($"1. {nameof(PlayerTypeEnums.Warrior)} \n Description:{PlayerTypeEnums.Warrior.GetDescription()}");
        Console.WriteLine($"2. {nameof(PlayerTypeEnums.Mage)} \n Description:{PlayerTypeEnums.Mage.GetDescription()}");
        Console.WriteLine($"3. {nameof(PlayerTypeEnums.Rogue)} \n Description: {PlayerTypeEnums.Rogue.GetDescription()}");
        Console.WriteLine($"4. {nameof(PlayerTypeEnums.Priest)} \n Description: {PlayerTypeEnums.Priest.GetDescription()}");
        Console.ForegroundColor = ConsoleColor.White;
        
        Console.WriteLine("Please select a character class:");
        var input = Console.ReadLine();
        Console.Clear();
        // Convert the input into a PlayerTypeEnums
        //var playerType = Enum.Parse<PlayerTypeEnums>(input);
        //var playerType = (PlayerTypeEnums)Enum.Parse(typeof(PlayerTypeEnums), input);
        Enum.TryParse(input, out PlayerTypeEnums playerType);

        Console.WriteLine($"You have selected {playerType} as your character class.");

        
        switch (playerType)
        {
            case PlayerTypeEnums.Warrior:
                Console.WriteLine(PlayerClass.Warrior);
                break;
            case PlayerTypeEnums.Mage:
                Console.WriteLine(PlayerClass.Mage);
                break;
            case PlayerTypeEnums.Rogue:
                Console.WriteLine(PlayerClass.Rogue);
                break;
            case PlayerTypeEnums.Priest:
                Console.WriteLine(PlayerClass.Priest);
                break;
            default:
                Console.WriteLine("You have selected an invalid class");
                break;
        }

        return playerType;
    }
    private void CreateNPC(){

        bankCharacter = new("Banker");
        bankCharacter.Type = NPCTypeEnums.Bank;

        villagerCharacter = new NonPlayer("Villager");
        villagerCharacter.Type = NPCTypeEnums.Villager;

    }
}
