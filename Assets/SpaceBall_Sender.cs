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
    private int databuffer;
    public Level_Manager difficulty;
    public void Calibrate()
    {
        Debug.Log("done");
        //data = "001";
        //BeginSendData("10.17.100.240", 80);

    }

    public void RollLeft()
    {
        data = "101";
        BeginSendData("10.17.100.240", 80);

    }

    public void RollRight()
    {
        data = "201";
        BeginSendData("10.17.100.240", 80);

    }

    public void PitchUp()
    {
        data = "301";
        BeginSendData("10.17.100.240", 80);

    }

    public void PitchDown()
    {
        data = "401";
        BeginSendData("10.17.100.240", 80);

    }

    public void RandomMovement()
    {
        bool same = true;
        int direction = Random.Range(1, 5);
        int Tens_movement = Random.Range(0, 3);
        int Ones_movement = Random.Range(1, 9);
        while (same)
        {
            if (difficulty.level == 1)
            {
                direction = Random.Range(1, 3);
                Tens_movement = Random.Range(0, 1);
                Ones_movement = Random.Range(0, 10);

                if (direction == databuffer)
                {
                    direction = Random.Range(1, 3);

                }
                else { same = false; }

            }
            if (difficulty.level == 2)
            {
                direction = Random.Range(1, 5);
                Tens_movement = Random.Range(0, 1);
                Ones_movement = Random.Range(0, 10);
                if (direction == databuffer)
                {
                    direction = Random.Range(1, 5);

                }
                else { same = false; }

            }
            if (difficulty.level == 3 || difficulty.level == 4)
            {
                direction = Random.Range(1, 5);
                Tens_movement = Random.Range(0, 3);
                Ones_movement = Random.Range(0, 10);
                if (direction == databuffer)
                {
                    direction = Random.Range(1, 5);

                }
                else { same = false; }
            }
        }
        data = direction.ToString() + Tens_movement.ToString() + Ones_movement.ToString();
        databuffer = direction;
        Debug.Log(data);
        BeginSendData("10.17.100.240", 80);

    }

    public void BeginSendData(string IP, int Port)
    {
        
            // Declaring Client
            var client = new TcpClient();

            // Creating Client on specified IP adress and Port
            client.Connect(IP, Port);

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
