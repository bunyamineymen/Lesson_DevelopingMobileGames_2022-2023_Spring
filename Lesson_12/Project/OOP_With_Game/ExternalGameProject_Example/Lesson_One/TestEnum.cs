
//Enums are a set of named constants that are assigned to a numeric value by default. 
//Enums are strongly typed constants. 
//Also, the default type is int, and the approved types are byte, sbyte, short, ushort, uint, long, and ulong.
//Enums are used when we know all possible values at compile time, such as choices on a menu, so we can use it to represent months, days, directions, colors, etc.
//Enums are value types and are created on the stack and not on the heap.
//Enums can be displayed as strings or as integer values.
//Enums can be declared outside a class or inside a class.
//An enum can be declared by using the enum keyword.
//The first enumerator has the default value of 0, and the value of each successive enumerator is increased by 1.
//Enums can be initialized with a specific value, which is called an explicit enumerator.
//Enums can include several explicit enumerators, which will be assigned a value based on the value of the previous enumerator.
//This Enum is Month, and it has 12 enumerators, which are the months of the year.

public enum Months
{
    January=1,
    February,
    March,
    April,
    May,
    June,
    July,
    August,
    September,
    October,
    November,
    December

}

public class TestEnum
{
    public static void Main()
    {
        SelectMonth(Months.March);
    }
    // Method that takes an enum as a parameter and prints the value.
    public static void SelectMonth(Months month)
    {
        switch (month)
        {
            case Months.January:
                Console.WriteLine("The month is sort name is Jan.");
                break;
            case Months.February:
                Console.WriteLine("The month is sort name is Feb.");
                break;
            case Months.March:
                Console.WriteLine("The month is sort name is Mar.");
                break;
            case Months.April:
                Console.WriteLine("The month is sort name is Apr.");
                break;
            case Months.May:
                Console.WriteLine("The month is sort name is May.");
                break;
            case Months.June:
                Console.WriteLine("The month is sort name is Jun.");
                break;
            case Months.July:
                Console.WriteLine("The month is sort name is Jul.");
                break;
            case Months.August:
                Console.WriteLine("The month is sort name is Aug.");
                break;
            case Months.September:
                Console.WriteLine("The month is sort name is Sep.");
                break;
            case Months.October:
                Console.WriteLine("The month is sort name is Oct.");
                break;
            case Months.November:
                Console.WriteLine("The month is sort name is Nov.");
                break;
            case Months.December:
                Console.WriteLine("The month is sort name is Dec.");
                break;
            default:
                break;
        }

    }
    // Method that takes a int as a parameter and prints the value.
    public static void SelectMonth(int month){

        switch (month)
        {
            case 1:
                Console.WriteLine("The month is sort name is Jan.");
                break;
            case 2:
                Console.WriteLine("The month is sort name is Feb.");
                break;
            case 3:
                Console.WriteLine("The month is sort name is Mar.");
                break;
            case 4:
                Console.WriteLine("The month is sort name is Apr.");
                break;
            case 5:
                Console.WriteLine("The month is sort name is May.");
                break;
            case 6:
                Console.WriteLine("The month is sort name is Jun.");
                break;
            case 7:
                Console.WriteLine("The month is sort name is Jul.");
                break;
            case 8:
                Console.WriteLine("The month is sort name is Aug.");
                break;
            case 9:
                Console.WriteLine("The month is sort name is Sep.");
                break;
            case 10:
                Console.WriteLine("The month is sort name is Oct.");
                break;
            case 11:
                Console.WriteLine("The month is sort name is Nov.");
                break;
            case 12:
                Console.WriteLine("The month is sort name is Dec.");
                break;
            default:
                Console.WriteLine("Invalid Month");
                break;
        }


    }

}
