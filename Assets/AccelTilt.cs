using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class AccelTilt : MonoBehaviour
{
    public Data_Aquisition AccelInfo;
    public float pitch = 0.0f, roll = 0.0f, yaw = 0.0f;
    public float speed = 3.3f;
    public float cutoff = 0.1f;
    public float cutoff1 = 0f;
    public Quaternion rotOffset = Quaternion.identity;




    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        yaw = AccelInfo.Accelx;
        pitch = AccelInfo.Accely;
        roll = AccelInfo.Accelz;



        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(roll-90, 0f, -pitch + 180), Time.deltaTime * speed);
        
    }
}

   
