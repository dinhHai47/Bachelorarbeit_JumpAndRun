using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StateInformation : MonoBehaviour
{
    // Start is called before the first frame update
    float timeLeft;
    public int startMinutes;


    void Start()
    {
        timeLeft = startMinutes * 60;
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft = timeLeft - Time.deltaTime;
    }

    public void resetTime()
    {
        timeLeft = startMinutes * 60;
    }

}
