namespace SmartHome.Temperature;

public class WhenTemperatureToHighLogHandler : SensorEventHandler<TemperatureToHighEvent>
{
    protected override void OnEvent(TemperatureToHighEvent ev)
    {
        Console.WriteLine($"Temperature is {ev.Temperature}º at {ev.AffectedSensor.Name}");
    }
}