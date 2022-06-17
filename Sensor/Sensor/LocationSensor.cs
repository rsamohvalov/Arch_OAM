using System;

namespace Sensors
{
    public class LocationSensor : Sensor
    {
        private double longtitude;
        private double latitude;
        private double speed;
        private double direction;
        public LocationSensor(string id) : base(id)
        {
            longtitude = 0;

        }
        public string toString()
        {
            return longtitude.ToString() + "|" + latitude.ToString() + "|" + speed.ToString() + "|" + direction.ToString();
        }
        public void UpdateValues()
        {
            latitude = 1;
            longtitude = 2;
            speed = 0;
            direction = 0;
        }
        public override SensorDTO ReadValue()
        {
            UpdateValues();
            return new SensorDTO(base.GetId(), toString());
        }
    }

    public class LocationSensorCreator : SensorProvider
    {
        public LocationSensorCreator() { }
        public override Sensor CreateSensor(string id)
        {
            return new LocationSensor(id);
        }
    }
}