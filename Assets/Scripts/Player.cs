using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine.UI;

public class Player : Entity {

    public int _comboMultiplier;
    public int _id;
    //public List<Monster> _listOfMonsters;
    public Vector3 _startPosition;
    
    public Image healthImage;
    public Image staminaImage;

    public int _pvMax;
    public int _breathMax;


    void Start()
    {
        _startPosition= transform.position;

        healthImage = GameObject.Find("HealthFull" + _id).GetComponent<Image>();
        staminaImage = GameObject.Find("StaminaFull" + _id).GetComponent<Image>();

        _pvMax = this._pv;
        _breathMax = this._breath;

        StartCoroutine(ReloadStamina());
    }

    void Update()
    {
        healthImage.fillAmount = (float)((float)this._pv / (float)_pvMax);
        staminaImage.fillAmount = (float)((float)this._breath / (float)_breathMax);
    }

    public override void TakeDamage(int parAmount)
    {
        this._pv -= parAmount / _paradeDiviser;
    }

    public override void TakeBreathCost(int parAmount, int parBreathMultiplier)
    {
        this._breath -= parAmount * parBreathMultiplier;
    }

    public override void Back()
    {
        transform.DOMove(_startPosition, 0.5f);
        this.isAdvanced = false;
    }

    public override void Death()
    {

    }

    public void Attack(int parIndex, List<Entity> parListOfMonster)
    {
        this._listOfAttacks[parIndex].Execute(parListOfMonster[0]);
    }

    void Block()
    {

    }

    void BreathLess()
    {

    }

    public void MoveToTarget(List<Entity> parListOfMonster)
    {
        transform.DOMove(parListOfMonster[0].transform.position - parListOfMonster[0].transform.right * 2.0f, 0.5f);
        this.isAdvanced = true;
    }

    IEnumerator ReloadStamina()
    {
        while (this._pv > 0)
        {
            if (this._breath >= 0 && this._breath < 15)
            {
                this._breath += 1;
                yield return new WaitForSeconds(4);
            }
            else if (this._breath >= 15 && this._breath < 30)
            {
                this._breath += 1;
                yield return new WaitForSeconds(2);
            }
            else if (this._breath >= 30 && this._breath < 40)
            {
                this._breath += 1;
                yield return new WaitForSeconds(1);
            }
            else
            {
                yield return 0;
            }
        }
    }
}
