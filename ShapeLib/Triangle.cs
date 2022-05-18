namespace ShapeLib;

[Serializable]
internal class Triangle : PointShape
{
  protected override List<Point> Points => new()
  {
        new Point(TopLeftX + Width/2, TopLeftY),
        new Point(TopLeftX, TopLeftY + Height),
        new Point(TopLeftX + Width, TopLeftY + Height)
      };
}
