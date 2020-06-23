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
    class Communicator
    {
        ResponseSocket receiver;

        public Communicator()
        {
            receiver = new ResponseSocket("@tcp://*:5558");
            Thread t = new Thread(run);
            t.Start();
        }
        public void run()
        {
            while (true)
            {
                string input = receiver.ReceiveFrameString();
                receiver.SendFrame("megkaptambaszod");
                Console.WriteLine(input);
                DataSeparator(input);
            }
        }
        /// <summary>
        /// Elválasztja egymástól a control, illetve a data típusú adatokat
        /// </summary>
        /// <param name="input"></param>
        public void DataSeparator(string input)
        {
            Console.WriteLine("X: " + input);
            var splitinput = input.Split('#');
            var segment = splitinput[1];
            var data = segment.Split(';');
            if (splitinput[0].Equals("data"))
            {
                DBIO.WriteDataData(splitinput[1]);
            }
            if (splitinput[0].Equals("control"))
            {
                DBIO.WriteControlData(splitinput[1]);
            }
        }
    }
}
