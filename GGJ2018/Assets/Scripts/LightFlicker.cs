using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlicker : MonoBehaviour {

    public Light lights;
    public float[] smoothing = new float[20];

	// Use this for initialization
	void Start () {
        for(int i=0; i<smoothing.Length;i++)
        {
            smoothing[i] = .0f;
        }
	}

	// Update is called once per frame
	void Update () {
        float sum = .0f;
        for(int i=1;i<smoothing.Length;i++)
        {
            smoothing[i - 1] = smoothing[i];
            sum += smoothing[i - 1];
        }
        smoothing[smoothing.Length - 1] = Random.value;
        sum += smoothing[smoothing.Length - 1];
        lights.intensity = sum / smoothing.Length;
	}
}
