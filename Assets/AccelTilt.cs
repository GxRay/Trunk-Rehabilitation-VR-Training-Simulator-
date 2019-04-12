using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class AccelTilt : MonoBehaviour
{
    public Data_Aquisition AccelInfo;
    public float pitch = 0.0f, roll = 0.0f, yaw = 0.0f;
    public float speed = 3.2f;
    public float cutoff = 0.1f;
    public float cutoff1 = 0f;
    public Quaternion rotOffset = Quaternion.identity;
    public GameObject LeftRA, RightRA, LeftOb, RightOb, Erect;
    private float previousroll, previouspitch;




    // Start is called before the first frame update
    void Start()
    {
        previousroll = AccelInfo.Accely;
        previouspitch = AccelInfo.Accelz;
    }

    // Update is called once per frame
    void Update()
    {



        yaw = AccelInfo.Accelx;
        roll = AccelInfo.Accely;
        pitch = AccelInfo.Accelz;


        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(pitch + 270, 0f, -roll + 180), Time.deltaTime * speed);



        if (roll-previousroll > 10)
        {
            LeftRA.SetActive(true);
            LeftOb.SetActive(true);
            RightRA.SetActive(false);
            RightOb.SetActive(false);
        }
        
        if (roll-previousroll < -10)
        {
            RightRA.SetActive(true);
            RightOb.SetActive(true);
            LeftRA.SetActive(false);
            LeftOb.SetActive(false);
        }

        //if (pitch < -65)
        //{
        //    Erect.SetActive(true);
        //}

        //if (pitch > )
        //{

        //}

        previousroll=roll;
        previouspitch=pitch;
        
    }
}

   
