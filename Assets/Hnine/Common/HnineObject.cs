/*
    ? *** 이 스크립트는 Canvas UI 오브젝트에 한해서 사용 합니다.
    ? 사용하는 방법은?
    ? 상단에 요렇게 게임오브젝트만 선언 해 주고,
    public GameObject objImage;
        
    void Start()
    {
        ? 해당 오브젝트에서 hnine()호출 뒤에 Btn, Cg, Rt, Img, Mask 등등 접근하면 됨!!

        objImage.hnine().Btn.onClick.AddListener(()=>{
            Debug.Log("click");
        });
        objImage.hnine().Cg.alpha = 0.5f;
        objImage.hnine().Rt.anchoredPosition = Vector2.zero;
    }
*/


using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UI.ProceduralImage;
using UnityEngine.Video;

public class HnineObject : MonoBehaviour
{
    public GameObject obj;
    private void Awake()
    {
        if (obj == null) obj = this.gameObject;
    }

    RawImage _rimg;
    public RawImage RImg
    {
        get
        {
            if (_rimg == null)
            {
                _rimg = obj.RImg();
            }
            return _rimg;
        }
    }

    Image _img;
    public Image Img
    {
        get
        {
            if (_img == null)
            {
                _img = obj.IMG();
            }
            return _img;
        }
    }
    CanvasGroup _cg;
    public CanvasGroup Cg
    {
        get
        {
            if (_cg == null)
            {
                _cg = obj.CG();
            }
            return _cg;
        }
    }
    Text _txt;
    public Text Txt
    {
        get
        {
            if (_txt == null)
            {
                _txt = obj.TXT();
            }
            return _txt;
        }
    }
    Button _btn;
    public Button Btn
    {
        get
        {
            if (_btn == null)
            {
                _btn = obj.BTN();
            }
            return _btn;
        }
    }
    RectTransform _rt;
    public RectTransform Rt
    {
        get
        {
            if (_rt == null)
            {
                _rt = obj.RT();
            }
            return _rt;
        }
    }
    Mask _mask;
    public Mask Mask
    {
        get
        {
            if (_mask == null)
            {
                _mask = obj.Mask();
            }
            return _mask;
        }
    }
    ProceduralImage _proceduralImg;
    public ProceduralImage PImg
    {
        get
        {
            if (_proceduralImg == null)
            {
                _proceduralImg = obj.GetComponent<ProceduralImage>();
            }
            return _proceduralImg;
        }
    }
    UniformModifier _uniformModifier;
    public UniformModifier UniformModifier
    {
        get
        {
            if (_uniformModifier == null)
                _uniformModifier = obj.GetComponent<UniformModifier>();
            return _uniformModifier;
        }
    }

    FreeModifier _freeModifier;
    public FreeModifier FreeModifier
    {
        get
        {
            if (_freeModifier == null)
                _freeModifier = obj.GetComponent<FreeModifier>();
            return _freeModifier;
        }
    }

    VideoPlayer _video;
    public VideoPlayer Video
    {
        get
        {
            if (_video == null)
                _video = obj.GetComponent<VideoPlayer>();
            return _video;
        }
    }
    public Vector2 GetSize
    {
        get
        {
            var size = new Vector2(Rt.rect.width, Rt.rect.height);
            return size;
        }
    }
    Animator _animator;
    public Animator Animator
    {
        get
        {
            if (_animator == null)
                _animator = obj.GetComponent<Animator>();
            return _animator;
        }
    }
}

public static class GameObjectExtension
{
    public static HnineObject hnine(this GameObject obj)
    {
        var hnineObj = obj.GetComponent<HnineObject>();
        if (hnineObj == null)
            hnineObj = obj.AddComponent<HnineObject>();
        hnineObj.obj = obj;
        return hnineObj;
    }
}