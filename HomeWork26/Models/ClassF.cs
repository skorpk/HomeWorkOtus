namespace Reflection.Models;

public class ClassF
{
    public int i1, i2, i3, i4, i5;

    public static ClassF Get()
    {
        return new ClassF { i1 = 1, i2 = 2, i3 = 3, i4 = 4, i5 = 5 };
    }
}
