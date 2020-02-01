using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TimerScript : MonoBehaviour
{
    private Image timerImage;
    public float maxTime = 6f;
    private float leftTime;
    public bool timeIsUp = false;
    void Start()
    {
        timerImage = GetComponent<Image>();
        leftTime = maxTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (leftTime > 0)
        {
            leftTime -= Time.deltaTime;
            timerImage.fillAmount = leftTime / maxTime;
        }
        else
        {
            timeIsUp = true;
            Time.timeScale = 0;
        }
    }
}
