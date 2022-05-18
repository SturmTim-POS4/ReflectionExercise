namespace ReflectionExercise;

public class PersonDto
{
  public string Lastname { get; set; }
  public string Firstname { get; set; }
  public DateTime Birthdate { get; set; }
  public string Name => $"{Lastname} {Firstname}";
}
