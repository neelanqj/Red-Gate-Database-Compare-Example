// using RedGate.Shared.SQL;
using RedGate.SQLCompare.Engine;
using RedGate.SQLCompare.Engine.Filter;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedGateExample
{
    class CompareTwoDatabasesExample
    {
        public void RunExample()
        {
            using (Database stagingDB = new Database(), productionDB = new Database())
            {
                ConnectionProperties sourceConnectionProperties = Program.StagingConnectionProperties;
                ConnectionProperties targetConnectionProperties = Program.ProductionConnectionProperties;


                Console.WriteLine("Registering database " + sourceConnectionProperties.DatabaseName);
                try
                {
                    stagingDB.Register(sourceConnectionProperties, Options.Default);
                }
                catch (SqlException e)
                {
                    //e.WarnUserAboutDatabaseRegistryFailure(sourceConnectionProperties);
                    return;
                }


                Console.WriteLine("Registering database " + targetConnectionProperties.DatabaseName);
                try
                {

                    productionDB.Register(targetConnectionProperties, Options.Default);
                }
                catch (SqlException e)
                {
                    //e.WarnUserAboutDatabaseRegistryFailure(targetConnectionProperties);
                    return;
                }



                // Compare WidgetStaging against WidgetProduction
                Differences stagingVsProduction = stagingDB.CompareWith(productionDB, Options.Default);

                // Display the results on the console
                foreach (Difference difference in stagingVsProduction)
                {
                    Console.WriteLine("{0} {1} {2}", difference.Type, difference.DatabaseObjectType, difference.Name);
                }
            }
        }
    }
}
