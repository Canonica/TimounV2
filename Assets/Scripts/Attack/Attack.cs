using UnityEngine;
using System.Collections;
using System.Collections.Generic;

abstract public class Attack : MonoBehaviour {

    public int _damage;
    public float _timeToExec;
    public float _coolDown;
    public float _currentCoolDown;
    public int _damageToBreath;
    public string _input;
    public int _breathMultiplier;

    public bool canAttack;

    abstract public void Execute(Entity parEntity);
}
