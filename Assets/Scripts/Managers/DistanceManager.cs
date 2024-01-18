using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DistanceManager : MonoBehaviour
{
    [SerializeField] internal float generalSpeed;
    private float timer,limitTimer=1f;
    [SerializeField] private float maxDistance;
    [SerializeField] private TMP_Text distanceCounterText;
    private void Awake()
    {
        maxDistance = 0f;
        distanceCounterText.text = maxDistance.ToString()+"m";
    }
    private void OnEnable()
    {
        GameEvents.OnStartGameEvent += CountDistance;
    }
    private void OnDisable()
    {
        GameEvents.OnStartGameEvent -= CountDistance;

    }

    private void CountDistance(bool state)
    {
        if(state)
        {
            timer += Time.deltaTime;
            Debug.Log(timer);
            if (timer >= limitTimer)
            {
                maxDistance++;
                distanceCounterText.text = maxDistance.ToString()+"m";
                timer = 0f;
                Debug.Log(maxDistance.ToString());
            }
        }
        else
        {
            timer = 0f;
            return;
        }
    }
}
