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
