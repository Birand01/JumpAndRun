using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
public enum CanvasType
{ 
    GameUI,
    GameLostUI,
    TapToRunAnimUI,
    GameSuccessUI
}
public class CanvasManager : MonoBehaviour
{
    List<CanvasController> canvasControllerList;
    internal CanvasController lastActiveCanvas;
    private void Awake()
    {
        canvasControllerList = GetComponentsInChildren<CanvasController>().ToList();
        canvasControllerList.ForEach(x => x.gameObject.SetActive(false));
        SwitchCanvas(CanvasType.TapToRunAnimUI);
    }
    private void OnEnable()
    {
        GameEvents.OnSwitchGameUI += SwitchCanvas;
    }
    private void OnDisable()
    {
        GameEvents.OnSwitchGameUI -= SwitchCanvas;

    }
    private void SwitchCanvas(CanvasType canvasType)
    {

        if (lastActiveCanvas != null)
        {
            lastActiveCanvas.gameObject.SetActive(false);
        }
        CanvasController desiredCanvas = canvasControllerList.Find(x => x.canvasType == canvasType);
        if (desiredCanvas != null)
        {
            desiredCanvas.gameObject.SetActive(true);
            lastActiveCanvas = desiredCanvas;
        }
        else
        {
            Debug.LogWarning("The desired canvas was not found");
        }
    }

}
