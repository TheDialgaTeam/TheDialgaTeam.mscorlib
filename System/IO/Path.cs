namespace TheDialgaTeam.mscorlib.System.IO
{
    public static class Path
    {
        public static string GetFullPath(string path)
        {
            return global::System.IO.Path.GetFullPath(GetFilePath(path));
        }

        public static string GetFilePath(string path)
        {
            return path.Replace('/', global::System.IO.Path.DirectorySeparatorChar).Replace('\\', global::System.IO.Path.DirectorySeparatorChar);
        }
    }
}