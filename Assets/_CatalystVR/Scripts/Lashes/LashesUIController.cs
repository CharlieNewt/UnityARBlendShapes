using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LashesUIController : MonoBehaviour
{
    [SerializeField] LashData lashDataLeft;
    [SerializeField] LashData lashDataRight;
    [Header("Lashes Shape Sliders")]
    [SerializeField] Slider curlSlider;
    [SerializeField] Slider widthSlider;
    [SerializeField] Slider lengthSlider;

    private void Start() {
        lashDataLeft.curl = 0;
        lashDataRight.curl = 0;
        lashDataLeft.width = 0;
        lashDataRight.width = 0;
        lashDataLeft.width = 0;
        lashDataRight.width = 0;
    }

    public void UpdateCurl()
    {
        lashDataLeft.curl = curlSlider.value;
        lashDataRight.curl = curlSlider.value;
    }

    public void UpdateWidth()
    {
        lashDataLeft.width = widthSlider.value;
        lashDataRight.width = widthSlider.value;
    }

    public void UpdateLength()
    {
        lashDataLeft.length = lengthSlider.value;
        lashDataRight.length = lengthSlider.value;
    }

    
}
