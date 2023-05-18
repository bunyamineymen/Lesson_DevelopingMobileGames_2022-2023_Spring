/*
    Reflection in C# is the process of collecting information on its features and operating on itself. The collecting information includes the properties, type, events, and methods of an object; reflection is useful in finding all types of assemblies.

    Reflection allows you to inspect and manipulate classes, constructors, methods, and fields at run time. You can use reflection to dynamically create an instance of a type, bind the type to an existing object, or get the type from an existing object and invoke its methods or access its fields and properties.

    Reflection provides objects (of type Type) that describe assemblies, modules, and types. You can use the System.Reflection namespace to perform reflection. The Type class is the primary way to access the metadata by using methods and properties.
*/

using System.Reflection;
using UnityEngine;
//Here are some basic examples of using reflection in C#:
public class ReflectionLesson
{
    public void Test(){
        //To get the type of a variable, you can use the GetType () method inherited by all types from the Object base class
        int i = 42;
        Type typeInt = i.GetType ();
        Console.WriteLine (typeInt); // Output: System.Int32

        //To get the assembly of a type, you can use the Assembly property of the Type class.
        Assembly info = typeof(int).Assembly;
        Console.WriteLine (info); // Output: System.Private.CoreLib, Version=7.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e

    }

    /*
        To dynamically load and use types from an external assembly, you can use the Assembly.LoadFrom () method to load the assembly into the current application domain. 
        Then you can use the GetTypes () method to get an array of Type objects that represent the types defined in the assembly. 
        You can use the Activator.CreateInstance () method to create an instance of a type, or the GetMethod () and Invoke () methods to call a method of a type.
    */
    public void GameModExample(){

        // Load an external assembly
        Assembly assembly = Assembly.LoadFrom("MyGameMod.dll");

        // Get the types defined in the assembly
        Type[] types = assembly.GetTypes();

        // Loop through the types
        foreach (Type type in types)
        {
            // Check if the type is a subclass of MonoBehaviour
            if (type.IsSubclassOf(typeof(MonoBehaviour)))
            {
                // Create an instance of the type
                var mod = Activator.CreateInstance(type);

                // Add the instance as a component to a game object
                GameObject go = new GameObject(type.Name);
                go.AddComponent(mod.GetType());

                // Call the Start method of the type if it exists
                MethodInfo startMethod = type.GetMethod("Start");
                if (startMethod != null)
                {
                    startMethod.Invoke(mod, null);
                }
            }
        }

    }
}