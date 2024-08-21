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
            rushPower += 0.5f;
            wait += 0.5f;
        }
        if(rushPower >= maxRushPower)
        {
            rushPower = maxRushPower;
            wait = maxWait;
        }
        if(Input.GetKeyUp(KeyCode.RightShift)&&!isSkill)
        {
            if (h == 0)
                h = 1;
            skillRange.SetActive(true);
            rb.velocity = new Vector2(rb.velocity.x + rushPower * h, 0);
            rushPower = 0;
            isSkill = true;
            StartCoroutine("SkillWaiting");
        }
    }

    IEnumerator SkillWaiting()
    {
        Debug.Log(isSkill);
        yield return new WaitForSeconds(wait);
        isSkill = false;
    }
}
