using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIKeysBar : MonoBehaviour
{
    public static UIKeysBar instance { get; private set; }

    public Image keysMask;
    float originalSize;

    void Awake()
    {
        instance = this;//storing the static, this is used for meaning the object that is running the function
    }

    void Start()
    {
        originalSize = keysMask.rectTransform.rect.width;//stores original size
    }

    public void SetValue(float value)
    {
        keysMask.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, originalSize * value);//changes the size of the mask
    }
}
