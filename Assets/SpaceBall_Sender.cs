using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Globalization;
using UnityEngine;

public class SpaceBall_Sender : MonoBehaviour
{
    public string data;
    public void Calibrate()
    {
        data = "001";
        BeginSendData("192.168.4.1", 80);

    }

    public void RollLeft()
    {
        data = "101";
        BeginSendData("192.168.4.1", 80);

    }

    public void RollRight()
    {
        data = "201";
        BeginSendData("192.168.4.1", 80);

    }

    public void PitchUp()
    {
        data = "301";
        BeginSendData("192.168.4.1", 80);

    }

    public void PitchDown()
    {
        data = "401";
        BeginSendData("192.168.4.1", 80);

    }

    public void BeginSendData(string IP, int Port)
    {
        
            // Declaring Client
            var client = new TcpClient();

            // Creating Client on specified IP adress and Port
            client.Connect(IP, Port);
        //if (client.Connected != true)
        //{
        //    Debug.Log("Network Not Found");
        //    return;
        //}
        while (client.Connected)
        {
            
            var stream = new StreamWriter(client.GetStream());
            stream.WriteLine(data);
            stream.Flush();
        }
        //client.GetStream().Close();
        //client.Close();

    }
}
