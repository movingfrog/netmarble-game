using UnityEngine;
using UnityEngine.UI;

public class coolTime : MonoBehaviour
{
    public GameObject skillObject;
    public static Image skill;
    public static Image Skill;

    public int oneandtwo;


    private void Awake()
    {
        if(this.gameObject.name == "RushAttack")
        {
            oneandtwo = 1;
            skill = GameObject.Find("Rush").GetComponent<Image>();
        }
        else if(this.gameObject.name == "SettESkill")
        {
            oneandtwo = 2;
            Skill = GameObject.Find("Suction").GetComponent<Image>();
        }
        Debug.Log(skill.name);
        Debug.Log(gameObject.name);
    }

    private void Update()
    {
         if(PlayerAttack1.isSkill2 && oneandtwo == 1)
         {
            skill.fillAmount -= Time.deltaTime/5;
         }
         else if(PlayerAttack2.isSkill1 && oneandtwo == 2)
        {
            Skill.fillAmount -= Time.deltaTime/5;
        }
    }
}
