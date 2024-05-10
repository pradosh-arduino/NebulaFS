using System;
using System.IO;
using System.Text;

struct NebulaFileSystemEntry
{
    UInt64 FileSize;
    UInt64 DataOffset; // offset from the end of the fs header that points to the start of the file data
}

struct NebulaFileSystemHeader
{
    private Dictionary<string,NebulaFileSystemEntry> FileDescriptors;
    private string Signature;
    private UInt64 FileCount;

    public NebulaFileSystemHeader()
    {
        // idk, read the signature and compare it with "NBFS"
        // read from somewhere
    }

    public void AddFile(string name, string path)
    {
        // this should just add a file from the user's drive to the fs
        // offsets should be calculated once all files have been added
    }

    public void Save(string path)
    {
        // 1. calculate file offsets
        // 2. write everything to the file at `path`
    }
}

class Logging{
    public static void done(string message){
        Console.WriteLine("\x1b[92m[Done] " + message + "\x1b[0m");
    }
    public static void info(string message){
        Console.WriteLine("\x1b[94m[Info] " + message + "\x1b[0m");
    }
    public static void warn(string message){
        Console.WriteLine("\x1b[93m[Warn] " + message + "\x1b[0m");
    }
    public static void error(string message){
        Console.WriteLine("\x1b[91m[Error] " + message + "\x1b[0m");
    }
}

class Nebula{
    public static void Main(string[] args){
        Nebula self = new Nebula();
        Console.Clear();
        while(true){
            Console.Write(">> ");
            string command = Console.ReadLine();
            self.handle_commands(command);
        }
    }

    byte[] to_bytes(string str){
        return Encoding.ASCII.GetBytes(str);
    }

    void handle_commands(string command){
        switch(command){
            case "init":
                using (FileStream fs = File.Open("./disk.img", FileMode.Create))
                {
                    using (BinaryWriter writer = new BinaryWriter(fs))
                    {
                        writer.Write(to_bytes("NBFS"));
                        writer.Write((UInt64)0);
                        writer.Write(to_bytes("\0"));
                        writer.Write(to_bytes("\0"));
                    }
                }
                break;
            case "quit":
                Environment.Exit(0);
                break; // WHY DOTNET? 
            case "":
                break;
            default:
                Logging.error("Unknown command - " + command);
                break; // WHY DOTNET?
        }
    }
}