using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider; // Reference to the UI Slider component

    public void SetMaxHealth(float maxHealth)
    {
        slider.maxValue = maxHealth; // Set the maximum value of the slider to the maximum health
        slider.value = maxHealth; // Set the current value to the maximum health initially
    }

    public void SetHealth(float health)
    {
        slider.value = health; // Set the current value of the slider to the current health
    }
}
