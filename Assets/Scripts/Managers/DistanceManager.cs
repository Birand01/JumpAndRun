using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DistanceManager : MonoBehaviour
{
    [SerializeField] internal float speedCoefficient;
    private float timer,limitTimer=3f,spawnDelay;
    [SerializeField] private float maxDistance;
    [SerializeField] private TMP_Text distanceCounterText,highestDistanceText;

    public static event Action<float> OnIncreaseGeneralGameSpeed;
    public static event Action<float> OnDecreaseSpawnObstacleDelay;
    private void Awake()
    {
        maxDistance = 0f;
        speedCoefficient =0.4f;
        spawnDelay = 0.01f;
        distanceCounterText.text = maxDistance.ToString()+"m";
        highestDistanceText.text =PlayerPrefs.GetFloat("HighScore",0).ToString()+"m";
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
                if(maxDistance>PlayerPrefs.GetFloat("HighScore",0))
                {
                    PlayerPrefs.SetFloat("HighScore", maxDistance);
                    highestDistanceText.text = maxDistance.ToString()+"m";
                }
                timer = 0f;
               
            }
            
            if(timer<=0)
            {
                OnIncreaseGeneralGameSpeed?.Invoke(speedCoefficient);
                OnDecreaseSpawnObstacleDelay?.Invoke(spawnDelay);
            }
        }
        else
        {
            timer = 0f;
            return;
        }

    }
}
