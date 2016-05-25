using UnityEngine;
using System.Collections;
using DG.Tweening;

public class MonsterAttack : Attack {

    public override void Execute(Entity parEntity)
    {
        parEntity.TakeDamage(this._damage);
        //this.GetComponent<Entity>().TakeBreathCost(this._damageToBreath, this._breathMultiplier);
        parEntity.transform.DOShakeScale(0.7f, 1, 10).OnComplete(() => parEntity.transform.DOKill(true));
    }
}
