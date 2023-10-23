using Newtonsoft.Json;
using SerialPortComApp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;

namespace SerialPortCommunication
{

    internal class Program
    {

        static void Main(string[] args)
        {
            List<string> ports = new List<string>();

            Console.WriteLine("Lutfen 20 saniye icinde usb baglantisini saglayiniz.");
            Thread.Sleep(20000);
            GetPortNames();
            List<SerialPort> serialPorts = new List<SerialPort>();

            Console.WriteLine("port isimleri okunuyor");

            PortsOpen();

            PortsRead();

            void GetPortNames()
            {
                ports.Add("/dev/ttyUSB0");
                ports.Add("/dev/ttyUSB1");
                ports.Add("/dev/ttyUSB2");
                ports.Add("/dev/ttyUSB3");
                ports.Add("/dev/ttyUSB4");
                ports.Add("/dev/ttyUSB5");

                Console.WriteLine("port name /dev/ttyUSB");
            }

            void PortsOpen()
            {
                SerialPort port1 = new SerialPort() { PortName = ports[0], BaudRate = 115200, WriteTimeout = 600, ReadTimeout = 600 };
                SerialPort port2 = new SerialPort() { PortName = ports[1], BaudRate = 115200, WriteTimeout = 600, ReadTimeout = 600 };
                SerialPort port3 = new SerialPort() { PortName = ports[2], BaudRate = 115200, WriteTimeout = 600, ReadTimeout = 600 };
                SerialPort port4 = new SerialPort() { PortName = ports[3], BaudRate = 115200, WriteTimeout = 600, ReadTimeout = 600 };
                SerialPort port5 = new SerialPort() { PortName = ports[4], BaudRate = 115200, WriteTimeout = 600, ReadTimeout = 600 };
                SerialPort port6 = new SerialPort() { PortName = ports[5], BaudRate = 115200, WriteTimeout = 600, ReadTimeout = 600 };

                serialPorts.Add(port1);
                serialPorts.Add(port2);
                serialPorts.Add(port3);
                serialPorts.Add(port4);
                serialPorts.Add(port5);
                serialPorts.Add(port6);
                Console.WriteLine("ports are created");

            }



            void Read(SerialPort item)//, SerialPort port3)//, SerialPort port4)
            {

                if (!item.IsOpen)
                {
                    Console.WriteLine("port opening");
                    item.Open();
                    item.RtsEnable = true;
                    item.DtrEnable = true;

                }


                string UId = string.Empty;

                try
                {
                    Thread.Sleep(200);
                    UId = item.ReadLine(); // Wait for data reception

                    if (UId.Length != 0)
                    {
                        Console.WriteLine(UId);
                        var value = UId.Split(',').ToList();

                        if (UIdControl(value[0], value[1]).Result)
                        {
                            item.WriteLine("true.");

                        }
                        else
                        {
                            item.WriteLine("false.");
                        }


                        UId = "";
                    }

                    //item.Close();

                }
                catch (TimeoutException Ex)//Catch Time out Exception
                {
                    //item.Close();
                    //Console.WriteLine(Ex.Message);

                }




            }







            async Task<bool> UIdControl(string UId,string doorId)
            {
                string[] value = UId.Split(',');

                using (var client = new HttpClient())
                {

                    var res = client.GetAsync($"https://localhost:7089/api/Validates/validate?UId={UId}&doorId={doorId}");

                    var jsonString = await res.Result.Content.ReadAsStringAsync();
                    var validateResult= JsonConvert.DeserializeObject<CardValidateResult>(jsonString);
                    if (res.Result.StatusCode==HttpStatusCode.BadRequest||validateResult==null||!validateResult.success)
                    {
                        Console.WriteLine("Permisson Denied");
                        return false;
                    }
                    else if(validateResult.success){
                        Console.WriteLine("Door opening");
                        return true;
                    }
                    return false;

                }
            }


            void PortsRead()
            {

                while (true)
                {
                    foreach (var item in serialPorts)
                    {
                        Read(item);
                    }

                }

            }

        }
    }
}