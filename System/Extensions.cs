using Project_CS.Data;

namespace Project_CS
{

  public static class Extensions
  {
    public static Color getColor(this Konsole.CharacterAttributes characterAttributes)
    {
      switch (characterAttributes)
      {
        case Konsole.CharacterAttributes.BACKGROUND_RED:
          return Color.RED;
        case Konsole.CharacterAttributes.BACKGROUND_BLUE:
          return Color.BLUE;
        case Konsole.CharacterAttributes.BACKGROUND_GREEN:
          return Color.GREEN;
        case Konsole.CharacterAttributes.BACKGROUND_INTENSITY:
          return Color.WHITE;
      }
      return Color.WHITE;
    }

    public static Konsole.CharacterAttributes getCharacterAttributes(this Color color)
    {
      List<Color> colors = new List<Color>();
      foreach (Konsole.CharacterAttributes characterAttributes in Enum.GetValues<Konsole.CharacterAttributes>())
      {
        colors.Add(characterAttributes.getColor());
      }

      Color nearestColor = GetClosestColor(colors.ToArray(), color);
      foreach (Konsole.CharacterAttributes characterAttributes in Enum.GetValues<Konsole.CharacterAttributes>())
      {
        if (nearestColor == characterAttributes.getColor())
        {
          return characterAttributes;
        }
      }

      return Konsole.CharacterAttributes.BACKGROUND_INTENSITY;
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