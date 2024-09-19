namespace BlazorLearnApp.Logic;

public class DemoLogic
{
    public int value1 {  get; private set; }
    public int value2 { get; private set; }

    public DemoLogic() 
    {
        value1 = Random.Shared.Next(1,100);
        value2 = Random.Shared.Next(101,200);
    }
}
