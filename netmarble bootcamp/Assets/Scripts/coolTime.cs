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
        if(this.gameObject.name == "SettESkill") //���⼭ �ڽ��� ���� �ν���
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
        if(PlayerAttack2.isSkill1) //���⼭ 1���� ���� ������
        {
           Skill.fillAmount -= Time.deltaTime/5;
           Debug.Log(Skill.name);
           //����?
        }
        //���� ����?
    }
}
