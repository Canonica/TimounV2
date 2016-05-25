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
        PlayerManager.GetInstance()._focusedCharacter = null;
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
        PlayerManager.GetInstance()._focusedCharacter = (Player)parListOfPlayer[rand];
        transform.DOMove(parListOfPlayer[rand].transform.position + parListOfPlayer[rand].transform.right *2.0f, 0.5f).OnComplete(()=> StartCoroutine(Attack(parListOfPlayer[rand])));
        _isAdvanced = true;
    }

    IEnumerator Attack(Entity parTarget)
    {
        _isAttacking = true;
        
        while (TurnManager.GetInstance()._currentTimeTurn>0.0f)
        {
            yield return new WaitForSeconds(1.0f);
            _listOfAttacks[0].Execute(parTarget);
            
        }
        Back();
    }
    
}
