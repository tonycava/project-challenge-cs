using Game.Engine;
using Project_CS.Data;

namespace Project_CS
{

  public static class Extensions
  {
    public static Color getColor(this Board.CharacterAttributes characterAttributes)
    {
      switch (characterAttributes)
      {
        case Board.CharacterAttributes.BACKGROUND_RED:
          return Color.RED;
        case Board.CharacterAttributes.BACKGROUND_BLUE:
          return Color.BLUE;
        case Board.CharacterAttributes.BACKGROUND_GREEN:
          return Color.GREEN;
        case Board.CharacterAttributes.BACKGROUND_INTENSITY:
          return Color.WHITE;
      }
      return Color.WHITE;
    }

    public static Board.CharacterAttributes getCharacterAttributes(this Color color)
    {
      List<Color> colors = new List<Color>();
      foreach (Board.CharacterAttributes characterAttributes in Enum.GetValues<Board.CharacterAttributes>())
      {
        colors.Add(characterAttributes.getColor());
      }

      Color nearestColor = GetClosestColor(colors.ToArray(), color);
      foreach (Board.CharacterAttributes characterAttributes in Enum.GetValues<Board.CharacterAttributes>())
      {
        if (nearestColor == characterAttributes.getColor())
        {
          return characterAttributes;
        }
      }

      return Board.CharacterAttributes.BACKGROUND_INTENSITY;
    }

    private static Color GetClosestColor(Color[] colorArray, Color baseColor)
    {
      var colors = colorArray.Select(x => new {Value = x, Diff = GetDiff(x, baseColor)}).ToList();
      var min = colors.Min(x => x.Diff);
      return colors.Find(x => x.Diff == min).Value;
    }

    private static int GetDiff(Color color, Color baseColor)
    {
      int r = color.R - baseColor.R,
        g = color.G - baseColor.G,
        b = color.B - baseColor.B;
      return r * r + g * g + b * b;
    }
  }
}