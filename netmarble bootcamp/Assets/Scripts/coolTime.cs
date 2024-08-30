using UnityEngine;
using UnityEngine.UI;

public class coolTime : MonoBehaviour
{
    public static Image skill;
    public static Image Skill;


    private void Awake()
    {
        if(this.gameObject.name == "RushAttack")
        {
            skill = GameObject.Find("Rush").GetComponent<Image>();
        }
        if(this.gameObject.name == "SettESkill")
        {
            Skill = GameObject.Find("Suction").GetComponent<Image>();
        }
    }

    private void FixedUpdate()
    {
        if(PlayerAttack1.isSkill2)
        {
           skill.fillAmount -= Time.deltaTime/10;
        }
        if(PlayerAttack2.isSkill1)
        {
           Skill.fillAmount -= Time.deltaTime/10;
        }
    }
}
