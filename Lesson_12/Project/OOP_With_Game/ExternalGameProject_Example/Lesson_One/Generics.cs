using System.Collections;
using UnityEngine;

//C# Generics are a programming language feature that allows the production of reusable, type-safe code. 
//Generics enable the design of classes, interfaces, and methods that can function with any data type rather than being restricted to a single type.
//This enables the creation of more flexible and reusable code.
//https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/generics/
//Generics are most frequently used with collections and the methods that operate on them.
//Generics are so important in .NET that the C# compiler, the common language runtime (CLR), and the base class libraries (BCL) are all designed to support generics. 
//Generics are used extensively by C# compilers to provide type safety for collections.

public class GenericsTest{

    [SerializeField] private List<Character> characters;
    private List<string> names;
    private List<int> numbers;
    private List<Vector2> vectors;
    private ArrayList arrayList;
    Component comp = new Component();

    //This method is an example of a generic method. It can operate on Character objects, or any class that derives from Character. 
    //The type parameter T is specified in angle brackets before the return type of the method.
    //The type parameter T is used as the type of the parameter named item and also as the return type of the method.
    private List<T> FindAllCharacterByType<T>() where T : Character
    {
        List<T> characterList = new List<T>();
        foreach (Character character in characters)
        {
            if (character is T)
            {
                characterList.Add(character as T);
            }
        }
        return characterList;
    }

    private void ComponentOp()
    {
        var rigidbody = comp.GetComponent<Rigidbody2D>();

        rigidbody.transform.rotation = Quaternion.identity;

        Larger<string>("","");
    }

    private void TestFindCharacter()
    {
        List<NonPlayer> nonPlayers = FindAllCharacterByType<NonPlayer>();
        foreach (NonPlayer nonPlayer in nonPlayers)
        {
            nonPlayer.Voice();
        }

        List<Player> players = FindAllCharacterByType<Player>();
        foreach (Player player in players)
        {
            player.Voice();
        }
    }
    
    //Multiple type parameters generic method
    //The following example shows a generic method that has two type parameters.
    //The type parameters are used to declare the type of the parameters named first and second, and also as the return type of the method.
    //The method returns the larger of the two parameters.
    private T Larger<T>(T first, T second) where T : IComparable<T>
    {
        if (first.CompareTo(second) >= 0)
        {
            return first;
        }
        else
        {
            return second;
        }
    }

}