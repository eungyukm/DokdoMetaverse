using UnityEngine;
using UnityEngine.Events;

// GeoPoint 클래스는 GeoJson 데이터 중 WKT Point의 데이터를 가지고 있습니다.
public class GeoPoint : MonoBehaviour
{
    public Vector3 positon = Vector3.zero;
    public int index = 0;
    public UnityAction<int> OnPositionChange;

    public void SetPosition(Vector3 pos)
    {
        positon = pos;
        transform.position = pos;
        OnPositionChange?.Invoke(index);
    }

    public void SetIndex(int idx)
    {
        index = idx;
    }
}
