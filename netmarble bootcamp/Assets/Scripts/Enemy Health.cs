using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public float curHealth;
    public float maxHealth;
    public GameObject slider;
    GameObject visualSlider;
    Slider healthSlider;
    RectTransform UI;
    public GameObject canvas;

    private void Awake()
    {
        visualSlider = Instantiate(slider);
        visualSlider.transform.SetParent(canvas.transform, false);
        visualSlider.transform.localPosition = Vector3.zero;
        if (GetComponent<Example>() != null)
        {
            maxHealth = 100f;
            curHealth = maxHealth;
        }
        else if (GetComponent<Example1>() != null)
        {
            maxHealth = 250f;
            curHealth = maxHealth;
        }
        healthSlider = visualSlider.GetComponent<Slider>();
        UI = visualSlider.GetComponent<RectTransform>();
    }

    private void Update()
    {
        healthSlider.value = curHealth / maxHealth;
        UI.position = Camera.main.WorldToScreenPoint(new Vector3(transform.position.x, transform.position.y + 1, transform.position.z));
    }
}
