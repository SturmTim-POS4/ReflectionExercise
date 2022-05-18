
using System.Reflection.Emit;

namespace ReflectionExercise;

public static class ExtensionMethods
{
  public static IEnumerable<T> Print<T>(this IEnumerable<T> collection)
  {
    collection.ToList().ForEach(x => Console.WriteLine($"  {x}"));
    Console.WriteLine();
    return collection;
  }
}

public class Program
{
  private static void Main()
  {
    try
    {
      object list = T01a_List();
      object listGeneric = T01b_ListGeneric();
      object dict = T02a_Dictionary();
      object dictGeneric = T02b_DictionaryGeneric();
      object val = T03_Parse("123");
      object sFont = T04_GetFontHeight();
      T05_ConcreteShapes("ShapeLib").Print();
      T05_ConcreteShapes("DummyLib").Print();
      T06_VoidMethods("ShapeLib").Print();
      T06_VoidMethods("DummyLib").Print();
      T07_TwoOrMoreParameters("ShapeLib").Print();
      T07_TwoOrMoreParameters("DummyLib").Print();
      T08_AllProperties("ShapeLib").Print();
      T08_AllProperties("DummyLib").Print();
      T09_ClassesWithNonDefaultConstructor("ShapeLib").Print();
      T09_ClassesWithNonDefaultConstructor("DummyLib").Print();
      T10_ClassesImplementingDraw("ShapeLib").Print();
      T10_ClassesImplementingDraw("DummyLib").Print();
    }
    catch (Exception exc)
    {
      Console.WriteLine(exc.ToString());
    }
    Console.ReadKey();
  }

  public static object T01a_List()
  {
      var ass = Assembly.Load("mscorlib");
      Type type = ass.GetType("System.Collections.ArrayList");
      var instance = Activator.CreateInstance(type);
      MethodInfo methodInfo = type.GetMethod("Add");
      methodInfo.Invoke(instance, new []{"abc"});
      methodInfo.Invoke(instance, new []{"def"});
      methodInfo.Invoke(instance, new []{"ghi"});
      
      return instance;
  }
  public static object T01b_ListGeneric()
  {
      var ass = Assembly.Load("mscorlib");
      Type type = ass.GetType("System.Collections.Generic.List`1");
      type = type.MakeGenericType(typeof(string));
      var instance = Activator.CreateInstance(type);
      MethodInfo methodInfo = type.GetMethod("Add");
      methodInfo.Invoke(instance, new []{"abc"});
      methodInfo.Invoke(instance, new []{"def"});
      methodInfo.Invoke(instance, new []{"ghi"});
      return instance;
  }

  public static object T02a_Dictionary()
  {
    var ass = Assembly.Load("mscorlib");
    Type type = ass.GetType("System.Collections.Hashtable");
    var instance = Activator.CreateInstance(type);
    MethodInfo methodInfo = type.GetMethod("Add");
    methodInfo.Invoke(instance, new object[]{1,"Hansi"});
    methodInfo.Invoke(instance, new object[]{2,"Susi"});
    return instance;
  }
  public static object T02b_DictionaryGeneric()
  {
    var ass = Assembly.Load("mscorlib");
    Type type = ass.GetType("System.Collections.Generic.Dictionary`2");
    type = type.MakeGenericType(typeof(int),typeof(string));
    var instance = Activator.CreateInstance(type);
    MethodInfo methodInfo = type.GetMethod("Add");
    methodInfo.Invoke(instance, new object[]{1,"Hansi"});
    methodInfo.Invoke(instance, new object[]{2,"Susi"});
    return instance;
      return new System.Collections.Generic.Dictionary<int,string>();

  }

  public static object T03_Parse(string sVal)
  {
    var ass = Assembly.Load("mscorlib");
    Type type = ass.GetType("System.Int32");
    MethodInfo methodInfo = type.GetMethod("Parse",new[]{typeof(string)});
    var instance = methodInfo.Invoke(type, new[] {sVal});
    return instance;
  }

  public static object T04_GetFontHeight()
  {
      var ass = Assembly.Load("System.Drawing.Common");
      Type type = ass.GetType("System.Drawing.Font");
      var instance = Activator.CreateInstance(type,"Arial",12);
      MethodInfo methodInfo = type.GetMethod("GetHeight", new [] {typeof(int)});
      var result = methodInfo.Invoke(instance, new object[]{100});
      return result;
  }

  public static IEnumerable<string> T05_ConcreteShapes(string localAssemblyame)
  {
    Console.WriteLine($"T05_ConcreteShapes {localAssemblyame}");
    var ass = Assembly.Load(localAssemblyame);
    var types = ass.GetTypes().Where(x => x.BaseType == typeof(BaseShape)).ToList();
    var results = new List<Type>();
    while (types.Count > 0)
    {
      var type = types.First();
      types.AddRange(ass.GetTypes().Where(x => x.BaseType == type));
      results.Add(type);
      types.RemoveAt(0);
    }
    return results.Where(x => !x.IsAbstract).Select(x => x.Name).ToList();
  }

  public static IEnumerable<string> T06_VoidMethods(string localAssemblyame)
  {
    Console.WriteLine($"T06_VoidMethods {localAssemblyame}");
    var ass = Assembly.Load(localAssemblyame);
    var types = ass.GetTypes().ToList();
    var methods = types.SelectMany(x => x.GetMethods()
      .Where(x => x.ReturnType == typeof(void) && !x.IsSpecialName)
      .Select(x => $"{x.ReflectedType.Name}::{x.Name}"))
      .OrderBy(x => x)
      .ToList();
    return methods;
  }

  public static IEnumerable<string> T07_TwoOrMoreParameters(string localAssemblyame)
  {
    Console.WriteLine($"T07_TwoOrMoreParameters {localAssemblyame}");
    var ass = Assembly.Load(localAssemblyame);
    var types = ass.GetTypes().ToList();
    var methods = types.SelectMany(x => x.GetMethods()
        .Where(x => x.GetParameters().Length >= 2 && !x.IsSpecialName)
        .Select(x => $"{x.ReflectedType.Name}::{x.Name}"))
      .Distinct()
      .OrderBy(x => x)
      .ToList();
    return methods;
  }

  public static IEnumerable<string> T08_AllProperties(string localAssemblyame)
  {
    Console.WriteLine($"T08_AllProperties {localAssemblyame}");
    var ass = Assembly.Load(localAssemblyame);
    var types = ass.GetTypes().ToList();
    var properties = types.SelectMany(x => x.GetProperties()
        .Select(x => $"{x.ReflectedType.Name}::{x.Name}"))
      .ToList();
    return properties;
  }

  public static IEnumerable<string> T09_ClassesWithNonDefaultConstructor(string localAssemblyame)
  {
    Console.WriteLine($"T09_ClassesWithNonDefaultConstructor {localAssemblyame}");
    var ass = Assembly.Load(localAssemblyame);
    var types = ass.GetTypes().ToList();
    var classes = types.Where(x => x.GetConstructors().Length > 1).Select(x => x.Name).ToList();
    return classes;
  }

  public static IEnumerable<string> T10_ClassesImplementingDraw(string localAssemblyame)
  {
    Console.WriteLine($"T10_ClassesImplementingDraw {localAssemblyame}");
    var ass = Assembly.Load(localAssemblyame);
    var types = ass.GetTypes().ToList();
    var classes = types.Where(x => !x.IsAbstract).Where(x => x.GetMethod("Draw") != null).Select(x => x.Name).ToList();
    return classes;
  }

  public static IEnumerable<string> T11a_PropertiesPublicGetter(object obj)
  {
    return obj.GetType().GetProperties()
      .Where(x => x.CanRead).Select(x => x.Name).OrderBy(x => x).ToList();
  }

  public static IEnumerable<string> T11b_PropertiesPublicSetter(object obj)
  {
    return obj.GetType().GetProperties()
      .Where(x => x.CanWrite).Select(x => x.Name).OrderBy(x => x).ToList();
  }
  public static IEnumerable<string> T11c_PropertiesSame(object objA, object objB)
  {
    return objA.GetType().GetProperties()
      .Select(x => x.Name)
      .Where(x => objB.GetType().GetProperties().Select(x => x.Name.ToUpper()).ToList().Contains(x.ToUpper()))
      .OrderBy(x => x).ToList();
  }
  public static void T11d_CopyPropertiesTo(object objTo, object objFrom)
  {
    var propertiesObjTo = T11c_PropertiesSame(objTo, objFrom)
      .ToList();
    var propertiesObjFrom = T11c_PropertiesSame(objFrom, objTo)
      .ToList();
    for (int i = 0; i < propertiesObjTo.Count; i++)
    {
      objTo.GetType().GetProperty(propertiesObjTo[i]).SetValue(objTo, objFrom.GetType().GetProperty(propertiesObjFrom[i]).GetValue(objFrom));
    }
  }
}
