using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;

public class Player : Entity {

    public int _comboMultiplier;
    //public List<Monster> _listOfMonsters;
    public Vector3 _startPosition;

    void Start()
    {
        _startPosition= transform.position;
    }

    public override void TakeDamage(int parAmount)
    {
        this._pv -= parAmount;
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
}
