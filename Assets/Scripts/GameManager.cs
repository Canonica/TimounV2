using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
    private static GameManager _instance = null;

    public static GameManager GetInstance()
    {
        return _instance;
    }

    void Awake()
    {
        _instance = this;
        //DontDestroyOnLoad(gameObject);
    }

    public enum GameState
    {
        Explo,
        Transition,
        Combat,
    }

    public GameState _gameState;

    public GameObject _healthCanvas;
    public GameObject _staminaCanvas;

    bool _alreadyChange;

    void Start()
    {
        _alreadyChange = false;
        _gameState = GameState.Explo;

        _healthCanvas.SetActive(false);
        _staminaCanvas.SetActive(false);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && !_alreadyChange)
        {
            ChangeState();
        }
    }

    void ChangeState()
    {
        _alreadyChange = true;
        StartCoroutine(Transition(2.0f));
    }

    IEnumerator Transition(float parTimer)
    {

        _gameState = GameState.Transition;
        yield return new WaitForSeconds(parTimer);
        ActiveAllUpdate();
        _gameState = GameState.Combat;
        

    }

    void ActiveAllUpdate()
    {
        _healthCanvas.SetActive(true);
        _staminaCanvas.SetActive(true);
        TurnManager.GetInstance().StartUpdate();
        PlayerManager.GetInstance().StartUpdate();
        MonsterManager.GetInstance().StartUpdate();
        foreach(Player _player in PlayerManager.GetInstance()._playerList)
        {
            _player.StartUpdate();
        }

        foreach (MonsterBoss _monster in MonsterManager.GetInstance()._monsterList)
        {
            _monster.StartUpdate();
        }
        
    }
}
