using UnityEngine;
using System.Collections;

public class PlayerAttack2 : MonoBehaviour
{
    public GameObject Effect;
    bool effect;
    public float skilldelay = 5f;
    public float range = 3f;
    Animator ani;
    EnemyHealth Damage;

    public static bool isSkill1;

    private void Awake()
    {
        ani = GetComponent<Animator>();
        Effect.SetActive(false);
    }

    private void Update()
    {
        if(effect)
        {
            Invoke("cooltime", 0.4f);
            effect = false;
            PlayerMove.isSkill = false;
        }
        Collider2D[] colliders = Physics2D.OverlapCircleAll(this.transform.position, range);
        if (Input.GetKeyDown(KeyCode.V) && !isSkill1 && defaultAttack.curtime <= 0)
        {
            gameObject.layer = 10;
            PlayerMove.isSkill = true;
            ani.SetTrigger("Skill2Attack");
            Invoke("coolTime", 0.6f);
            isSkill1 = true;
            Debug.Log(isSkill1);
            {
                foreach (Collider2D collider in colliders)
                {
                    if (collider.gameObject.CompareTag("Enemy"))
                    {
                        collider.transform.position = Vector2.Lerp(collider.transform.position, transform.position, 0.6f);
                        Damage = collider.GetComponent<EnemyHealth>();
                        Damage.curHealth -= 35f;
                        if (collider.GetComponent<Example>() != null)
                        {
                            collider.GetComponent<Example>().stun = true;
                            StartCoroutine("notStun", collider);
                        }
                        else if(collider.GetComponent<Example1>() != null)
                        {
                            collider.GetComponent<Example1>().stun = true;
                            StartCoroutine("notStun", collider);
                        }
                    }
                }
            }
            Debug.Log("sldjflsk");
            StartCoroutine("SkillWaiting");
        }
    }

    IEnumerator notStun(Collider2D collider)
    {
        yield return new WaitForSeconds(1f);
        gameObject.layer = 3;
        yield return new WaitForSeconds(2.0f);
        if (collider != null)
        {
            if (collider.GetComponent<Example>() != null)
            {
                collider.GetComponent<Example>().stun = false;
            }
            else if (collider.GetComponent<Example1>() != null)
            {
                collider.GetComponent<Example1>().stun = false;
            }
        }
    }

    public void cooltime()
    {
        Effect.SetActive(false);
    }
    public void coolTime()
    {
        Effect.SetActive(true);
        effect = true;
    }

    IEnumerator SkillWaiting()
    {
        Debug.Log(isSkill1);
        yield return new WaitForSeconds(skilldelay);
        isSkill1 = false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}