using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class AccelTiltNotUsed : MonoBehaviour
{
    public Data_Aquisition AccelInfo;
    public float Ax=0.0f, Ay=0.0f, Az=0.0f, Gx=0.0f, Gy=0.0f, Gz=0.0f;
    public float initAx, initAy, initAz, initGx, initGy, initGz;
    private Quaternion localRotation;
    private Quaternion calibrateRotation;
    public float speed = 1.0f;
    private Quaternion rot;
    public float AccelerometerUpdateInterval = 1f / 60f;
    public float LowPassKernelWidthInSeconds = 1f;
    Vector3 lowPassValue = Vector3.zero;
    public Quaternion initRotation;
    public Vector3 initpos;
    public int filterWindowSize = 5;
    private Queue<Vector3> filter;
    public float LowPassFilterFactor = 0.2f;
    public float filteredXAccel = 0, filteredYAccel = 0, filteredZAccel = 0;
    public float filteredXGyro = 0, filteredYGyro = 0, filteredZGyro = 0;
    public float cutoff = 0.1f;
    public float cutoff1 = 0f;
    public float acceldiff = 0.1f;
    public Vector3 accelinputprev;
    public float filteredAngleX = 0;
    public float filteredAngleY = 0;
    public float filteredAngleZ = 0;
    public float predgx;
    public float predaccx;
    public float predgz;
    public float predaccz;
    public Vector3 filtvect;



    // Start is called before the first frame update
    void Start()
    {
        // copy the rotation of the object itself into a buffer
        initAx = AccelInfo.Accelx;
        initAy = AccelInfo.Accely;
        initAz = AccelInfo.Accelz;
        initGx = AccelInfo.Gyrox;
        initGy = AccelInfo.Gyroy;
        initGz = AccelInfo.Gyroz;
        //Vector3 accelerationSnapshot = new Vector3(Ax, Ay, Az);
        //Vector3 accelerationSnapshot = new Vector3(Gz, Gy, Gx);
        //initRotation = transform.rotation;
        initpos = transform.position;
        //Quaternion rotateQuaternion = Quaternion.FromToRotation(new Vector3(0.0f, 0.0f, 0.0f), accelerationSnapshot);
        //calibrateRotation = Quaternion.Inverse(rotateQuaternion);
        ////initpos = new Vector3(-14.54f, -8.46f, 51.38f);
        ////rot = new Quaternion(0, 0, 1, 0);
        filter = new Queue<Vector3>();
    }

    // Update is called once per frame
    void Update()
    {
        //float LowPassFilterFactor = AccelerometerUpdateInterval / LowPassKernelWidthInSeconds; // tweakable

        //MultiplyGyro();
        //initpos = transform.position;
        //initRotation = transform.rotation;
        GetIMU();
        //Az = ((float)Math.Atan2(AccelInfo.Accely, AccelInfo.Accelz) + (float)Math.PI);// * 57.295779513082320876798154814105f; //*0.01f + Ax*0.99f;
        //Ax = AccelInfo.Accelx;
        //Ay = AccelInfo.Accely;//* 0.1f + Ay * 0.9f;
        ////Ax = ((float)Math.Atan2(AccelInfo.Accelx, AccelInfo.Accelz) + (float)Math.PI);// * 57.295779513082320876798154814105f; //* 0.01f + Az * 0.99f;
        //Az = AccelInfo.Accelz;
        //Gx = Gx*Time.deltaTime; //* 0.01f + Gx * 0.99f;
        //Gy = Gy*Time.deltaTime; //* 0.01f + Gy * 0.99f;
        //Gz = Gz*Time.deltaTime; //* 0.01f + Gz * 0.99f;

        //if (Math.Abs(filteredXAccel - Ax) < cutoff)
        //{
        //    Ax = filteredXAccel;
        //}
        
        //if (Math.Abs(filteredYAccel - Ay) < 0.05)
        //{
        //    Ay = filteredYAccel;
        //}
        
        //if (Math.Abs(filteredZAccel - Az) < cutoff)
        //{
        //    Az = filteredZAccel;
        //}
        
        //if (Math.Abs(filteredXGyro - Gx) < cutoff)
        //{
        //    Gx = filteredXGyro;
        //}
        
        //if (Math.Abs(filteredYGyro - Gy) < cutoff)
        //{
        //    Gy = filteredYGyro;
        //}
        
        //if (Math.Abs(filteredZGyro - Gz) < cutoff)
        //{
        //    Gz = filteredZGyro;
        //}

        //Vector3 accelinput = new Vector3(Ax, Ay, Az);
        //Vector3 gyroinput = new Vector3(Gx, Gy, Gz);

        //filter.Enqueue(accelinput);
        //if (filter.Count > filterWindowSize)
        //    filter.Dequeue();

        //float totalX = 0, totalY = 0, totalZ = 0;
        //foreach (Vector3 acc in filter)
        //{
        //    totalX += acc.x;
        //    totalY += acc.y;
        //    totalZ += acc.z;
        //}
        ////filteredXAccel = (float)Math.Round((double)totalX / filter.Count, 1);
        ////filteredYAccel = (float)Math.Round((double)totalY / filter.Count, 1);
        ////filteredZAccel = (float)Math.Round((double)totalZ / filter.Count, 1);
        //filteredXAccel = totalX / filter.Count;
        //filteredYAccel = totalY / filter.Count;
        //filteredZAccel = totalZ / filter.Count;

        //filter.Enqueue(gyroinput);
        //if (filter.Count > filterWindowSize)
        //    filter.Dequeue();

        //totalX = 0; totalY = 0; totalZ = 0;
        //foreach (Vector3 gyro in filter)
        //{
        //    totalX += gyro.x;
        //    totalY += gyro.y;
        //    totalZ += gyro.z;
        //}
        ////filteredXGyro = (float)Math.Round((double)totalX / filter.Count, 1);
        ////filteredYGyro = (float)Math.Round((double)totalY / filter.Count, 1);
        ////filteredZGyro = (float)Math.Round((double)totalZ / filter.Count, 1);
        //filteredXGyro = totalX / filter.Count;
        //filteredYGyro = totalY / filter.Count;
        //filteredZGyro = totalZ / filter.Count;

        //fixedaccelinput = c
        //lowPassValue = Vector3.Slerp(lowPassValue, accelinput, LowPassFilterFactor);

        // find speed based on delta
        float curSpeed = Time.deltaTime * speed;
        // first update the current rotation angles with input from acceleration axis
        //localRotation.x += filteredXAccel* curSpeed;
        //localRotation.y += filteredYAccel* curSpeed;
        //localRotation.z += filteredZAccel * curSpeed;
        //localRotation.x = filteredXGyro * curSpeed;
        //localRotation.y = filteredYGyro * curSpeed;
        //localRotation.z = filteredZGyro * curSpeed;
        //localRotation = Quaternion.Euler(Gx*curSpeed, Gy*curSpeed, Gz*curSpeed);

        predgx = (Gx / speed)* Time.deltaTime;
        predaccx = (float)Math.Atan2(Ay, Az) * (180f / (float)Math.PI) *Time.deltaTime*Time.deltaTime;
        filteredAngleX = (0.98f *(predgx))+ (0.02f*(predaccx));
        //filteredAngleY = 0.98f * (filteredAngleY + Gy) + 0.02f * (Ay);
        if (filteredAngleX > -0.005f && filteredAngleX < 0.005f)
        {
            filteredAngleX = 0f;
        }

        predgz = (Gz / speed) * Time.deltaTime;
        predaccz = (float)Math.Atan2(Ay, Ax) * (180f / (float)Math.PI)*Time.deltaTime*Time.deltaTime;
        filteredAngleZ = (0.98f * (predgz)) +(0.02f * (predaccz));
        if (filteredAngleZ > -0.05f && filteredAngleZ < 0.05f)
        {
            filteredAngleZ = 0f;
        }

        filtvect = new Vector3(filteredAngleX, 0, filteredAngleZ).normalized;
        // then rotate this object accordingly to the new angle
        //transform.RotateAround(initpos,transform.forward, Gz*curSpeed); //* rot;
        //transform.RotateAround(initpos,transform.right, Gx * curSpeed);
        //transform.rotation = calibrateRotation*localRotation;
        //transform.rotation = localRotation;
        //transform.rotation = 
        //transform.Rotate(0.98f*(transform.eulerAngles.x+Gx*Time.deltaTime)+(0.02f*Ax), 0, 0.98f*(transform.eulerAngles.z+Gz*Time.deltaTime)+(0.02f*Az));
        //transform.Rotate(filteredAngleX, filteredAngleY, filteredAngleZ);
        //if (Math.Abs(accelinputprev.magnitude - accelinput.magnitude) > acceldiff)
        //{
        //transform.localRotation = Quaternion.Slerp(transform.localRotation, Quaternion.Euler(new Vector3((transform.rotation.x+Gx*Time.deltaTime),181.149f,(transform.rotation.z+Gz*Time.deltaTime))), LowPassFilterFactor);
        //}
        //transform.rotation = Quaternion.Slerp(transform.rotation,localRotation, LowPassFilterFactor);
        //float prevX = filteredXGyro;
        //float prevZ = filteredYGyro;

        //if (Math.Abs(filteredXGyro-prevX) < cutoff)
        //{
        //    transform.rotation = initRotation;
        //    transform.position = initpos;
        //}
        //else
        //{
        transform.RotateAround(transform.position, Vector3.right, filteredAngleX);
        transform.RotateAround(transform.position, Vector3.forward, filteredAngleZ);
        //}




    //accelinputprev = accelinput;
}
    public Vector3 RotatePointAroundPivot(Vector3 point, Vector3 pivot, Vector3 angles)
    {
        Vector3 dir = point - pivot; // get point direction relative to pivot
        dir = Quaternion.Euler(angles) * dir; // rotate it
        point = dir + pivot; // calculate rotated point
        return point; // return it
    }

    private void GetIMU()
    {
        if (AccelInfo.Gyrox < -cutoff || AccelInfo.Gyrox > cutoff)
        {
            //If the gyro value is between these two values, then keep it still by multiplying it with 0.
            Gx = AccelInfo.Gyrox;
        }
        else
        {
            Gx = 0f;
        }

        if (AccelInfo.Gyroy < -cutoff || AccelInfo.Gyroy > cutoff)
        {
            //If the gyro value is between these two values, then keep it still by multiplying it with 0.
            Gy = AccelInfo.Gyroy;
        }
        else
        {
            
            Gy = 0f;
        }

        if (AccelInfo.Gyroz < -cutoff || AccelInfo.Gyroz > cutoff)
        {
            //If the gyro value is between these two values, then keep it still by multiplying it with 0.
            Gz = AccelInfo.Gyroz;
        }
        else
        {
            Gz = 0f;
        }
        if (AccelInfo.Accelx < -cutoff1 || AccelInfo.Accelx > cutoff1)
        {
            //If the gyro value is between these two values, then keep it still by multiplying it with 0.
            Ax = AccelInfo.Accelx;
        }
        else
        {
            Ax = 0f;
        }

        if (AccelInfo.Accely < -cutoff1 || AccelInfo.Accely > cutoff1)
        {
            //If the gyro value is between these two values, then keep it still by multiplying it with 0.
            Ay = AccelInfo.Accely;
        }
        else
        {
            Ay = 0f;
        }

        if (AccelInfo.Accelz < -cutoff1 || AccelInfo.Accelz > cutoff1)
        {
            //If the gyro value is between these two values, then keep it still by multiplying it with 0.
            Az = AccelInfo.Accelz;
        }
        else
        {
            Az = 0f;
        }
    }
}
