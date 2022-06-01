using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public GameObject sliderImage;

    private void Start() {
        
    }

    public void SetSliderImageStatu(bool status){
        sliderImage.SetActive(status);
    }
    public void SetMaxHealth(int maxHealth){
        slider.maxValue=maxHealth;
        slider.value=maxHealth;
    }

    public void SetCurrentHealth(int currentHealth){
        slider.value=currentHealth;
    }
}
