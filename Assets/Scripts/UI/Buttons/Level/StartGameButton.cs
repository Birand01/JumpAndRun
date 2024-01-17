using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameButton : LevelButtonBase
{
    public delegate IEnumerator OnSpawnObstacleEventHandler(bool state);
    public static event OnSpawnObstacleEventHandler OnSpawnObstacleCoroutine;
    public static event Action<bool> OnSpawnObstacle;
    protected override void OnButtonClickEvent()
    {
       OnSpawnObstacle?.Invoke(true);
      // StartCoroutine(OnSpawnObstacleCoroutine?.Invoke(true));
    }
}
