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
        if(this.gameObject.name == "SettESkill") //여기서 자신이 뭔지 인식함
        {
            Skill = GameObject.Find("Suction").GetComponent<Image>();
        }
    }

    private void Update()
    {
        if(PlayerAttack1.isSkill2)
        {
           skill.fillAmount -= Time.deltaTime/5;
           Debug.Log(skill.name);
        }
        if(PlayerAttack2.isSkill1) //여기서 1에서 점점 내려감
        {
           Skill.fillAmount -= Time.deltaTime/5;
           Debug.Log(Skill.name);
           //여기?
        }
        //여기 말고?
    }
}
