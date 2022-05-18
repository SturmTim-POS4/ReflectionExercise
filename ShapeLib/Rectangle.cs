namespace ShapeLib;

[Serializable]
internal class Rectangle : BaseShape
{
  public override void Draw(DrawingContext g)
  {
    var rectangle = new Rect(TopLeftX, TopLeftY, Width, Height);
    g.DrawRectangle(Brush, Pen, rectangle);
  }
}
