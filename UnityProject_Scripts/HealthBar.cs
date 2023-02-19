using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public static HealthBar instance { get; private set; }

    public int maxHealth = 10;
    public int currentHealth = 10;

    public Slider slider;
    public Gradient gradient;
    public Image fill;

    public AudioSource audioClip;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;

        fill.color = gradient.Evaluate(1f);

    }


    public void SetHealth(int health)
    {
        if (health < currentHealth)
        {
            audioClip.Play();
        }
        currentHealth = health;
        slider.value = health;

        fill.color = gradient.Evaluate(slider.normalizedValue);

    }

    public void decreace(int health)
    {
        SetHealth(currentHealth - health);
    }

    public void ToDead()
    {
        SetHealth(0);
    }
}
