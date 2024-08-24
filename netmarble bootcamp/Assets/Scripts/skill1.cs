using DG.Tweening;
using System.Collections;
using UnityEngine;

public class PlayerAttack1 : MonoBehaviour
{
    public GameObject skillRange;
    public GameObject stopCol;
    [SerializeField]
    private float rushPower;
    [SerializeField]
    private float maxRushPower = 4;
    [SerializeField]
    private float maxWait = 5f;
    [SerializeField]
    private float wait;
    [SerializeField]
    private float uping = 1;
    private Tween mytween;

    Collider2D cld2D;
    Rigidbody2D rb;
    public static bool isSkill;
    private void Start()
    {
        skillRange.SetActive(false);
        isSkill = false;
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");

        if (Input.GetKey(KeyCode.LeftShift) && !isSkill)
        {
            Debug.Log(isSkill);
            rushPower += uping * Time.deltaTime;
            wait += uping * Time.deltaTime * 1/2;
        }
        if (rushPower >= maxRushPower)
        {
            rushPower = maxRushPower;
        }
        if(wait >= maxWait)
            wait = maxWait;
        if (Input.GetKeyUp(KeyCode.LeftShift) && !isSkill)
        {
            Debug.Log("SDF");
            if (h == 0)
                h = 1;
            skillRange.SetActive(true);
            mytween = transform.DOMoveX(transform.position.x + (transform.localScale.x > 0 ? rushPower : -rushPower), 0.5f).SetEase(Ease.OutQuad);
            rushPower = 0;
            StartCoroutine("skillDelay");
            StartCoroutine("SkillWaiting");
            isSkill = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && isSkill)
        {
            mytween.Pause();
        }
    }

    IEnumerator skillDelay()
    {
        yield return new WaitForSeconds(0.5f);
        skillRange.SetActive(false);
    }

    IEnumerator SkillWaiting()
    {
        Debug.Log(isSkill);
        yield return new WaitForSeconds(wait);
        wait = 0;
        isSkill = false;
    }
}
