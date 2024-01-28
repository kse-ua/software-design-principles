namespace SmartHome.Temperature;

public class TemperatureSensor : ISensor
{
    public string Name { get; }

    public TemperatureSensor(string name)
    {
        Name = name;
    }

    public float GetTemperature() => 31;
}