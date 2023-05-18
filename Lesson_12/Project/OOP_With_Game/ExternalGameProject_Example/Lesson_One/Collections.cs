using System.Collections;
using UnityEngine;

public class CollectionsLesson{
    public static void Main()
    {

        //****Generic Collections*****
        //https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic?view=net-8.0 
        //System.Collections.Generic: This class contains generic collections that enforce type safety. 
        //This means that you can only add objects of the same data type to the collection, and you don’t need to cast them when you retrieve them.

        //List<T>: This is a generic collection that stores objects in a list and allows you to access them by index, similar to an array.
        //Includes methods such as Add, Remove, and Clear.
        //Includes properties such as Count and Capacity.
        //https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1?view=net-8.0
        List<int> numbers = new List<int>();
        numbers.Add(1);
        Console.WriteLine($"Count: {numbers.Count}"); // Count: 1
        Console.WriteLine($"Capacity: {numbers.Capacity}"); // Capacity: 4
        var count = numbers.Count;

        var evenNumbers = new List<int>() { 2, 4, 6, 8 };
        var oddNumbers = new List<int>() { 1, 3, 5, 7 };
        //AddRange: Adds the elements of the specified collection to the end of the List<T>.
        numbers.AddRange(evenNumbers);
        numbers.AddRange(oddNumbers);

        List<string> names = new List<string>();
        names.Add("John");
        names.Remove("John");
        
        List<Vector2> vectors = new List<Vector2>();
        vectors.Add(new Vector2(1, 2));
        vectors.Clear();

        //Dictionary<TKey, TValue>: This class is a generic collection of key-value pairs. Also, it’s a generic version of the Hashtable class.
        Dictionary<string, Vector2> keyValuePairs = new Dictionary<string, Vector2>();
        keyValuePairs.Add("Player", new Vector2(0, 0));
        keyValuePairs.Add("Enemy", new Vector2(1, 1));
        keyValuePairs.Add("NPC", new Vector2(2, 2));
        //Don't add same key twice 
        //keyValuePairs.Add("Player", new Vector2(0, 0)); //ArgumentException: An item with the same key has already been added. Key: Player

        keyValuePairs["Player"] = new Vector2(3, 3);
        keyValuePairs.Remove("Enemy");
        keyValuePairs.ContainsKey("NPC");


        //LinkedList<T> is a generic collection that stores a list of objects of the same type and provides methods to manipulate them.
        //A linked list is a data structure that consists of a sequence of nodes, each containing some data and a pointer to the next node. 
        //Linked lists are useful for storing and manipulating dynamic data that can grow or shrink during the program execution.
        LinkedList<int> linkedList = new LinkedList<int>();
        linkedList.AddFirst(1);
        var second = linkedList.AddAfter(linkedList.First, 2);
        var third = linkedList.AddAfter(second, 3);
        linkedList.AddLast(4);     
        //var t = linkedList[6]; // Error: Cannot apply indexing with [] to an expression of type 'LinkedList<int>'


        //Queue<T> is a first-in, first-out (FIFO) collection of objects that can be accessed by index and supports adding and removing items.
        //Different from a list, a queue only allows you to add items to the end of the queue and remove items from the beginning of the queue.
        Queue<int> queueGeneric = new Queue<int>();
        queueGeneric.Enqueue(1);
        queueGeneric.Enqueue(2);
        queueGeneric.Enqueue(3);
        var resultQueue = queueGeneric.Dequeue(); // 1 => remove first element and return. Remaining elements are 2, 3.

        //Stack<T> is a last-in, first-out (LIFO) collection of objects that can be accessed by index and supports adding and removing items. 
        //Difference from the list is that you can only add and remove items from the top of the stack.
        Stack<int> stackGeneric = new Stack<int>();
        stackGeneric.Push(1);
        stackGeneric.Push(2);
        stackGeneric.Push(3);
        var resultStack = stackGeneric.Pop(); // 3 => remove last element and return. Remaining elements are 1, 2.

        //HashSet<T> is a generic collection that stores unique elements and provides methods to manipulate them. Similar to List<T> but unique elements.
        HashSet<int> hashSet = new HashSet<int>();
        hashSet.Add(1);
        hashSet.Add(2);
        hashSet.Add(3);
        hashSet.Add(3); // 3 is already in the set, so this will be ignored.


        //****Non-Generic Collections*****
        //https://learn.microsoft.com/en-us/dotnet/api/system.collections?view=net-8.0
        //System.Collections: This class contains non-generic collections that can store any type of object. 
        //However, this means that you need to cast the objects when you retrieve them, and you may encounter runtime errors if the cast fails.

        //ArrayList: This class stores objects in a list and allows you to access them by index, similar to an array. Also, it’s a non-generic version of the List<T> class.
        //Not recommended to use. Use List<T> instead, because it’s type-safe.
        ArrayList arrayList = new ArrayList();
        ArrayList arrayList2 = new();
        var arrayList3 = new ArrayList();
        arrayList.Add(1);
        arrayList.Add("string");
        arrayList.Add(new Vector2(1, 1));


        //Hashtable: This class is a non-generic collection of key-value pairs.
        //Not recommended to use. Use Dictionary<TKey, TValue> instead, because it’s type-safe.
        Hashtable hashtable = new Hashtable();
        hashtable.Add("Player", new Vector2(0, 0));
        hashtable.Add(Months.April, 4);

        //Queue is a first-in, first-out (FIFO) collection of objects that can be accessed by index and supports adding and removing items.
        //Not recommended to use. Use Queue<T> instead, because it’s type-safe.
        Queue queue = new Queue();
        queue.Enqueue(1);
        queue.Enqueue(2.56f);

        //Stack is a last-in, first-out (LIFO) collection of objects that can be accessed by index and supports adding and removing items.
        //Not recommended to use. Use Stack<T> instead, because it’s type-safe.
        Stack stack = new Stack();
        stack.Push(1);
        stack.Push(2.56f);

        // IntEvenList: This class is a non-generic collection that stores only even numbers.
        var intList = new IntEvenList();
        intList.Add(2);
        intList.Add(4);
        //intList.Update(2, 3); // Error: Cannot apply indexing with [] to an expression of type 'IntEvenList'
        
    }

}

//****Custom Collections*****
public class IntEvenList : List<int>
{

    //override the Add method to only allow even numbers
    //https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/how-to-override-the-add-method-in-a-custom-collection
    // The following code example demonstrates how to override the Add method in a custom collection.
    // new keyword is used to explicitly hide a member inherited from a base class.
    public new void Add(int value)
    {
        if (value % 2 == 0)
        {
            // The base keyword is used to access members of the base class from within a derived class: Call the base class implementation of Add.
            base.Add(value);
        }
        else
        {
            throw new ArgumentException("You can only add even numbers to this collection.");
        }
    }

    // Create update method
    public void Update(int index, int value){
        if(value % 2 == 0){
            base[index] = value;
        }else{
            throw new ArgumentException("You can only add even numbers to this collection.");
        }

    }

}