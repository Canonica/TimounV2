using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
public class MonsterBoss : Entity {

    public List<Player> _listOfPlayer;
    public Vector3 _startPosition;
    public bool _isAdvanced;
    public bool _isAttacking;

    void Start()
    {
        _startPosition = transform.position;
        _isAdvanced = false;
        _isAttacking = false;
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
        transform.DOMove(_startPosition, 0.5f).OnComplete(() => _isAttacking = _isAdvanced = false);
    }

    public override void Death()
    {
    }

    public void AttackTarget(List<Entity> parListOfPlayer)
    {
        if(!_isAdvanced)
        {
            MoveToTarget(parListOfPlayer);
        }
        

    }

    void MoveToTarget(List<Entity> parListOfPlayer)
    {
        int rand = Random.Range(0, parListOfPlayer.Count);
        Debug.Log(rand);

        transform.DOMove(parListOfPlayer[rand].transform.position + parListOfPlayer[rand].transform.forward *2.0f, 0.5f).OnComplete(()=> StartCoroutine(Attack(parListOfPlayer[rand])));
        _isAdvanced = true;
    }

    IEnumerator Attack(Entity parTarget)
    {
        _isAttacking = true;

        Debug.Log(TurnManager.GetInstance()._currentTimeTurn);
        while (TurnManager.GetInstance()._currentTimeTurn>1.0f)
        {
            yield return new WaitForSeconds(1.0f);
            this.GetComponent<SimpleAttack>().Execute(parTarget);
            parTarget.transform.DOShakeScale(0.7f, 1, 10).OnComplete(() => parTarget.transform.DOKill(true));
        }
        Back();
    }
    
}
