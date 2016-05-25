using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MonsterManager : MonoBehaviour {

    private static MonsterManager _instance = null;
    public static MonsterManager GetInstance()
    {
        return _instance;
    }

    void Awake()
    {
        _instance = this;
        //DontDestroyOnLoad(gameObject);
    }

    public List<Entity> _playerList = new List<Entity>();
    
    public MonsterBoss _advancedMonster;
    public List<Entity> _monsterList = new List<Entity>();

    public bool _isPlaying;

    // Use this for initialization
    void Start () {
        

    }

    public void StartUpdate()
    {
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

        if (GameManager.GetInstance()._gameState != GameManager.GameState.Combat)
            return;

        if (TurnManager.GetInstance()._whoPlays == 1 && !_isPlaying)
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
