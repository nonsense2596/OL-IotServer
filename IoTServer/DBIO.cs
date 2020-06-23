using IoTServerV2.IoTServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoTServerV2
{
    class DBIO
    {
        /// <summary>
        /// A control csomagokat kezeli.
        /// </summary>
        /// <param name="control"></param>
        public static void WriteControlData(string control)
        {
            var controlarray = control.Split(';');
            string cliname = controlarray[0];
            string ipaddress = controlarray[1];   // todo implementalni a kliensben meg itt is
            string runmode = controlarray[2];
            var coords = controlarray[3].Split(',');
            string coordX = coords[0];
            string coordY = coords[1];
            Console.WriteLine(cliname);
            Console.WriteLine(runmode);
            Console.WriteLine(coordX);
            Console.WriteLine(coordY);

            // DBIO HERE
            //var query = from b in db.Sensors orderby b.SensorId select b;

            using (var db = new Model1Context())
            {
               
                if(!db.Sensors.Any(o => o.Name.Equals(cliname))) // UJ SZENZOR hozzaadasa
                {
                    Console.WriteLine("uj sensor"); 
                    var added = new Sensor
                    {
                        Name = cliname,
                        Mode = (runmode.Equals("Static"))?true:false,   // ha static akkor true, ha mobile akkor false
                        IP = ipaddress,
                        CoordX = coordX,
                        CoordY = coordY
                    };
                    db.Sensors.Add(added);
                    db.SaveChanges();
                }
                else // MAR MEGLEVO SZENZOR, ha a kommunikacio kozben romlott volna el valami
                {
                    Console.WriteLine("duplicatebaszod"); 
                }

                    
            }


        }
        /// <summary>
        /// A tényleges data adatokat kezeli.
        /// </summary>
        /// <param name="data"></param>
        public static void WriteDataData(string data)
        {
            Console.WriteLine("writedatalol");
            var dataarray = data.Split(';');
            bool IsStatic = (dataarray.Count()==4);

            string cliname = dataarray[0];
            string ipaddr = dataarray[1];
            string datetime = dataarray[2];

            if (!DataExists(cliname, datetime))
            {
                Console.WriteLine("kex");
                // ha static akkor ez az ag
                if (IsStatic)
                {
                    string pm10 = dataarray[3];
                    using (var db = new Model1Context())
                    {
                        var query = from s in db.Sensors where s.Name == cliname select s.SensorId;
                        int sensorid = query.First();

                        var added = new DataS {
                            PM10 = Int32.Parse(pm10),
                            SensorId = sensorid,
                            Date = datetime
                        };
                        db.DataSs.Add(added);
                        db.SaveChanges();
                        Console.WriteLine("db S mentett bastya, udv SAndor");
                    }
                }
                // ha mobile akkor ez az ag
                else
                {
                    var coords = dataarray[3].Split(',');
                    string coordX = coords[0];
                    string coordY = coords[1];
                    string pm10 = dataarray[4];
                    using (var db = new Model1Context())
                    {
                        var query = from s in db.Sensors where s.Name == cliname select s.SensorId;
                        int sensorid = query.First();

                        var added = new DataM
                        {
                            PM10 = Int32.Parse(pm10),
                            SensorId = sensorid,
                            Date = datetime,
                            CoordX = coordX,
                            CoordY = coordY
                        };
                        db.DataMs.Add(added);
                        db.SaveChanges();
                        Console.WriteLine("db M mentett bastya, udv SAndor");
                    }

                }
            }
            else
            {

            }

        }
        // ha nem letezik ilyen meresi eredmeny
        public static bool DataExists(string cliname, string datetime)
        {
            using (var db = new Model1Context())
            {
                var query = from s in db.Sensors where s.Name == cliname select s.SensorId;
                int sensorid = query.First();
                var query1 = from s in db.DataMs where s.SensorId == sensorid && s.Date == datetime select s;
                var exists1 = query1.Any();
                var query2 = from s in db.DataSs where s.SensorId == sensorid && s.Date == datetime select s;
                var exists2 = query2.Any();
                Console.WriteLine("exists1:" + exists1 + " exists2:" + exists2);
                if (!exists1 && !exists2)
                {
                    return false;
                }
                return true;
            }

        }
    }
}
