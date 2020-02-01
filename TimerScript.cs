using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    private Image timerImage;
    public float maxTime = 2f;
    private float leftTime;
    public bool timeIsUp = false;

    void Start()
    {
        GameManager.instance.ts = this;
        timerImage = GetComponent<Image>();
        leftTime = maxTime;
    }

    // Update is called once per frame
    public bool Run()
    {
        if (leftTime > 0)
        {
            leftTime -= Time.deltaTime;
            timerImage.fillAmount = leftTime / maxTime;
            return false;
        }
        
        return true;
    }
}