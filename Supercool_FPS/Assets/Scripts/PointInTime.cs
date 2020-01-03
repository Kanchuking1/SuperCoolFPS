using UnityEngine;

public class PointInTime
{
    public Transform transform;
    //public Color color;

    public PointInTime NewPointInTime(Transform _transform)
    {
        this.transform = _transform;
        return this;
    }
}
