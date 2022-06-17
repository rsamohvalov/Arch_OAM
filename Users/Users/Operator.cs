using System;
using System.Collections.Generic;
using Agregators;
using Sensors;

namespace Users {
    public interface ISensorReadRepository {
        public List<SensorDTO> Read( string id, DateTime start, DateTime end );
    }

    
    public class Operator : User {
        private List<Agregator> AgregatorList;
        private ISensorReadRepository SensorDBReader;
    }
}