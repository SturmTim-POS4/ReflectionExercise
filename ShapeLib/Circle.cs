namespace ShapeLib;

[Serializable]
internal class Circle : BaseShape
{
  public override void Draw(DrawingContext g)
  {
    double x = (TopLeftX + Width) / 2.0;
    double y = (TopLeftY + Height) / 2.0;
    var center = new Point(x, y);
    g.DrawEllipse(Brush, Pen, center, Width / 2.0, Height / 2.0);
  }
}

