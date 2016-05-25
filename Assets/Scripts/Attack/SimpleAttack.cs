using UnityEngine;
using System.Collections;
using DG.Tweening;
public class SimpleAttack : Attack {

    public override void Execute(Entity parEntity)
    {
        if (canAttack)
        {
            Debug.Log("simple Attack");
            parEntity.TakeDamage(this._damage);
            this.GetComponent<Entity>().TakeBreathCost(this._damageToBreath, this._breathMultiplier);
            _currentCoolDown = 0;
            parEntity.transform.DOShakeScale(0.7f, 1, 10).OnComplete(() => parEntity.transform.DOKill(true));
        }
        
    }

    void Start()
    {
        canAttack = true;
    }

    void Update()
    {
        if(_currentCoolDown >= _coolDown)
        {
            canAttack = true;
        }else
        {
            canAttack = false;
            _currentCoolDown += Time.deltaTime;
        }
    }
}
