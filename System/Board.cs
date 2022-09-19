namespace Game.Engine
{
  public class Board
  {
    private static bool _isFirstTime = true;
    private static string _Username = "";
    protected static string[,] array2Db = new string[10, 10]
    {
      {"O", "O", "O", "O", "O", "O", "O", "O", "O", "O"},
      {"O", "O", "O", "O", "O", "O", "O", "O", "O", "O"},
      {"O", "O", "O", "O", "O", "O", "O", "O", "O", "O"},
      {"O", "O", "O", "O", "O", "O", "O", "O", "O", "O"},
      {"O", "O", "O", "O", "O", "O", "O", "O", "O", "O"},
      {"O", "O", "O", "O", "O", "O", "O", "O", "O", "O"},
      {"O", "O", "O", "O", "O", "O", "O", "O", "O", "O"},
      {"O", "O", "O", "O", "O", "O", "O", "O", "O", "O"},
      {"O", "O", "O", "O", "O", "O", "O", "O", "O", "O"},
      {"O", "O", "O", "O", "O", "O", "O", "O", "O", "O"},
    };

    protected static void DisplayGame(string[,] array2Db, int[] PlayerCord)
    {
      if (_isFirstTime)
      {
        Console.Write("Enter username: ");
        _Username = Console.ReadLine();
        _isFirstTime = false;
      }

      Console.CursorVisible = false;
      Console.Clear();
      Console.WriteLine(_Username);
      
      for (int i = 0; i < array2Db.GetLength(0); i++)
      {
        for (int j = 0; j < array2Db.GetLength(1); j++)
        {
          Console.Write(i == PlayerCord[0] && j == PlayerCord[1] ? "X " : array2Db[i, j] + " ");
        }

        Console.Write("\n");
      }
    }
  }
};