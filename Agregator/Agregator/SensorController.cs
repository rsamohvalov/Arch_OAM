using System;
using System.Collections.Generic;
using Sensors;

namespace Agregators {
    public interface ISensorWriteRepository {
        public void Insert( SensorDTO dto );
        public void BulkInsert( List<SensorDTO> DtoList );
        public void Create( Sensor sensor );
    }

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
