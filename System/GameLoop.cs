namespace Game.Engine
{
  public class GameLoop : Board
  {
    public static void Update(int[] cordOfChar)
    {
      ConsoleKeyInfo keyinfo = new ConsoleKeyInfo();
      do
      {
        keyinfo = Console.ReadKey();

        switch (keyinfo.Key)
        {
          case ConsoleKey.UpArrow:
            cordOfChar[0] -= 1;
            DisplayGame(array2Db, cordOfChar);
            break;
          case ConsoleKey.DownArrow:
            cordOfChar[0] += 1;
            DisplayGame(array2Db, cordOfChar);
            break;

          case ConsoleKey.LeftArrow:
            cordOfChar[1] -= 1;
            DisplayGame(array2Db, cordOfChar);
            break;
          case ConsoleKey.RightArrow:
            cordOfChar[1] += 1;
            DisplayGame(array2Db, cordOfChar);
            break;
        }

        Console.WriteLine(keyinfo.Key + " was pressed");
      } while (keyinfo.Key != ConsoleKey.Escape);
    }
  };
}