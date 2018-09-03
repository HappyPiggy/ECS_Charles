/// <summary>
/// 为游戏对象分配uid
/// </summary>
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

   
    public static void ResetUid()
    {
        uid = 0;
    }
}