using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Globalization;
using UnityEngine;

[System.Serializable]
public class Data_Aquisition : MonoBehaviour
{
    public float Accelx;
    public float Accely;
    public float Accelz;
    public float EMGleftRA, EMGrightRA, EMGleftOb, EMGrightOb, EMGerect;
    public TcpClient client;
    private FilterData filt = new FilterData();
    FilterData.IIRFilter LAnotch60, RAnotch60, LOnotch60, ROnotch60, ERnotch60;
    FilterData.IIRFilter LAhp, RAhp, LOhp, ROhp, ERhp;
    FilterData.IIRFilter LAlp, RAlp, LOlp, ROlp, ERlp;
    public List<PointData> EMGdata = new List<PointData>();
    PointData temppoints;

    public struct PointData
    {
        public float EMGleftRA;
        public float EMGrightRA;
        public float EMGleftOb;
        public float EMGrightOb;
        public float EMGerect;
    }


    // Start is called before the first frame update
    public void Begin(string IP, int Port)
    {
        var thread = new Thread(() =>
        {
            // Declaring Client
            client = new TcpClient();
            LAnotch60 = new FilterData.IIRFilter(2000, 60, 5);
            RAnotch60 = new FilterData.IIRFilter(2000, 60, 5);
            LOnotch60 = new FilterData.IIRFilter(2000, 60, 5);
            ROnotch60 = new FilterData.IIRFilter(2000, 60, 5);
            ERnotch60 = new FilterData.IIRFilter(2000, 60, 5);
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
                    float EMGleftRA = float.Parse(all_data[0], CultureInfo.InvariantCulture.NumberFormat);
                    float EMGrightRA = float.Parse(all_data[1], CultureInfo.InvariantCulture.NumberFormat);
                    float EMGleftOb = float.Parse(all_data[2], CultureInfo.InvariantCulture.NumberFormat);
                    float EMGrightOb = float.Parse(all_data[3], CultureInfo.InvariantCulture.NumberFormat);
                    float EMGerect = float.Parse(all_data[4], CultureInfo.InvariantCulture.NumberFormat);
                    Accelx = float.Parse(all_data[5], CultureInfo.InvariantCulture.NumberFormat);
                    Accely = float.Parse(all_data[6], CultureInfo.InvariantCulture.NumberFormat);
                    Accelz = float.Parse(all_data[7], CultureInfo.InvariantCulture.NumberFormat);
                    //no need for gyro as accel and gyro is combined in arduino
                    //Gyrox = float.Parse(all_data[8], CultureInfo.InvariantCulture.NumberFormat);
                    //Gyroy = float.Parse(all_data[9], CultureInfo.InvariantCulture.NumberFormat);
                    //Gyroz = float.Parse(all_data[10], CultureInfo.InvariantCulture.NumberFormat);

                    buffer.Clear();

                    temppoints.EMGleftRA = filt.Filter(EMGleftRA, LAnotch60);
                    temppoints.EMGrightRA = filt.Filter(EMGrightRA, RAnotch60);
                    temppoints.EMGleftOb = filt.Filter(EMGleftOb, LOnotch60);
                    temppoints.EMGrightOb = filt.Filter(EMGrightOb, ROnotch60);
                    temppoints.EMGerect = filt.Filter(EMGerect, ERnotch60);

                    //temppoints.EMGleftRA = EMGleftRA_i;
                    //temppoints.EMGrightRA = EMGrightRA_i;
                    //temppoints.EMGleftOb = EMGleftOb_i;
                    //temppoints.EMGrightOb = EMGrightOb_i;
                    //temppoints.EMGerect = EMGerect_i;

                    lock (EMGdata)
                    {
                        EMGdata.Add(temppoints);
                        Debug.Log("Placed in list");
                    }
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
