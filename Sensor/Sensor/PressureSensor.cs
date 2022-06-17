using System;

namespace Sensor
{
    public class PressureSensor : Sensor
    {
        private double value;
        public PressureSensor(string id ) : base( id )
        {
            value = 0;

        }
        public override SensorDTO ReadValue()
        {
            return new SensorDTO(base.GetId(), value.ToString());
        }
    }

    public class PressureSensorCreator: SensorProvider
    {
        public PressureSensorCreator() { }
        public override Sensor CreateSensor(string id)
        {
            return new PressureSensor(id);
        }
    }
}