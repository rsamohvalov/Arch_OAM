using System;
using System.Collections.Generic;

namespace Sensor
{
    public class SensorDTO
    {
        public string Id;
        public string Value;
        public DateTime time;
        public SensorDTO(string id )
        {
            Id = id;
            Value = "n/a";
            time = DateTime.Now;
        }
        public SensorDTO(string id, string val)
        {
            Id = id;
            Value = val;
            time = DateTime.Now;
        }
        public SensorDTO(string id, string val, DateTime t)
        {
            Id = id;
            Value = val;
            time = t;
        }
    }
    public abstract class Sensor
    {
        private string Id;
        public string GetId()
        {
            return Id;
        }
        public Sensor(string id)
        {
            Id = id;
        }
        public abstract SensorDTO ReadValue(); 
    }

    public abstract class SensorProvider
    {
        public abstract Sensor CreateSensor();
    }

    public interface ISensorReader
    {
        public SensorDTO ReadBySensorId(string id);
        public List<SensorDTO> ReadAllSensors();
    }
}
