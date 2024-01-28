using SmartHome;
using SmartHome.Temperature;

var system = new SmartHome.SmartHome(new List<ISensor>()
{
    new TemperatureSensor("Kitchen"),
    new TemperatureSensor("Bedroom"),
}, () => new List<ISensorEventTrigger>()
{
    new TemperatureToHighTrigger()
}, new List<ISensorEventHandler>()
{
    new WhenTemperatureToHighLogHandler()
});

system.Start();