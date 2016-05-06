using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MonsterManager : MonoBehaviour {
    
    public List<Entity> _playerList = new List<Entity>();
    
    public MonsterBoss _advancedMonster;
    public List<Entity> _monsterList = new List<Entity>();

    public bool _isPlaying;

    // Use this for initialization
    void Start () {
        _playerList = PlayerManager.GetInstance()._playerList;
        _isPlaying = false;

        GameObject[] tempMonsters = GameObject.FindGameObjectsWithTag("Monster");
        foreach (GameObject parPlayers in tempMonsters)
        {
            _monsterList.Add(parPlayers.GetComponent<MonsterBoss>());
        }

    }
	
	// Update is called once per frame
	void Update () {
        if(TurnManager.GetInstance()._whoPlays == 1 && !_isPlaying)
        {
            StartCoroutine(ExecuteMonsterTurn());
        }
	}

    IEnumerator ExecuteMonsterTurn()
    {
        _isPlaying = true;
        while (TurnManager.GetInstance()._whoPlays == 1)
        {
            _monsterList[0].GetComponent<MonsterBoss>().AttackTarget(_playerList);
            yield return new WaitForSeconds(1.0f);
        }
        _isPlaying = false;


    }
}
