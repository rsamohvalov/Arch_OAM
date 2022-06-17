using System;
using System.Collections.Generic;
using System.Text;
using Agregators;

namespace Users {
    class Technolog {
        private IAgregatorRepository AgregateRepository;
    }

    public interface IAgregatorRepository {
        public void Update( Agregator agregator );
        public void Delete( Agregator agregator );
        public void Create( Agregator agregator );
    }
}
