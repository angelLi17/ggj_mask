using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Health health;

    void Start()
    {
        slider.maxValue = health.maxHealth;
        slider.value = health.currentHealth;
    }

    void Update()
    {
        slider.value = health.currentHealth;
    }
}