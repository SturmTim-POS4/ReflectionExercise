namespace ShapeLib;

[Serializable]
internal class Line : BaseShape
{
  public override void Draw(DrawingContext g)
  {
    g.DrawLine(new Pen(_baseBrush, 2),
      new Point(TopLeftX, TopLeftY),
      new Point(TopLeftX + Width, TopLeftY + Height));
  }
}
