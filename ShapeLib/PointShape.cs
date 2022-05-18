namespace ShapeLib;

[Serializable]
internal abstract class PointShape : BaseShape
{
  protected abstract List<Point> Points { get; }

  public override void Draw(DrawingContext g)
  {
    var streamGeometry = new StreamGeometry();
    using (var geometryContext = streamGeometry.Open())
    {
      geometryContext.BeginFigure(Points.First(), true, true);
      geometryContext.PolyLineTo(Points.Skip(1).ToList(), true, true);
    }
    streamGeometry.Freeze();
    g.DrawGeometry(Brush, Pen, streamGeometry);
  }
}

