namespace SmartHome.Temperature;

public class TemperatureToHighTrigger : SensorEventTrigger<TemperatureSensor>
{
    protected override void CheckInternal(TemperatureSensor sensor)
    {
        var temperature = sensor.GetTemperature();
        if (temperature > 30)
        {
            Publish(new TemperatureToHighEvent(temperature, sensor));
        }
    }
}