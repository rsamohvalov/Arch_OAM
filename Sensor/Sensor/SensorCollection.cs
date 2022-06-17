using System;
using System.Collections.Generic;

namespace Sensors {
    public class SensorCollection : ISensorReader {
        private List<Sensor> SensorsList;
        Random rand;
        public SensorCollection() {
            SensorsList = new List<Sensor>();
        }
        public void AddSensor( SensorProvider Provider, string id ) {
           SensorsList.Add( Provider.CreateSensor( id ) );
        }
        public void AddSensor( SensorProvider Provider ) {
            SensorsList.Add( Provider.CreateSensor( rand.Next().ToString() ) );
        }
        public SensorDTO ReadBySensorId( string id ) {
            foreach( Sensor sensor in SensorsList ) {
                if( sensor.GetId() == id ) {
                    return sensor.ReadValue();
                }
            }
            return null;
        }
        public List<SensorDTO> ReadAllSensors() {
            List<SensorDTO> returnList = new List<SensorDTO>();
            foreach(Sensor sensor in SensorsList) {
                returnList.Add( sensor.ReadValue());                
            }
            return returnList;
        }
    }
}