using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GenericHealthBar
{
    public class PlayerHealthBar : MonoBehaviour
    {
        Slider healthSlider;

        public void Start()
        {
            healthSlider = GetComponent<Slider>();
        }

        public void SetMaxHealth(float maxHealth)
        {
            healthSlider.maxValue = maxHealth;
            healthSlider.value = maxHealth;
        }

        public void SetHealth(float health)
        {
            healthSlider.value = health;
        }
    }
}
