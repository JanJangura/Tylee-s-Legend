using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WavePoints : MonoBehaviour
{
    public Transform[] wavePoints;

    private void Awake()
    {
        wavePoints = new Transform[transform.childCount];
        for(int i = 0; i < wavePoints.Length; i++)
        {
            wavePoints[i] = transform.GetChild(i);
        }
    }
}
