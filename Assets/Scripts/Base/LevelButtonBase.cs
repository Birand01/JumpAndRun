using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class LevelButtonBase : MonoBehaviour
{
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

    }

}
