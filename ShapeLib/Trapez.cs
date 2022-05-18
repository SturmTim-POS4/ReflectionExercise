namespace ShapeLib;

[Serializable]
internal class Trapez : PointShape
{
  protected override List<Point> Points => new()
  {
        new Point(TopLeftX + Width/4, TopLeftY),
        new Point(TopLeftX + Width*3/4, TopLeftY),
        new Point(TopLeftX + Width, TopLeftY + Height),
        new Point(TopLeftX, TopLeftY + Height)
      };

}

