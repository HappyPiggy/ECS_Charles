

public class UidUtils
{

    private static ulong uid = 0;

    public static ulong Uid
    {
        get
        {
            uid++;
            return uid;
        }

    }
}