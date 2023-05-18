
public class ReturnMultiParameter
{
    // This function return multiple parameter.
    public (int intValue, float floatValue) NamedMultipleValueReturnFunction()
    {
        int i = 123;
        float f = 123.123f;
        return (intValue: i, floatValue: f);
    }

    public void GetNamedMultipleValue()
    {
        int returnedNamedIntValue = NamedMultipleValueReturnFunction().intValue;
        float returnedNamedFloatValue = NamedMultipleValueReturnFunction().floatValue;
    }
}
public class ReferancePrimitiveType
{
    public void NamedReferanceTypeFunction(ref int intValue, ref float floatValue)
    {
        intValue = 123;
        floatValue = 123.123f;
    }

    public void GetNamedReferanceType()
    {
        int i = 0;
        float f = 0.0f;
        NamedReferanceTypeFunction(ref i, ref f);
    }

}
public class ReferancePrimitiveType2
{
    public void NamedReferanceTypeFunction(out int intValue, out float floatValue)
    {
        intValue = 123;
        floatValue = 123.123f;
    }

    public void GetNamedReferanceType()
    {
        int i = 0;
        float f = 0.0f;
        NamedReferanceTypeFunction(out i, out f);
    }

}

