using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timeCycle : MonoBehaviour {

    private float dayLength = 1200f;
    private float nightLength = 600f;

    private int day;
    private int night;

    private float currentTime;

    public int days;

	void Update () {

        currentTime += Time.deltaTime;

        if (currentTime >= dayLength && day == 0)
        {
            day = 1;
            currentTime = 0;
        }
        if (currentTime >= nightLength && night == 0 && day == 1)
        {
            night = 1;
            currentTime = 0;
        }
        if (night == 1 && day == 1)
        {
            night = 0;
            day = 0;
            days += 1;
        }
	}
}
