using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using DG.Tweening;
public enum Direction { hor, ver }
public class HorizontalScrollSnapHandler : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] Direction MyScrollDirection;
    ScrollRect scrollRect;
    public int index = 0;
    public List<HnineObject> list_Items;
    public float gap, size;
    public Vector2 movePos;
    CanvasScaler canvas;
    public UnityEvent OnSnap = new UnityEvent();
    private void Start()
    {
        Init();
    }

    public void Init()
    {
        canvas = FindObjectOfType<CanvasScaler>();
        // 해당 스크롤렉트 찾고, 호리존탈로 세팅
        scrollRect = GetComponent<ScrollRect>();
        scrollRect.horizontal = (MyScrollDirection == Direction.hor) ? true : false;
        scrollRect.vertical = (MyScrollDirection == Direction.hor) ? false : true;
        // 자동 스클롤 꺼주고,
        scrollRect.inertia = false;
        // 스크롤 콘텐츠 안쪽에 아이템이 몇개가 있는지 확인
        var cnt = scrollRect.content.childCount;
        // 해당 인덱스에 아이템들을 리스트에 넣어줌
        for (int i = 0; i < cnt; i++)
        {
            list_Items.Add(scrollRect.content.GetChild(i).gameObject.hnine());
        }
        size = (MyScrollDirection == Direction.hor) ? list_Items[0].GetSize.x : list_Items[0].GetSize.y;
        gap = (MyScrollDirection == Direction.hor) ? list_Items[0].GetSize.x * list_Items[0].Rt.pivot.x : list_Items[0].GetSize.y * list_Items[0].Rt.pivot.y;

    }
    float scaleFactor()
    {
        return canvas.referenceResolution.x / Screen.width;
    }

    Vector2 startPos;
    public void OnPointerDown(PointerEventData e)
    {
        startPos = scrollRect.content.anchoredPosition;
    }

    public void OnBeginDrag(PointerEventData e)
    {

    }

    public void OnDrag(PointerEventData e)
    {

    }

    public void OnEndDrag(PointerEventData e)
    {
        movePos = startPos - scrollRect.content.anchoredPosition;
        var percent = ((MyScrollDirection == Direction.hor) ? movePos.x : -movePos.y) % size;
        int idx = 0;
        if (percent > 0) idx = (percent > size * 0.5f) ? 1 : 0;
        else idx = (percent < -size * 0.5f) ? -1 : 0;
        var movedIdx = (int)(((MyScrollDirection == Direction.hor) ? movePos.x : -movePos.y) / size) + idx;
        index += movedIdx;
        index = Mathf.Clamp(index, 0, list_Items.Count - 1);
        snap();
    }

    public void snap()
    {
        //해당 아이템의 X위치를 가져와서 스냅처리, 위치값이 음수이기때문에 양수로 바꿔 움직임.
        Debug.Log(-list_Items[index].Rt.anchoredPosition.y + " - " + (scrollRect.content.rect.height - (Screen.height * scaleFactor())));
        var _posx = list_Items[index].Rt.anchoredPosition.x;
        var _posy = -list_Items[index].Rt.anchoredPosition.y;
        float pos = ((MyScrollDirection == Direction.hor) ? _posx : _posy);
        var _width = scrollRect.content.rect.width - canvas.referenceResolution.x;
        var _height = scrollRect.content.rect.height - (Screen.height * scaleFactor());
        if (pos > ((MyScrollDirection == Direction.hor) ? _width : _height))
            pos = ((MyScrollDirection == Direction.hor) ? _width : _height);
        if (MyScrollDirection == Direction.hor)
        {
            scrollRect.content.DOAnchorPosX(-pos, 0.3f).SetEase(Ease.OutQuart).OnComplete(() =>
            {
                OnSnap.Invoke();
            });
        }
        else
        {
            scrollRect.content.DOAnchorPosY(pos, 0.3f).SetEase(Ease.OutQuart).OnComplete(() =>
            {
                OnSnap.Invoke();
            });
        }
    }
}