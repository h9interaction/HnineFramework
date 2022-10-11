using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonLongpress : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public UnityEvent OnLongPress = new UnityEvent();
    public float pressTime = 0.4f;

    public void OnPointerDown(PointerEventData e)
    {
        Invoke("onLongPress", pressTime);
    }

    public void OnPointerUp(PointerEventData e)
    {
        CancelInvoke("onLongPress");
    }

    void onLongPress()
    {
        OnLongPress?.Invoke();
        Debug.Log("Long Pressed");
    }
}
