using System;
using System.Collections.Generic;
using System.Text;
using Sensors;

namespace Agregator {
    public class AggregateInDb {
        public int AggregateInDbId { get; set; }
        public List<SensorInDb> Sensors;
        public AggregateInDb() {
            Sensors = new List<SensorInDb>();
        }
        public AggregateInDb( List<SensorInDb> sensors ) {
            Sensors = sensors;
        }
        public void AddSensor( SensorInDb sensor ) {
            Sensors.Add( sensor );
        }
    }
}
