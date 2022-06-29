using System;
using System.Collections.Generic;
using System.Text;

namespace Sensors {
    public class SensorDbValue {
        public int SensorDbValueId { get; set; }
        public SensorInDb Sensor;
        public string Value { get; set; }
        public DateTime Time { get; set; }
        public SensorDbValue() {
            Value = "n/a";
            Time = DateTime.Now;
        }
        public SensorDbValue( string value, DateTime time ) {
            Value = value;
            Time = time;
        }
    }
    public class SensorInDb {
        public int SensorInDbId { get; set; }
        public string Description { get; set; }
        public List<SensorDbValue> SensorValues;
        private Random rand;
        public SensorInDb() {
            SensorValues = new List<SensorDbValue>();
            rand = new Random();
        }
        public SensorInDb( string description ) {
            Description = description;
            SensorValues = new List<SensorDbValue>();
            rand = new Random();
        }
        public SensorInDb( string description, List<SensorDbValue> values ) {
            Description = description;
            SensorValues = values;
            rand = new Random();
        }
        public void Read() {
            SensorValues.Add( new SensorDbValue( rand.Next().ToString(), DateTime.Now ) );
        }
    }
}
