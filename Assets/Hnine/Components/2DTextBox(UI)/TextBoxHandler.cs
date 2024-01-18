/*
## 
## 2024.1.18 v0.1 updated by Beomseok.Jang@hnine.com
## It requires the ProceduralImage and TextMeshPro
## The method of use involves dragging the prefab onto the Canvas and then adjusting the inspector for use.
*/

using UnityEngine;

public enum TextHorizontalAlignment
{
    Left, Center, Right, Justified, Flush, GeometryCenter
}
public enum TextVerticalAlignment
{
    Top, Middle, Bottom, Baseline, Midline, Capline
}

[ExecuteInEditMode]
public class TextBoxHandler : MonoBehaviour
{
    [Header("[Box Settings]")]
    [SerializeField] private float boxRound;
    [SerializeField] private Color boxColor;
    [Header("[Text Settings]")]
    [TextArea(10,2)]
    [SerializeField] private string textString;
    [SerializeField] private TMPro.TMP_FontAsset font;
    [SerializeField] private Color fontColor;
    [SerializeField] private int fontSize;
    [SerializeField] private int textMarginLeft;
    [SerializeField] private int textMarginRight;
    [SerializeField] private int textMarginTop;
    [SerializeField] private int textMarginBottom;
    [SerializeField] private TMPro.TextAlignmentOptions textAlignment;

    [Header("[Border Settings]")]
    [SerializeField] private bool enableBoxBorder;
    [Range(0.1f, 100f)]
    [SerializeField] private float boxBorderWidth;
    [SerializeField] private Color boxBorderColor;

    [Header("[Shadow Settings]")]
    [SerializeField] private bool enableShadow;
    [SerializeField] private Color shadowColor;
    [SerializeField] private float shadowBlurSize;
    [SerializeField] private Vector2 shadowDistance;

    private GameObject shadow;
    private GameObject bg;
    private GameObject border;
    private GameObject text;

    void Start()
    {
        shadow = transform.Find("Shadow").gameObject;
        bg = transform.Find("Bg").gameObject;
        border = transform.Find("Border").gameObject;
        text = transform.Find("Text").gameObject;
    }

    void Update()
    {
        bg.hnine().UniformModifier.Radius = boxRound;
        bg.hnine().PImg.color = boxColor;

        shadow.hnine().UniformModifier.Radius = boxRound;
        text.hnine().TmpTxt.text = textString;
        text.hnine().TmpTxt.color = fontColor;
        text.hnine().TmpTxt.fontSize = fontSize;
        text.hnine().TmpTxt.alignment = textAlignment;
        text.hnine().TmpTxt.font = font;

        text.hnine().Rt.offsetMin = new Vector2(textMarginLeft, textMarginBottom);
        text.hnine().Rt.offsetMax = new Vector2(-textMarginRight, -textMarginTop);

        border.SetActive(enableBoxBorder);
        border.hnine().UniformModifier.Radius = boxRound;
        border.hnine().PImg.color = boxBorderColor;
        border.hnine().PImg.BorderWidth = boxBorderWidth;

        shadow.SetActive(enableShadow);
        shadow.hnine().PImg.color = shadowColor;
        shadow.hnine().PImg.FalloffDistance = shadowBlurSize;
        shadow.hnine().Rt.offsetMin = new Vector2(shadowDistance.x, shadowDistance.y);
        shadow.hnine().Rt.offsetMax = new Vector2(shadowDistance.x, shadowDistance.y);
    }
}
