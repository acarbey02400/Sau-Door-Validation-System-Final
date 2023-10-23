using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Security.Cryptography;

namespace SerialPortCommunication
{
    internal class Program
    {

        [STAThread]
        static void Main(string[] args)
        {
            string masterCard = "116 30 144 171 ";
            List<string> ports = new List<string>();
            Console.WriteLine("Hello World!");
            GetPortNames();
            PortsOpen();
           // UIdControl("asd1",false);
            void GetPortNames()
            {

                foreach (var item in SerialPort.GetPortNames())
                {
                    ports.Add(item);
                   
                }
                if (ports.Count == 2)
                {
                    return;
                }
                GetPortNames();
            }

            void PortsOpen()
            {
                SerialPort port1 = new SerialPort() { PortName = ports[0], BaudRate = 115200 };
                port1.Open();
                SerialPort port2 = new SerialPort() { PortName = ports[1], BaudRate = 115200 };
                port2.Open();
                //SerialPort port3 = new SerialPort() { PortName = ports[2], BaudRate = 9600 };
                //port3.Open();
                //SerialPort port4 = new SerialPort() { PortName = ports[3], BaudRate = 9600 };
                //port4.Open();

                PortsRead(port1, port2);//, port3);//port4);
                
            }
            void PortsRead(SerialPort port1, SerialPort port2)//, SerialPort port3)//, SerialPort port4)
            {
                for (; ; )
                {
                    if (port1.IsOpen)
                    {
                        
                        string UId = port1.ReadLine();
                        if (UId.Length == 0)
                        {
                            continue;
                        }
                        else
                        {
                            Console.WriteLine(UId);
                            string[] value = UId.Split(',');

                            if (value[0] == masterCard)
                            {
                                AddUId(port1);
                            }
                            else
                            {
                                UIdControl(value[0], false);
                            }
                            UId = "";
                        }
                        port1.ReadExisting();
                    }
                    else
                    {
                        PortsOpen();
                    }
                    if (port2.IsOpen)
                    {
                        string UId = port2.ReadLine();
                        if (UId.Length == 0)
                        {
                            continue;
                        }
                        else
                        {
                            Console.WriteLine(UId);
                            string[] value = UId.Split(',');

                            if (value[0] == masterCard)
                            {
                                AddUId(port2);
                            }
                            else
                            {
                                UIdControl(value[0], false);
                            }
                            UId = "";
                        }
                        port2.ReadExisting();
                    }
                    else
                    {
                        PortsOpen();
                    }
                    /*if (port3.IsOpen)
                    {
                        string UId = port1.ReadLine();
                        if (UId.Length == 0)
                        {
                            continue;
                        }
                        else
                        {
                            Console.WriteLine(UId);
                            string[] value = UId.Split(',');
                            if (value[0] == masterCard)
                            {
                                UIdControl(value[1], true);
                            }
                            else
                            {
                                UIdControl(value[0], false);
                            }
                            UId = "";
                        }
                    }
                    else
                    {
                        PortsOpen();
                    }
                    if (port4.IsOpen)
                    {
                        string UId = port1.ReadLine();
                        if (UId.Length == 0)
                        {
                            continue;
                        }
                        else
                        {
                            Console.WriteLine(UId);
                            string[] value = UId.Split(',');
                            if (value[0] == masterCard)
                            {
                                UIdControl(value[1], true);
                            }
                            else
                            {
                                UIdControl(value[0], false);
                            }
                            UId = "";
                        }
                    }
                    else
                    {
                        PortsOpen();
                    }*/
                }
            }
            bool UIdControl(string UId, bool isNewUId)
            {
               
               
                    List<string> satirlarList = new List<string>();
                    using (StreamReader sr = new StreamReader("data.txt")) 
                    {
                        string satir; //burada okuduğunuz her satırı atamamız için gerekli değişkeni tanımlıyoruz.
                        while ((satir = sr.ReadLine()) != null) //Döngü kurup eğer satır boş değilse, satirlarList List'ine ekleme yapıyoruz.
                        {
                            satirlarList.Add(satir);
                          
                        }
                        sr.Close();
                    }
                    foreach (var item in satirlarList)
                    {
                        if (item==UId)
                        {
                            Console.WriteLine("kapı açıldı");
                            return true;
                            
                        }
                    }
                
                Console.WriteLine("kapı açılamadı");
                return false;
            }

            void AddUId(SerialPort port)
            {
                if (port.IsOpen)
                {
                    string UId = port.ReadLine();
                    string[] val = UId.Split(',');
                    if (UId.Length == 0 || val[0]==masterCard)
                    {
                        UId = "";
                        AddUId(port);
                        
                    }
                    else
                    {
                        
                        string[] value = UId.Split(',');

                        
                        string filelocation = @"./";
                        string filename = "data.txt";
                        if (File.Exists(filelocation + filename))
                        {
                            StreamWriter sw = new StreamWriter(filelocation + filename, true);
                            sw.WriteLine(value[0]);
                            sw.Close();


                            UId = "";
                            port.ReadExisting();
                        }
                        else
                        {
                            // Dosya yok  
                        }
                       
                        
                    }
                }
            }
        }
        

    
    }
}
