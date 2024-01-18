/*
GameObject에 다양 한 컴포넌트를 붙이거나 접근하는 용도로 사용
*/

using TMPro;
using UnityEngine;
using UnityEngine.UI;

public static class MyExtensions
{
    public static Image IMG(this GameObject obj)
    {
        return obj.GetComponent<Image>();
    }
    public static CanvasGroup CG(this GameObject obj)
    {
        var cg = obj.GetComponent<CanvasGroup>();
        if (cg == null)
            cg = obj.AddComponent<CanvasGroup>();
        return cg;
    }
    public static Text TXT(this GameObject obj)
    {
        var txt = obj.GetComponent<Text>();
        if (txt == null)
            txt = obj.AddComponent<Text>();
        return txt;
    }
    public static TMP_Text TmpTXT(this GameObject obj)
    {
        var txt = obj.GetComponent<TMP_Text>();
        if (txt == null)
            txt = obj.AddComponent<TMP_Text>();
        return txt;
    }
    public static Button BTN(this GameObject obj)
    {
        var btn = obj.GetComponent<Button>();
        if (btn == null)
            btn = obj.AddComponent<Button>();
        return btn;
    }
    public static RectTransform RT(this GameObject obj)
    {
        var rt = obj.GetComponent<RectTransform>();
        return rt;
    }
    public static Mask Mask(this GameObject obj)
    {
        var mask = obj.GetComponent<Mask>();
        if (mask == null)
            mask = obj.AddComponent<Mask>();
        return mask;
    }
    public static RawImage RImg(this GameObject obj)
    {
        var rimg = obj.GetComponent<RawImage>();
        if (rimg == null)
            rimg = obj.AddComponent<RawImage>();
        return rimg;
    }
}
