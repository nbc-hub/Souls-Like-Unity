using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaPointBar : MonoBehaviour
{

    public Slider slider;
    public GameObject sliderImage;

    private void Start() {
        
    }

    public void SetSliderImageStatu(bool status){
        sliderImage.SetActive(status);
    }
    public void SetMaxMana(float maxMana){
        slider.maxValue=maxMana;
        slider.value=maxMana;
    }

    public void SetCurrentMana(float currentMana){
        if(currentMana<0){
            currentMana=0;
            SetSliderImageStatu(false);
        }else{
            SetSliderImageStatu(true);
        }
        slider.value=currentMana;
    }
}
