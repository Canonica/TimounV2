using UnityEngine;
using System.Collections;
using System;

public class SimpleAttack : Attack {

    public override void Execute(Entity parEntity)
    {
        parEntity.TakeDamage(this._damage);
        this.GetComponent<Entity>().TakeBreathCost(this._damageToBreath, this._breathMultiplier);
    }
}
