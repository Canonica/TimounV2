﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

abstract public class Entity : MonoBehaviour {

	public enum EntityStates
    {
        NONE,
        BREATHLESS,
        STUN,
    }

    public EntityStates _entityState;

    public bool isAdvanced;

    public int _pv;
    public int _breath;
    public int _paradeDiviser;
    public List<Attack> _listOfAttacks;
    
    abstract public void TakeDamage(int parAmount);

    abstract public void TakeBreathCost(int parAmount, int parBreathMultiplier);

    abstract public void Back();

    abstract public void Death();
}
