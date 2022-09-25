using System;
using System.Collections.Generic;
using System.IO;

namespace CLIPixelEngine.Engine.Generic
{
  public class Logger
  {
    public int fCount = 0;

    /// <summary>
    /// create the log file
    /// </summary>
    public void CreateLogFile()
    {
      Directory.CreateDirectory("./CLIPixelEngine/Log/");
      fCount = Directory.GetFiles("./CLIPixelEngine/Log/", "*", SearchOption.AllDirectories).Length;
      File.CreateText("./CLIPixelEngine/Log/log_" + (fCount + 1) + ".txt").Close();
    }

    /// <summary>
    /// Log the given message
    /// </summary>
    /// <param name="line">message to log (add \n) for new line</param>
    public void Log(string line)
    {
      fCount = Directory.GetFiles("./CLIPixelEngine/Log/", "*", SearchOption.AllDirectories).Length;
      File.AppendAllText("./CLIPixelEngine/Log/log_" + fCount + ".txt", line);
    }
  }
}