namespace AlzaUkol.Application._Shared.Utils;

public static class MyFileUtils
{
    /// <summary>
    /// Temporary method to get db folder, this may vary in the future.
    /// </summary>
    public static string GetDbFolder()
    {
        string currentDir = Directory.GetCurrentDirectory();

        // traverse up to src folder
        DirectoryInfo dir = new DirectoryInfo(currentDir);
        while (dir != null && !dir.Name.Equals("src", StringComparison.OrdinalIgnoreCase))
            dir = dir.Parent;

        // get parent of src folder
        dir = dir?.Parent;

        // get db subfolder
        string dbFolder = Path.Combine(dir.FullName, "db");
        
        return dbFolder;
    }
}
