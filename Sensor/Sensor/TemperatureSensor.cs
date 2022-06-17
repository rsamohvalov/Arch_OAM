using System;

namespace Sensor
{
    public class TemperatureSensor : Sensor
    {
        private double value;
        public TemperatureSensor(string id) : base(id)
        {
            value = 0;
        }
        private void GetCurrentTemperature()
        {
            value = 111;
        }
        public override SensorDTO ReadValue()
        {
            GetCurrentTemperature();
            return new SensorDTO(base.GetId(), value.ToString());
        }
    }

    public class TemperatureSensorCreator : SensorProvider
    {
        public TemperatureSensorCreator() { }
        public override Sensor CreateSensor(string id)
        {
            return new TemperatureSensor(id);
        }
    }
}