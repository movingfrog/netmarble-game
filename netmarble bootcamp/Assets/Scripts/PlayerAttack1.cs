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

        if (Input.GetKey(KeyCode.LeftShift)&&!isSkill)
        {
            Debug.Log(isSkill);
            rushPower += uping * Time.deltaTime;
            wait += uping * Time.deltaTime;
        }
        if(rushPower >= maxRushPower)
        {
            rushPower = maxRushPower;
            wait = maxWait;
        }
        if(Input.GetKeyUp(KeyCode.LeftShift)&&!isSkill)
        {
            if (h == 0)
                h = 1;
            //skillRange.SetActive(true);
            transform.DOMoveX(transform.position.x + (transform.localScale.x > 0 ? rushPower : -rushPower), 0.1f).SetEase(Ease.OutQuad);
            rushPower = 0;
            isSkill = true;
            StartCoroutine("SkillWaiting");
        }
    }

    IEnumerator SkillWaiting()
    {
        Debug.Log(isSkill);
        yield return new WaitForSeconds(wait);
        wait = 0;
        isSkill = false;
    }
}
