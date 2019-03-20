using UnityEngine;
using System.Collections;
using ChartAndGraph;

public class StreamingGraph : MonoBehaviour
{

    public GraphChart Graph;
    public Data_Aquisition AccelInfo = new Data_Aquisition();
    public int TotalPoints = 5;
    float lastTime = 0f;
    float lastX = 0f;
    private float Timer = 0.001f;
    private float X = 1f;

    void Start()
    {
        AccelInfo.Begin("192.168.4.1", 80);
        if (Graph == null) // the ChartGraph info is obtained via the inspector
            return;
        float x = 3f * TotalPoints;
        Graph.DataSource.StartBatch(); // calling StartBatch allows changing the graph data without redrawing the graph for every change
        Graph.DataSource.ClearCategory("EMG1"); // clear the "Player 1" category. this category is defined using the GraphChart inspector
        Graph.DataSource.ClearCategory("EMG2");
        Graph.DataSource.ClearCategory("EMG3");
        //Graph.DataSource.ClearCategory("Player 2"); // clear the "Player 2" category. this category is defined using the GraphChart inspector

        for (int i = 0; i < TotalPoints; i++)  //add random points to the graph
        {
            Graph.DataSource.AddPointToCategory("EMG1",0, 0); // each time we call AddPointToCategory
            Graph.DataSource.AddPointToCategory("EMG2", 0, 0);
            Graph.DataSource.AddPointToCategory("EMG3", 0, 0);
            //Graph.DataSource.AddPointToCategory("Player 2", 0, 0); // each time we call AddPointToCategory 
            x -= Random.value * 3f;
            lastX = x;
        }

        Graph.DataSource.EndBatch(); // finally we call EndBatch , this will cause the GraphChart to redraw itself
    }

    void Update()
    {
        Timer -= Time.deltaTime;
        if (Timer <= 0f)
        {
            Timer=0.001f;
            //lastX += Random.value * 3f;
            //            System.DateTime t = ChartDateUtility.ValueToDate(lastX);
            Graph.DataSource.AddPointToCategoryRealtime("EMG1", X, AccelInfo.Accelx,0.001f);// each time we call AddPointToCategory 
            Graph.DataSource.AddPointToCategoryRealtime("EMG2", X, AccelInfo.Accely, 0.001f);
            Graph.DataSource.AddPointToCategoryRealtime("EMG3", X, AccelInfo.Accelz, 0.001f);
            //Graph.DataSource.AddPointToCategoryRealtime("Player 2", X, UnityEngine.Random.value*100f,0.01f); // each time we call AddPointToCategory
            X++;
        }

    }
}
