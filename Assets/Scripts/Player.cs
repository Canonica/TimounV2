﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Player : Entity {

    public int _comboMultiplier;

    //public List<Monster> _listOfMonsters;
    

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

    }

    public override void Death()
    {

    }


    void Block()
    {

    }

    void BreathLess()
    {

    }
}
