namespace ShapeLib;

[Serializable]
public abstract class BaseShape
{
  #region ------------------------- Propterties
  public int TopLeftX { get; set; }
  public int TopLeftY { get; set; }
  public int Width { get; set; }
  public int Height { get; set; }

  [NonSerialized]
  protected Color _color;
  [NonSerialized]
  protected Brush _baseBrush;
  public Color Color
  {
    get => _color;
    set
    {
      _color = value;
      _baseBrush = new SolidColorBrush(_color);
    }
  }

  public bool Fill { get; set; }

  public Brush Brush => Fill ? _baseBrush : null;
  public Pen Pen => Fill ? null : new Pen(_baseBrush, 2);
  #endregion

  protected BaseShape()
  {
    TopLeftX = 0;
    TopLeftY = 0;
    Width = 50;
    Height = 40;
    Color = Colors.Blue;
    Fill = false;
  }

  public abstract void Draw(DrawingContext g);

}
