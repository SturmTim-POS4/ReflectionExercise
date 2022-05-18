namespace DummyLib;

public class ClassB : ClassA
{
  public override int F(int val) => val / 10;

  public override int G(int valA, int valB) => valA / valB;
}
