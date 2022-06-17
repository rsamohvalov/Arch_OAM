using System;

namespace Sensors
{
    public class PressureSensor : Sensor
    {
        private double value;
        public PressureSensor(string id ) : base( id )
        {
            value = 0;

        }
        private void GetCurrentPressure()
        {
            value = 111;
        }
        public override SensorDTO ReadValue()
        {
            GetCurrentPressure();
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