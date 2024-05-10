using System;

class Logging{
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
        
        Logging.warn("Test warn!");
    }
}