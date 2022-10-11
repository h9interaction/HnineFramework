using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestHandler : MonoBehaviour
{
    public GameObject objImage;

    void Start()
    {
        var obj = objImage.hnine();
        obj.Btn.onClick.AddListener(() =>
        {
            Debug.Log("click");
            Debug.Log(obj.GetSize);
            obj.Cg.alpha = 0.5f;
            obj.Rt.anchoredPosition = Vector2.zero;
        });
    }
}
