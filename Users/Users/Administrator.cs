using System;
using System.Collections.Generic;
using System.Text;

namespace Users {

    public interface IUserRepository {
        public void Insert( User user );
        public void Update( User user );
        public void Delete( User user );
    }
    class Administrator {
        private IUserRepository UserRepository;
    }
}
