using System.IO.Ports;


List<string> ports = new List<string>();
PortsRead();
PortsOpen();
void PortsRead(){
    
    foreach (var item in SerialPort.GetPortNames())
    {
        ports.Add(item);
    }

}

void PortsOpen() { 
    SerialPort port1 = new SerialPort() { PortName = ports[0], BaudRate=9600 };
    port1.Open();
    SerialPort port2 = new SerialPort() { PortName= ports[1], BaudRate=9600 };
    port2.Open();
    SerialPort port3 = new SerialPort() { PortName = ports[2], BaudRate = 9600 };
    port3.Open();
    SerialPort port4 = new SerialPort() { PortName = ports[3], BaudRate = 9600 };
    port4.Open();


    for (; ; )
    {
        if (port1.IsOpen)
        {
            string UId = port1.ReadLine();
            if (UId.Length==0)
            {
                continue;
            }
            else
            {
                Console.WriteLine(UId);
                UIdControl(UId);
            }
        }
        if (port2.IsOpen)
        {
            string UId = port1.ReadLine();
            if (UId.Length == 0)
            {
                continue;
            }
            else
            {
                Console.WriteLine(UId);
                UIdControl(UId);
            }
        }
        if (port3.IsOpen)
        {
            string UId = port1.ReadLine();
            if (UId.Length == 0)
            {
                continue;
            }
            else
            {
                Console.WriteLine(UId);
                UIdControl(UId);
            }
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
                UIdControl(UId);
            }
        }
    }
}

bool UIdControl(string UId)
{
    return true;
}