using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using DG.Tweening;

public class Player : MonoBehaviour {
    public int playerID;

    public int healthMax;
    public int health;
    public Image healthImage;

    public int staminaMax;
    public int stamina;
    public Image staminaImage;


    public bool canRegenStamina;
    public bool canAttack;
    public Vector3 position;
    public Monster target;

    public Monster[] allMonsters;

    public Animation allAnims;
    public bool isAdvanced;
    public Vector3 firstPosition;

    public Text impossibleActionText;

    [Header("Attaque A - Options")]
    public int costAttackA;
    public float cooldownAttackA;
    public int damageAttackA;
    public float stunAttackA;

    [Header("Attaque B - Options")]
    public int costAttackB;
    public float cooldownAttackB;
    public int damageAttackB;
    public float stunAttackB;

    [Header("Attaque Combo - Options")]
    public int costAttackC;
    public float cooldownAttackC;
    public int damageAttackC;
    public float stunAttackC;

    public Animator myAnims;

    public Image Croix;
    public Image A_Button;
    public Image Button_X;
    public Image Button_B;

    // Use this for initialization
    void Start () {
        myAnims = GetComponent<Animator>();
        canAttack = true;
        healthMax = 40;
        staminaMax = 40;
        stamina = staminaMax;
        health = healthMax;
        healthImage = GameObject.Find("HealthFull" + (playerID + 1)).GetComponent<Image>();
        staminaImage = GameObject.Find("StaminaFull" + (playerID + 1)).GetComponent<Image>();
        firstPosition = transform.position;
        StartCoroutine(reloadStamina());
        impossibleActionText.DOFade(0, 0f);
        Croix.DOFade(0, 0f);
        A_Button.DOFade(0, 0f);
        Button_X.DOFade(0, 0f);
        Button_B.DOFade(0, 0f);

    }
	
	// Update is called once per frame
	void Update () {
        healthImage.fillAmount = (float)((float)health / (float)healthMax);
        staminaImage.fillAmount = (float)((float)stamina / (float)staminaMax);

    }

    public void getDamage(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Dead();
        }
    }

    void Dead()
    {
        Debug.Log(playerID + " is dead");
    }

    public void Advance()
    {
        myAnims.SetBool("isRun", true);
        isAdvanced = true;
        transform.DOMove(GameObject.Find("Advanced").transform.position + new Vector3(0, -0.5f, 0), 0.5f).OnComplete(Zoom); ;
    }

    public void Zoom()
    {
        myAnims.SetBool("isRun", false);
        Camera.main.transform.DOLookAt(transform.position, 0.5f);
        Camera.main.DOFieldOfView(35, 1f);
    }

    public void Back()
    {
        isAdvanced = false;
        transform.DOMove(firstPosition, 0.5f);
    }

    public void AttackA()
    {
        StartCoroutine(Attack(costAttackA, cooldownAttackA, damageAttackA, stunAttackA));
        A_Button.DOFade(1, 0.2f);
        Invoke("Fade", 0.2f);
    }

    public void Fade()
    {
        A_Button.DOFade(0, 0.2f);
    }

    public void AttackB()
    {
        StartCoroutine(Attack(costAttackB, cooldownAttackB, damageAttackB, stunAttackB));

    }

    public void AttackCombo()
    {
        StartCoroutine(Attack(costAttackC, cooldownAttackC, damageAttackC, stunAttackC));
        Button_X.DOFade(1, 0.2f);
       
        Button_B.DOFade(1, 0.2f);

        Croix.DOFade(1, 0.2f);
        Camera.main.transform.DOKill(true);
        Camera.main.transform.DOShakePosition(0.7f, 1, 30, 90);
    }

    public IEnumerator Attack(int cost, float cooldown, int damage, float stunDuration)
    {
        if ((stamina - cost) > 0)
        {
            myAnims.SetBool("isAttack", true);
            canAttack = false;
            stamina -= cost;
            Debug.Log("Attack");
            target.GetDamage(damage, true);
            target.transform.DOShakePosition(0.5f, 0.5f, 10, 90);
            yield return new WaitForSeconds(cooldown);
            canAttack = true;
            myAnims.SetBool("isAttack", false);
        }
        else
        {
            impossibleActionText.transform.DOShakeScale(0.1f, 10);
            impossibleActionText.DOFade(1, 0.2f).OnComplete(() => impossibleActionText.DOFade(0, 0.5f));
            //impossibleActionText.DOFade(0, 0.5f);
            yield break;
        }
        
       
    }

    IEnumerator reloadStamina()
    {
        while (health > 0)
        {
            if (stamina >= 0 && stamina < 15)
            {
                stamina += 1;
                yield return new WaitForSeconds(4);
            }
            else if (stamina >= 15 && stamina < 30)
            {
                stamina += 1;
                yield return new WaitForSeconds(2);
            }
            else if (stamina >= 30 && stamina < 40)
            {
                stamina += 1;
                yield return new WaitForSeconds(1);
            }
            else
            {
                yield return 0;
            }
        }
    }
}
