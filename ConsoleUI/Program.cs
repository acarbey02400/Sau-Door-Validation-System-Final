// See https://aka.ms/new-console-template for more information
using Business.Concrete;
using Core.Entities.Concrete;
using Core.Utilities;
using DataAccess.Concrete;
using Entities.Concrete;
using System.IO;
using System.IO.Ports;


//UserValidationDoorManager manager = new UserValidationDoorManager(new UserValidationDoorDal(), new DoorRoleManager(new DoorRoleDal()));

//var result= manager.Validate("34 75 193 75", 7);

//Console.WriteLine(result.Message);

//string[] ports = SerialPort.GetPortNames();
//string[] data = { };
//string UId = "";
//foreach (var item in ports)
//{
//    Console.WriteLine(item);
//}

//SerialPort serialPort = new SerialPort(ports[0], 9600);


//serialPort.Open();
//if (serialPort.IsOpen)
//{

//    UId = serialPort.ReadLine();
//    Console.WriteLine(UId.Substring(0, UId.Length - 1));
//    //var result = verificationManager.Validate(UId.Substring(0, UId.Length - 1), 1, DateTime.Now);
//    if (result.Success) serialPort.Write("1");
//    else serialPort.Write("0");

//    Console.WriteLine(result.Message);

//}
//serialPort.Close();





