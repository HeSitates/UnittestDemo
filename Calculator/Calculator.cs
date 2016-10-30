namespace MyCalculator.BLL
{
  public class Calculator
  {
    public double Result { get; set; }

    public void Add(double i)
    {
      Result += i;
    }

    public void Clear()
    {
      Result = default(double);
    }
  }
}