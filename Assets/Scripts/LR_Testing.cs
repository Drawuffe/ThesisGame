using UnityEngine;

public class LR_Testing : MonoBehaviour
{
    [SerializeField]  private Transform[] points;
    [SerializeField]  private LineController line;

    void Start()
    {
        line.SetUpLine(points);
    }


}
