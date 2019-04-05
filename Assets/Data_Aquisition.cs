using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Globalization;
using UnityEngine;

public class Data_Aquisition : MonoBehaviour
{
    public float Accelx , Gyrox;
    public float Accely , Gyroy;
    public float Accelz , Gyroz;
    public float EMGleftRA,EMGrightRA,EMGleftOb,EMGrightOb,EMGerect;
    public TcpClient client;
    

    // Start is called before the first frame update
    public void Begin(string IP, int Port)
    {
        var thread = new Thread(() =>
        {
            // Declaring Client
            client = new TcpClient();

            // Creating Client on specified IP adress and Port
            client.Connect(IP, Port);
            //if (client.Connected != true)
            //{
            //    Debug.Log("Network Not Found");
            //    return;
            //}

            var stream = new StreamReader(client.GetStream());

            //Declaring Temporary Buffer
            var buffer = new List<byte>();

            while (client.Connected)
            {
                // Reads data stream
                var data = stream.Read();

                if (data == 13)
                {
                    // Converting Incoming ASCII Values to string
                    var incommingData = Encoding.ASCII.GetString(buffer.ToArray());
                    // Display Data
                    Debug.Log("Data Recieved:" + incommingData);
                    // Spliting Data into appropriate variables
                    string[] all_data = incommingData.Split(',');
                    
                    // Conerting String to Float data
                    EMGleftRA = float.Parse(all_data[0], CultureInfo.InvariantCulture.NumberFormat);
                    EMGrightRA = float.Parse(all_data[1], CultureInfo.InvariantCulture.NumberFormat);
                    EMGleftOb = float.Parse(all_data[2], CultureInfo.InvariantCulture.NumberFormat);
                    EMGrightOb = float.Parse(all_data[3], CultureInfo.InvariantCulture.NumberFormat);
                    EMGerect = float.Parse(all_data[4], CultureInfo.InvariantCulture.NumberFormat);
                    Accelx = float.Parse(all_data[5], CultureInfo.InvariantCulture.NumberFormat);
                    Accely = float.Parse(all_data[6], CultureInfo.InvariantCulture.NumberFormat);
                    Accelz = float.Parse(all_data[7], CultureInfo.InvariantCulture.NumberFormat);
                    Gyrox = float.Parse(all_data[8], CultureInfo.InvariantCulture.NumberFormat);
                    Gyroy = float.Parse(all_data[9], CultureInfo.InvariantCulture.NumberFormat);
                    Gyroz = float.Parse(all_data[10], CultureInfo.InvariantCulture.NumberFormat);

                    buffer.Clear();

                    
                }
                else
                    // Continue reading incomming data
                    buffer.Add((byte)data);

             

            }

            client.GetStream().Close();
            client.Client.Close();

            

        });
        thread.Start();
    }
}
   