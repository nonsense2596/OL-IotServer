using NetMQ;
using NetMQ.Sockets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IoTServerV2
{
    class Program
    {
        static void Main(string[] args)
        {
            /*using (var receiver = new PullSocket("@tcp://localhost:5558"))
            {
                while (true)
                {
                    string inp = receiver.ReceiveFrameString();
                    Console.WriteLine("Received data:");
                    Console.WriteLine(inp);
                }
            }*/
            Console.WriteLine("bef comm");
            Communicator communicator = new Communicator();
            Console.WriteLine("aft comm");
            //Console.WriteLine(DateTime.Now.ToString());


            /*using (var db = new Model1Context())
            {
                var query = from s in db.Sensors where s.Name == "kQMYcza8CUOjN3PwqhLPvQ" select s.SensorId;
                int sensorid = query.First();
                Console.WriteLine(sensorid);
                var query2 = from s in db.DataMs where s.SensorId == sensorid && s.Date == "25/04/2020 15:22:55" select s;
                var exists1 = query2.Any();
                Console.WriteLine(exists1);

            }/*



            /*using(var db = new Model1Context())
            {
                var snsr = new Sensor
                {
                    Name = "asd",
                    Mode = false,
                    IP = "77.77.44.55",
                    CoordX = "45.23",
                    CoordY = "59.41"
                };
                db.Sensors.Add(snsr);
                db.SaveChanges();
                var query = from b in db.Sensors orderby b.SensorId select b;
                foreach (var item in query)
                {
                    Console.WriteLine(item.SensorId + " " + item.Name);
                }
            }*/


            /*using(var db = new Model1Context())
            {
                var snsr = new Sensor
                {
                    Name = "tesztautoinkr",
                    Mode = false,
                    IP = "5.6.7.8",
                    LastData = DateTime.Now
                };
                db.Sensors.Add(snsr);
                db.SaveChanges();
                for(int i = 0; i < 100; i++)
                {
                    Console.Clear();
                    var query = from b in db.Sensors orderby b.SensorId select b;
                    foreach (var item in query)
                    {
                        Console.WriteLine(item.SensorId + " " + item.Name);
                    }
                    Thread.Sleep(3000);
                }

            }*/

            Console.WriteLine("lol");
            Console.ReadKey();
        }
    }
}
