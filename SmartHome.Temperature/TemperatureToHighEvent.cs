namespace SmartHome.Temperature;

public class TemperatureToHighEvent : ISensorEvent
{
    public float Temperature { get; private set; }
    
    public TemperatureSensor AffectedSensor { get; }
    
    public TemperatureToHighEvent(float temperature, TemperatureSensor affectedSensor)
    {
        Temperature = temperature;
        AffectedSensor = affectedSensor;
    }

}