﻿using System;
using System.IO.Ports;

namespace SerialTest
{
    class Program
    {
        static void Main(string[] args)
        {
            SerialPort serial = new SerialPort("COM18");
            serial.Open();

            serial.ReadTimeout = 1000;
            serial.NewLine = "\n";
            serial.DtrEnable = true;

            int cnt = 0;
            while (Console.KeyAvailable == false)
            {
                string data = String.Format("{0}: ", cnt).PadRight(64, 'A');
                Console.WriteLine("Sending {0} bytes:", data.Length + serial.NewLine.Length);
                serial.WriteLine(data);
                try
                {
                    string read = serial.ReadLine();
                    Console.WriteLine(read);
                }
                catch
                {
                    Console.WriteLine("Timeout");
                }
                cnt++;
            }
        }
    }
}