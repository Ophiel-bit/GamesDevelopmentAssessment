using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHealthBar : MonoBehaviour
{
    public static UIHealthBar instance { get; private set; }

    public Image mask;
    float originalSize;

    void Awake()
    {
        instance = this;//storing the static, this is used for meaning the object that is running the function
    }

    void Start()
    {
        originalSize = mask.rectTransform.rect.width;//stores original size
    }

    public void SetValue(float value)
    {
        mask.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, originalSize * value);//changes the size of the mask
    }
}
