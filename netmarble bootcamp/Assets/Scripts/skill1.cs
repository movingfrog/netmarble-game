using DG.Tweening;
using System.Collections;
using UnityEngine;

public class PlayerAttack1 : MonoBehaviour
{
    public GameObject skillRange;
    public GameObject Effect;
    [SerializeField]
    private float rushPower;
    [SerializeField]
    private float maxRushPower = 10;
    [SerializeField]
    private float maxWait = 5f;
    [SerializeField]
    private float wait;
    [SerializeField]
    private float uping = 5f;
    Animator ani;
    Tween mytween;
    bool isEndChraging;
    bool boolsoneshot;

    public static bool isSkill2;
    private void Start()
    {
        ani = GetComponent<Animator>();
        skillRange.SetActive(false);
        isSkill2 = false;
        isEndChraging = false;
        boolsoneshot = false;
        Effect.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift) && !isSkill2 &&defaultAttack.curtime <= 0)
        {

            if (!boolsoneshot)
            {
                ani.SetTrigger("isChrag");
                boolsoneshot = true;
                PlayerMove.isSkill = true;
            }
            else
            {
                ani.SetTrigger("isChraging");
            }
            Debug.Log(isSkill2);
            gameObject.layer = 9;
            //데미지 점점 증가 코드 예: damage += uping * uping * Time.deltaTime;
            rushPower += uping * Time.deltaTime;
            wait += uping * Time.deltaTime * 1/2;
        }
        if (rushPower >= maxRushPower)
        {
            rushPower = maxRushPower;
            if (!isEndChraging)
            {
                Effect.SetActive(true);
                isEndChraging=true;
            }
        }
        if(wait >= maxWait)
            wait = maxWait;
        if (Input.GetKeyUp(KeyCode.LeftShift) && !isSkill2)
        {
            PlayerMove.isSkill=false;
            boolsoneshot = false;
            Debug.Log("SDF");
            skillRange.SetActive(true);
            ani.SetTrigger("isAttack");
            mytween = transform.DOMoveX(transform.position.x + (transform.localScale.x > 0 ? rushPower : -rushPower), 0.5f).SetEase(Ease.OutQuad);
            rushPower = 0;
            StartCoroutine("skillDelay");
            StartCoroutine("SkillWaiting");
            isSkill2 = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && isSkill2)
        {
            mytween.Pause();
            gameObject.layer = 3;
            PlayerMove.isSkill = false;
        }
    }

    IEnumerator skillDelay()
    {
        yield return new WaitForSeconds(0.5f);
        gameObject.layer = 3;
        ani.ResetTrigger("isAttack");
        ani.ResetTrigger("isChrag");
        ani.ResetTrigger("isChraging");
        Effect.SetActive(false);
        skillRange.SetActive(false);
        isEndChraging = false;
    }

    IEnumerator SkillWaiting()
    {
        Debug.Log(isSkill2);
        yield return new WaitForSeconds(wait);
        wait = 0;
        isSkill2 = false;
    }
}
