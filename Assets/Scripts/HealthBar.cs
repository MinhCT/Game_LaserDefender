using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    Slider slider;

    void Start()
    {
        slider = GetComponent<Slider>();
    }

    public void SetMaxHealth(int value)
    {
        slider.maxValue = value;
        SetHealth(value);
    }

    public void SetHealth(int value)
    {
        slider.value = value;
    }
}
