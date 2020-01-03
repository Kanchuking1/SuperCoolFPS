using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeReverser : MonoBehaviour
{
    public bool isRewinding = false;
    public int maxNumberOfFramesToRewind = 100;

    List<PointInTime> pointsInTime;
    private void Awake()
    {
        pointsInTime = new List<PointInTime>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartRewind();
        }
        if(Input.GetKeyUp(KeyCode.Space))
        {
            StopRewind();
        }
    }

    private void FixedUpdate()
    {
        if (isRewinding)
        {
            Rewind();
        }
        else
        {
            Record();
        }
    }

    public void StartRewind()
    {
        isRewinding = true;
    }

    public void StopRewind()
    {
        isRewinding = false;
    }

    public void Rewind()
    {
        if (pointsInTime.Count > 0)
        {
            transform.position = pointsInTime[0].transform.position;
            pointsInTime.RemoveAt(0);
        }
    }

    public void Record()
    {
        PointInTime currentPointInTime = new PointInTime();
        currentPointInTime = currentPointInTime.NewPointInTime(this.transform);
        pointsInTime.Insert(0, currentPointInTime);
        if(pointsInTime.Count >= maxNumberOfFramesToRewind)
        {
            pointsInTime.RemoveAt(maxNumberOfFramesToRewind - 1);
        }
    }
}
