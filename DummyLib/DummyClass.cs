namespace DummyLib;

public class DummyClass
{
  private readonly int _factor = 10;
  public int DummyProp { get; set; }

  public DummyClass() => Console.WriteLine("   DummyClass: Default Constructor");
  public DummyClass(int factor)
  {
    _factor = factor;
    Console.WriteLine("   DummyClass: Constructor DummyClass(int factor)");
  }

  public string DummyS(string x) => $"{x}_{x}";

  public void DummyF() => Console.WriteLine("   DummyClass: DummyF()");

  public int DummyG(int val)
  {
    int result = val * _factor;
    Console.WriteLine($"   DummyClass: DummyG({val}) = {result}");
    return result;
  }

  public double DummyH(int val, double divisor)
  {
    double result = val / divisor;
    Console.WriteLine($"   DummyClass: DummyH({val},{divisor}) = {result}");
    return result;
  }
  public double DummyH(int val, double divisor, double add)
  {
    double result = val / divisor + add;
    Console.WriteLine($"   DummyClass: DummyH({val},{divisor},{add}) = {result}");
    return result;
  }

  public static void StaticDummy(int x) => Console.WriteLine($"   DummyClass: StaticDummy({x})");

  private void PrivateDummy() => Console.WriteLine($"   DummyClass: PrivateDummy()");
}
