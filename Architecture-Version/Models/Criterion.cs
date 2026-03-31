public class Criterion
{
    public string Name { get; private set; }
    public int Weight { get; private set; }

    public Criterion(string name, int weight)
    {
        Name = name;
        Weight = weight;
    }
}