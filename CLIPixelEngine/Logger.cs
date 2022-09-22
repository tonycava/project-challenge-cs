using System;
using System.Collections.Generic;
using System.IO;

namespace CLIPixelEngine.Engine.Generic
{
  public class Logger
  {
    public List<string> text = new List<string>();

    public void CreateLogFile()
    {
      int fCount = Directory.GetFiles("./CLIPixelEngine/Log/", "*", SearchOption.AllDirectories).Length;
      File.CreateText("./CLIPixelEngine/Log/log_" + (fCount + 1) + ".txt");
    }

    public void Log(string line)
    {
      int fCount = Directory.GetFiles("./CLIPixelEngine/Log/", "*", SearchOption.AllDirectories).Length;
      File.AppendAllText("./CLIPixelEngine/Log/log_" + fCount + ".txt",line);
    }
  }
}