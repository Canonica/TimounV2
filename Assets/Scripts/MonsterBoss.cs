using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class MonsterBoss : Entity {

    public List<Player> _listOfPlayer;

    void Start()
    {
        //listOfPlayer = PlayerManager.instance.listOfPlayer;
    }

    public override void TakeDamage(int parAmount)
    {
        this._pv -= parAmount;
    }


    public override void TakeBreathCost(int parAmount, int parBreathMultiplier)
    {
    }

    public override void Back()
    {
    }

    public override void Death()
    {
    }

    void DoSomething()
    {

    }

}
