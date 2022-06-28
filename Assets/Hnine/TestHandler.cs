using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestHandler : MonoBehaviour
{
    public GameObject objImage;
    
    void Start()
    {
        objImage.hnine().Btn.onClick.AddListener(()=>{
            Debug.Log("click");
        });
        objImage.hnine().Cg.alpha = 0.5f;
        objImage.hnine().Rt.anchoredPosition = Vector2.zero;
    }
}
