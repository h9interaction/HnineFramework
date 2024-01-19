/*
## 
## 2024.1.19 v0.1 updated by Beomseok.Jang@hnine.com
## It requires the ProceduralImage and DoTween
## The method of use involves dragging the prefab onto the Canvas and then adjusting the inspector for use.
*/

using UnityEngine;
using DG.Tweening;

namespace com.hnine.UIComponentFrameworks
{
    [ExecuteInEditMode]
    public class SwitchHandler : MonoBehaviour
    {
        [SerializeField] private bool isOn = false;
        [SerializeField] private float tweenTime = 0.2f;
        [SerializeField] private Ease ease = Ease.OutQuart;


        [Header("Box Settings")]
        [SerializeField] private float boxRound = 40;
        [SerializeField] private Color boxColorOff = Color.gray, boxColorOn = Color.blue;
        [SerializeField] private bool enableBorder = true;
        [SerializeField] private float borderWidth = 3;
        [SerializeField] private Color borderColorOff = Color.black, borderColorOn = Color.white;
        [Header("Toggle Settings")]
        [SerializeField] private float toggleRound = 25;
        [SerializeField] private Color toggleColorOn = Color.white, toggleColorOff = Color.white;
        // [SerializeField] private Vector2 toggleSize = new Vector2(36, 36);

        private GameObject box;
        private GameObject border;
        private GameObject toggle;
        private float togglePos;


        void Start()
        {
            box = transform.Find("Bg").gameObject;
            border = transform.Find("Border").gameObject;
            toggle = transform.Find("Toggle").gameObject;
            box.hnine().Btn.onClick.AddListener(onClick);
        }
        void Update()
        {
            if (!Application.isPlaying)
            {
                box.hnine().UniformModifier.Radius = boxRound;
                box.hnine().PImg.color = (isOn) ? boxColorOn : boxColorOff;

                border.SetActive(enableBorder);
                border.hnine().UniformModifier.Radius = boxRound;
                border.hnine().PImg.BorderWidth = borderWidth;
                border.hnine().PImg.color = (isOn) ? borderColorOn : borderColorOff;

                toggle.hnine().UniformModifier.Radius = toggleRound;
                toggle.hnine().PImg.color = (isOn) ? toggleColorOn : toggleColorOff;
                // toggle.hnine().Rt.sizeDelta = toggleSize;
                togglePos = box.hnine().Rt.rect.width / 2 - toggle.hnine().Rt.rect.width / 2 - (box.hnine().Rt.rect.height - toggle.hnine().Rt.rect.height) / 2;
                toggle.hnine().Rt.anchoredPosition = new Vector2((isOn) ? togglePos : -togglePos, 0);
            }
        }

        void onClick()
        {
            togglePos = box.hnine().Rt.rect.width / 2 - toggle.hnine().Rt.rect.width / 2 - (box.hnine().Rt.rect.height - toggle.hnine().Rt.rect.height) / 2;
            if (isOn)
            {
                isOn = false;
                toggle.hnine().Rt.DOAnchorPosX(-togglePos, tweenTime).SetEase(ease);

                box.hnine().PImg.DOColor(boxColorOff, tweenTime).SetEase(ease);
                border.hnine().PImg.DOColor(borderColorOff, tweenTime).SetEase(ease);
                toggle.hnine().PImg.DOColor(toggleColorOff, tweenTime).SetEase(ease);
            }
            else
            {
                isOn = true;
                toggle.hnine().Rt.DOAnchorPosX(togglePos, tweenTime).SetEase(ease);

                box.hnine().PImg.DOColor(boxColorOn, tweenTime).SetEase(ease);
                border.hnine().PImg.DOColor(borderColorOn, tweenTime).SetEase(ease);
                toggle.hnine().PImg.DOColor(toggleColorOn, tweenTime).SetEase(ease);
            }
        }
    }
}
