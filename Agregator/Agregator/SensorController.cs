using System;
using Sensor;

namespace Agregator {
    public class SensorController {
        private ISensorReader SensorReader;
        public SensorController( ISensorReader reader) {
            SensorReader = reader;
        }
        public SensorDTO ReadSensorData(string id) {
            return SensorReader.ReadBySensorId( id );
        }
    }
    public class Agregator {
        private SensorController Sensors;
        private string Id;
        public Agregator( string id, SensorController controller ) {
            Id = id;
            Sensors = controller;
        }
    }
}
