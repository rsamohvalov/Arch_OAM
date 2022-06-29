using System;
using Microsoft.EntityFrameworkCore;
using Users;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Collections.Generic;
using Sensors;
using Agregator;


namespace ConsoleEF {


    class Program {

        static void PrintList( List<string> list ) {
            foreach(string s in list ) {
                Console.WriteLine( s );
            }
            Console.WriteLine( "finished" );
        }

        static void Main( string[] args ) {
                        
            IUserRepository userRepository = new SqlUserRepository( "Server=(localdb)\\mssqllocaldb;Database=HWDb;Trusted_Connection=True;" );

            PrintList( userRepository.PrintUsers() );

            SensorInDb pressureSensor1 = new SensorInDb( "Pressure Sensor Type 1" );
            pressureSensor1.Read();
            pressureSensor1.Read();
            pressureSensor1.Read();

            SensorInDb temperatureSensor1 = new SensorInDb( "Temperature Sensor Type X" );
            temperatureSensor1.Read();
            temperatureSensor1.Read();
            temperatureSensor1.Read();

            AggregateInDb aggregate = new AggregateInDb();
            aggregate.AddSensor( pressureSensor1 );
            aggregate.AddSensor( temperatureSensor1 );

            List<AggregateInDb> aggregators = new List<AggregateInDb>();
            aggregators.Add( aggregate );

            User user = new User( new UserInfo( "Вася", "Иванов", "v.i@оаm.ru" ),
                                  new Credential( "VIvanov", "12345" ),
                                  new Operator(aggregators) );
            userRepository.AddUser( user );

            PrintList( userRepository.PrintUsers() );

            var Vasia = userRepository.Login( "VIvanov", "12345" );

            PrintList( userRepository.PrintUsers() );

            userRepository.Delete( Vasia );

            PrintList( userRepository.PrintUsers() );
        }
    }
}
