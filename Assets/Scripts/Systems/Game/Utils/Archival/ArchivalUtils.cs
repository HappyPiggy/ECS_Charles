

public static class ArchivalUtils
{

    /// <summary>
    /// 游戏存档存储帮助类
    /// </summary>
    public static void Save(object save)
    {
        IOHelper.CreateDirectory(ConstantUtils.dirpath);
        IOHelper.SetData(ConstantUtils.filename, save);
    }

    /// <summary>
    /// 加载游戏存档
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static T Load<T>()
    {
        T t1 = (T)IOHelper.GetData(ConstantUtils.filename, typeof(T));
        return t1;
    }

}