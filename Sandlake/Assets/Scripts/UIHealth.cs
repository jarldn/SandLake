using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHealth : MonoBehaviour
{

    public static UIHealth Instance { get; private set; }// estamos creado una instancia para poder acceder a este script sin tener que referenciarlo

    public Image mask;
    float originalSize;

    void Awake()
    {
        Instance = this;//instanciamos est objeto
    }

    void Start()
    {
        originalSize = mask.rectTransform.rect.width;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetValue(float value)
    {
        mask.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, originalSize * value);
    }
}
