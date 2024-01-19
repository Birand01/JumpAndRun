using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class LevelButtonBase : MonoBehaviour
{
    public static event Action<SoundType, bool> OnButtonClickSound;
    protected Button button;
    protected virtual void Awake()
    {
        button = GetComponent<Button>();
    }
    protected virtual void Start()
    {
      
        button.onClick.AddListener(OnButtonClickEvent);
    }

    protected virtual void OnButtonClickEvent()
    {
        OnButtonClickSound?.Invoke(SoundType.ButtonSound, true);
    }

}
