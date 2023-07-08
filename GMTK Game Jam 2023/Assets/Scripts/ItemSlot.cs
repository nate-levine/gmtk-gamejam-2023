using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour, IDropHandler
{
    public int markIndex;

    public void Start()
    {
        markIndex = -1;
    }
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            markIndex = eventData.pointerDrag.GetComponent<Mark>().index;
        }
    }

    public void Update()
    {
        if (markIndex != -1)
        {
            GetComponent<Image>().color = new Color(0.0f, 1.0f, 0.0f, 0.5f);
        }
        else if (markIndex == -1)
        {
            GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 0.2f);
        }
    }
}
