using DG.Tweening;
using System.Collections;
using UnityEngine;

public class PlayerAttack1 : MonoBehaviour
{
    public GameObject skillRange;
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


    Rigidbody2D rb;
    bool isSkill;
    private void Start()
    {
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
            wait += uping * Time.deltaTime;
            rushPower += 0.5f * Time.deltaTime;
            wait += 0.5f * Time.deltaTime;
        }
        if (rushPower >= maxRushPower)
        {
            rushPower = maxRushPower;
            wait = maxWait;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift) && !isSkill)
        {
            Debug.Log("SDF");
            if (h == 0)
                h = 1;
            skillRange.SetActive(true);
            transform.DOMoveX(transform.position.x + (transform.localScale.x > 0 ? rushPower : -rushPower), 0.1f).SetEase(Ease.OutQuad);
            rb.velocity = new Vector2(rushPower * h, 0);
            rushPower = 0;
            StartCoroutine("skillDelay");
            isSkill = true;
            StartCoroutine("SkillWaiting");
        }
    }

    IEnumerator skillDelay()
    {
        yield return new WaitForSeconds(1f);
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
