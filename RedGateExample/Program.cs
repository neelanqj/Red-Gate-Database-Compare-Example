using RedGate.SQLCompare.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedGateExample
{
    class Program
    {
        // To install the databases used in these examples, see the "Getting Started" application under SQL Comparison SDK in the start menu.
        private const string StagingServerName = @"(local)";
        private const string ProductionServerName = StagingServerName;
        private const string StagingDatabaseName = "App_FortressDb";
        private const string ProductionDatabaseName = "App_FortressDb";

       
        //
        // configure Sqlusername & SqlPassword if you wish to use SQL Authentication
        //
                                                                                                            private const string SqlUsername = "Program";
                                                                                                            private const string SqlPassword = "think123";


        static void Main(string[] args)
        {
            CompareTwoDatabasesExample r = new CompareTwoDatabasesExample();

            r.RunExample();
        }

        internal static ConnectionProperties StagingConnectionProperties
        {
            get
            {
                    return new ConnectionProperties(StagingServerName, StagingDatabaseName);
            }
        }


        /// <summary>
        /// Return the connection to Production Database
        /// </summary>
        internal static ConnectionProperties ProductionConnectionProperties
        {
            get
            {
                    return new ConnectionProperties(ProductionServerName, ProductionDatabaseName, SqlUsername,
                        SqlPassword);
            }
        }

    }
}
