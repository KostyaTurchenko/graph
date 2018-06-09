using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace IntGraph
{
    public class FileTools
    {
        public string Path { get; set; }
        public FileTools(string path) => Path = path;
        public string Read() => File.ReadAllText(Path);
        public void Write(string s) => File.WriteAllText(Path, s);
    }
}
