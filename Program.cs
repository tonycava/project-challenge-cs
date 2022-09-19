using Game.Engine;

public class Project : Board
{
  public static void Main()
  {
    int[] cordOfChar = new[] {0, 0};
    DisplayGame(array2Db, cordOfChar);
    GameLoop.Update(cordOfChar);
  }
}