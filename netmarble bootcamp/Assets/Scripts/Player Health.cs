using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    GameObject image;
    Image HPBar;
    float curHP = 100f;
    float maxHP = 100f;
    Rigidbody2D rb;
    public GameObject light;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        image = GameObject.FindGameObjectWithTag("PlayerHpBar");
        HPBar = image.GetComponent<Image>();
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "mainUI")
        {
            Destroy(gameObject);
        }
        else
        {
            image = GameObject.FindGameObjectWithTag("PlayerHpBar");
            HPBar = image.GetComponent<Image>();
        }
        if (scene.name == "Lab")
        {
            transform.position = new Vector3(-2.57f, -0.07f, 0f);
        }
        else if(scene.name == "Tunnel")
        {
            transform.position = new Vector3(-12.57f, -0.07f, 0f);
            light.SetActive(true);
        }
        else if(scene.name == "Tunnel_2")
        {
            transform.position = new Vector3(-17.01f, -0.73f, 0f);
        }
        else if(scene.name == "Lab_2")
        {
            transform.position = new Vector3(-8.431178f, -2.732734f, 0f);
        }
        else if (scene.name == "Lab_3")
        {
            transform.position = new Vector3(-8.386908f, -2.737552f, 0f);
        }
        else if(scene.name == "Village")
        {
            transform.position = new Vector3(0.56f, -1.14f, 0);
        }
    }

    void OnDestroy()
    {
        // 이벤트 구독 해제
        SceneManager.sceneLoaded -= OnSceneLoaded;
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
            rb.gravityScale = 2f;
            GameObject.Find("DamageSFX").GetComponent<AudioSource>().Play();
            int dirc = ((transform.position.x - collision.gameObject.transform.position.x > 0) ? 1 : -1);
            rb.AddForce(new Vector2(dirc, 1) * 7, ForceMode2D.Impulse);
            gameObject.layer = 10;
            gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0.4f);
            curHP -= 5f;
            Camera.main.DOShakePosition(0.5f, 1f, 10, 90f);
            Invoke("offDamage", 1.5f);
        }
        if (curHP <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    void offDamage()
    {
        gameObject.layer = 3;
        gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 1f);
    }
}
