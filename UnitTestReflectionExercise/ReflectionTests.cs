using ShapeLib;

namespace UnitTestReflectionExercise;

public class ReflectionTests
{

  [Fact]
  public void T01a_ListTest()
  {
    var expected = new ArrayList { "abc", "def", "ghi" };
    object actual = Program.T01a_List();
    actual.GetType().Should().Be(typeof(ArrayList));
    actual.Should().BeEquivalentTo(expected);
  }
  [Fact]
  public void T01b_ListTestGeneric()
  {
    var expected = new List<string> { "abc", "def", "ghi" };
    Program.T01b_ListGeneric().GetType().Should().Be(typeof(List<string>));
    Program.T01b_ListGeneric().Should().BeEquivalentTo(expected);
  }

  [Fact]
  public void T02a_DictionaryTest()
  {
    var expected = new Hashtable
      {
        { 1, "Hansi" },
        { 2, "Susi" }
      };
    object actual = Program.T02a_Dictionary();
    actual.GetType().Should().Be(typeof(Hashtable));
    actual.Should().BeEquivalentTo(expected);
  }
  [Fact]
  public void T02b_DictionaryTestGeneric()
  {
    var expected = new Dictionary<int,string>
      {
        { 1, "Hansi" },
        { 2, "Susi" }
      };
    object actual = Program.T02b_DictionaryGeneric();
    actual.GetType().Should().Be(typeof(Dictionary<int, string>));
    actual.Should().BeEquivalentTo(expected);
  }

  [Fact]
  public void T03_ParseTest()
  {
    int val = 123;
    object actual = Program.T03_Parse("" + val);
    actual.GetType().Should().Be(typeof(int));
    actual.Should().Be(val);
  }

  [Fact]
  public void T04_GetFontTest()
  {
    //var rect = new System.Drawing.Rectangle(10, 10, 50, 50);
    var font = new System.Drawing.Font("Arial", 12);
    float expected = font.GetHeight(100);
    object actual = Program.T04_GetFontHeight();
    actual.GetType().Should().Be(typeof(float));
    actual.Should().Be(expected);
  }

  [Fact]
  public void T05_ConcreteShapes()
  {
    Program.T05_ConcreteShapes("ShapeLib").Should().Equal(new List<string> { "Circle", "Line", "Rectangle", "Trapez", "Triangle" });
    Program.T05_ConcreteShapes("DummyLib").Should().Equal(new List<string> { });
  }

  [Fact]
  public void T06_VoidMethods()
  {
    var expected = new List<string> { "BaseShape::Draw", "Circle::Draw", "Line::Draw", "PointShape::Draw", "Rectangle::Draw", "SomeDummyClass::MethodWithOneParameter", "SomeDummyClass::MethodWithTwoParameters", "Trapez::Draw", "Triangle::Draw" };
    Program.T06_VoidMethods("ShapeLib").Should().Equal(expected);
    Program.T06_VoidMethods("DummyLib").Should().Equal(new List<string> { "DummyClass::DummyF", "DummyClass::StaticDummy" });
  }

  [Fact]
  public void T07_TwoOrMoreParameters()
  {
    Program.T07_TwoOrMoreParameters("ShapeLib").Should().Equal(new List<string> { "SomeDummyClass::MethodWithTwoParameters" });
    Program.T07_TwoOrMoreParameters("DummyLib").Should().Equal(new List<string> { "AAA::Squared", "ClassA::G", "ClassB::G", "ClassC::H", "DummyClass::DummyH" });
  }

  [Fact]
  public void T08_AllProperties()
  {
    var expected = new List<string> { "BaseShape::TopLeftX", "BaseShape::TopLeftY", "BaseShape::Width", "BaseShape::Height", "BaseShape::Color", "BaseShape::Fill", "BaseShape::Brush", "BaseShape::Pen", "Circle::TopLeftX", "Circle::TopLeftY", "Circle::Width", "Circle::Height", "Circle::Color", "Circle::Fill", "Circle::Brush", "Circle::Pen", "Line::TopLeftX", "Line::TopLeftY", "Line::Width", "Line::Height", "Line::Color", "Line::Fill", "Line::Brush", "Line::Pen", "PointShape::TopLeftX", "PointShape::TopLeftY", "PointShape::Width", "PointShape::Height", "PointShape::Color", "PointShape::Fill", "PointShape::Brush", "PointShape::Pen", "Rectangle::TopLeftX", "Rectangle::TopLeftY", "Rectangle::Width", "Rectangle::Height", "Rectangle::Color", "Rectangle::Fill", "Rectangle::Brush", "Rectangle::Pen", "Trapez::TopLeftX", "Trapez::TopLeftY", "Trapez::Width", "Trapez::Height", "Trapez::Color", "Trapez::Fill", "Trapez::Brush", "Trapez::Pen", "Triangle::TopLeftX", "Triangle::TopLeftY", "Triangle::Width", "Triangle::Height", "Triangle::Color", "Triangle::Fill", "Triangle::Brush", "Triangle::Pen" };
    Program.T08_AllProperties("ShapeLib").Should().Equal(expected);
    Program.T08_AllProperties("DummyLib").Should().Equal(new List<string> { "AAA::DummyProp", "DummyClass::DummyProp" });
  }

  [Fact]
  public void T09_ClassesWithNonDefaultConstructor()
  {
    Program.T09_ClassesWithNonDefaultConstructor("ShapeLib").Should().Equal(new List<string> { "SomeDummyClass" });
    Program.T09_ClassesWithNonDefaultConstructor("DummyLib").Should().Equal(new List<string> { "DummyClass" });
  }

  [Fact]
  public void T10_ClassesImplementingDraw()
  {
    Program.T10_ClassesImplementingDraw("ShapeLib").Should().Equal(new List<string> { "Circle", "Line", "Rectangle", "Trapez", "Triangle" });
    Program.T10_ClassesImplementingDraw("DummyLib").Should().Equal(new List<string> { });
  }
  
  [Fact]
  public void T11a_PropertiesPublicGetter()
  {
    Program.T11a_PropertiesPublicGetter(new Person()).Should().Equal(new List<string> { "BirthDate", "Firstname", "Id", "Lastname" });
    Program.T11a_PropertiesPublicGetter(new PersonDto()).Should().Equal(new List<string> { "Birthdate", "Firstname", "Lastname", "Name" });
  }
  
  [Fact]
  public void T11b_PropertiesPublicSetter()
  {
    Program.T11b_PropertiesPublicSetter(new Person()).Should().Equal(new List<string> { "BirthDate", "Firstname", "Id", "Lastname" });
    Program.T11b_PropertiesPublicSetter(new PersonDto()).Should().Equal(new List<string> { "Birthdate", "Firstname", "Lastname" });
  }
  
  [Fact]
  public void T11c_PropertiesSame()
  {
    Program.T11c_PropertiesSame(new Person(),new PersonDto()).Should().Equal(new List<string> { "BirthDate", "Firstname", "Lastname" });
  }
  
  [Fact]
  public void T11d_CopyPropertiesTo()
  {
    PersonDto personDto = new PersonDto();
    Program.T11d_CopyPropertiesTo(personDto,new Person(){Firstname = "Tim", Lastname = "Sturm", BirthDate = DateTime.Parse("21.12.2003")});
    personDto.Should().Be(new PersonDto()
      {Firstname = "Tim", Lastname = "Sturm", Birthdate = DateTime.Parse("21.12.2003")});
  }
}
