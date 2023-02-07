using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarBehavior : MonoBehaviour
{
    #region Exposed

    public Slider Slider;
    public Color Low;
    public Color High;
    public Vector3 Offset;

    #endregion



    #region Unity Lifecycle
    void Awake()
{

}

 void Start()
    {

    }

 void Update()
    {
        Slider.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position + Offset);
    }

void FixedUpdate()
{

}
    #endregion



    #region Methods

    public void SetHealth(float health, float maxHealth)
    {
        Slider.gameObject.SetActive(health < maxHealth);
        Slider.value = health;
        Slider.maxValue = maxHealth;

        Slider.fillRect.GetComponentInChildren<Image>().color = Color.Lerp(Low, High, Slider.normalizedValue);
    }

    #endregion



    #region Private & Protected

    #endregion
}
