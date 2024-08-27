using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public GameObject image;
    Image HPBar;
    float curHP = 100f;
    float maxHP = 100f;
    Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        HPBar = image.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        HPBar.fillAmount = curHP / maxHP;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            int dirc = ((transform.position.x - collision.gameObject.transform.position.x > 0) ? 1 : -1);
            rb.AddForce(new Vector2(dirc, 1) * 7, ForceMode2D.Impulse);
            gameObject.layer = 10;
            gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0.4f);
            curHP -= 5f;
            Invoke("offDamage", 1.5f);
        }
        if (curHP <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    void offDamage()
    {
        gameObject.layer = 3;
        gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 1f);
    }
}
