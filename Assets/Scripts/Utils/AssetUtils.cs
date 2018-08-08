

public class AssetUtils
{
    public static string GetAssetFolderName(AssetType tp)
    {
        string name = "";

        switch (tp)
        {
            case AssetType.Module:
                name = "Module";
                break;
        }
        return name;

    }
}