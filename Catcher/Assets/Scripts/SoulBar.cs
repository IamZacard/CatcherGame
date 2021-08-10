using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoulBar : MonoBehaviour
{
    public Slider slider;

    private void Start()
    {
        slider.maxValue = 10;
    }

    public void SetMaxSouls(int souls)
    {
        
        slider.value = souls;
    }

    public void SetSouls(int souls)
    {
        slider.value = souls;
    }
}
