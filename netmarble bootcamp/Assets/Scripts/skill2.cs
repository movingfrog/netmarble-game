using UnityEngine;
using System.Collections;

public class PlayerAttack2 : MonoBehaviour
{
    public float skilldelay = 5f;
    public float range = 3f;

    public bool isSkill;

    private void Update()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(this.transform.position, range);
        if (Input.GetKeyDown(KeyCode.V) && !isSkill)
        {
            isSkill = true;
            Debug.Log(isSkill);
            foreach (Collider2D collider in colliders)
            {
                if (collider.gameObject.CompareTag("Enemy"))
                {
                    collider.transform.position = Vector2.Lerp(collider.transform.position, transform.position, 0.6f);

                }
            }
            Debug.Log("sldjflsk");
            StartCoroutine("SkillWaiting");
        }
    }

    IEnumerator SkillWaiting()
    {
        Debug.Log(isSkill);
        yield return new WaitForSeconds(skilldelay);
        isSkill = false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}