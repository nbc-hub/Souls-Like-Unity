using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{
    public Slider slider;
    public GameObject sliderImage;

    private void Start() {
        
    }

    public void SetSliderImageStatu(bool status){
        sliderImage.SetActive(status);
    }
    public void SetMaxStamina(float maxStamina){
        slider.maxValue=maxStamina;
        slider.value=maxStamina;
    }

    public void SetCurrentStamina(float currentStamina){
        if(currentStamina<0){
            currentStamina=0;
            SetSliderImageStatu(false);
        }else{
            SetSliderImageStatu(true);
        }
        slider.value=currentStamina;
    }
}
