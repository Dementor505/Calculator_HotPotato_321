using System;
using System.IO;

namespace kalk
{
    public static class TxtStorage
    {
        readonly static string path = @"C:\Users\212122\Desktop\Calculator\Calculator\Components\txt_storage.txt";
        static public void AddNewLine(string value)
        {
            File.AppendAllText(path, value + Environment.NewLine);
        }
    }
}
