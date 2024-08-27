using UnityEngine;
using System.Collections;

public class PlayerAttack2 : MonoBehaviour
{
    public float skilldelay = 5f;
    public float range = 3f;
    Animator ani;

    public static bool isSkill1;

    private void Awake()
    {
        ani = GetComponent<Animator>();
    }

    private void Update()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(this.transform.position, range);
        if (Input.GetKeyDown(KeyCode.V) && !isSkill1 && defaultAttack.curtime <= 0)
        {
            ani.SetTrigger("Skill2Start");
            isSkill1 = true;
            Debug.Log(isSkill1);
            {
                foreach (Collider2D collider in colliders)
                {
                    if (collider.gameObject.CompareTag("Enemy"))
                    {
                        collider.transform.position = Vector2.Lerp(collider.transform.position, transform.position, 0.6f);

                    }
                }
            }
            Debug.Log("sldjflsk");
            StartCoroutine("SkillWaiting");
        }
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