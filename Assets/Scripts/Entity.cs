using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Entity : MonoBehaviour {

	public enum EntityStates
    {
        NONE,
        BREATHLESS,
        STUN,
    }

    public EntityStates _entityState;

    public int _pv;
    public int _breath;

    //public List<Attack> _listOfAttacks;

    void TakeDamage(int parAmount)
    {

    }

    void Death()
    {

    }
}
