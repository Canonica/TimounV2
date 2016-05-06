using UnityEngine;
using System.Collections;
using System.Collections.Generic;

abstract public class Attack : MonoBehaviour {

    public int _damage;
    public float _timeToExec;
    public int _damageToBreath;
    public string _input;
    public int _breathMultiplier;

    abstract public void Execute(Entity parEntity);
}
