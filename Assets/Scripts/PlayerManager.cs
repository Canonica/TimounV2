using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using XInputDotNetPure;
public class PlayerManager : MonoBehaviour {
    private static PlayerManager _instance = null;

    public Player _selectedPlayer;
    public Player _advancedPlayer;
    public List<Entity> _playerList = new List<Entity>();

    public List<GameObject> _indicatorPlayer = new List<GameObject>();
    public Vector3 _initialCamPosition ;

    bool isButtonA;
    bool isButtonB;

    public static PlayerManager GetInstance()
    {
        return _instance;
    }

    void Awake()
    {
        _instance = this;
        DontDestroyOnLoad(gameObject);
    }
    // Use this for initialization
    void Start () {
        GameObject[] tempPlayers = GameObject.FindGameObjectsWithTag("Player");
        foreach(GameObject parPlayers in tempPlayers)
        {
            _playerList.Add(parPlayers.GetComponent<Player>());
        }
        _playerList.Reverse();
        HideIndicators();
        _initialCamPosition = Camera.main.transform.position;
    }

	// Update is called once per frame
	void Update () {
        
        if (XInput.instance.getButton (0, 'R') == ButtonState.Pressed)
        {
            Debug.Log("test");
        }
        float h = XInput.instance.getYStick(0);
        float v = XInput.instance.getXStick(0);

        float triggerRight = XInput.instance.getRightTrigger(0);
        float triggerLeft = XInput.instance.getLeftTrigger(0);

        if (TurnManager.GetInstance()._whoPlays == 0)
        {
            if (v > 0.4 && _advancedPlayer == null)
            {
                if (!_playerList[0].isAdvanced)
                {
                    
                    _selectedPlayer = (Player)_playerList[0];
                    HideIndicators();
                    _indicatorPlayer[0].SetActive(true);
                }
            }
            if (Input.GetKey(KeyCode.Z) || h > 0.4 && _advancedPlayer == null)
            {
                if (!_playerList[2].isAdvanced)
                {
                    _selectedPlayer = (Player)_playerList[2];
                    HideIndicators();
                    _indicatorPlayer[2].SetActive(true);
                }
            }
            if (Input.GetKey(KeyCode.E) || h < -0.4 && _advancedPlayer == null)
            {
                if (!_playerList[1].isAdvanced)
                {
                    _selectedPlayer = (Player)_playerList[1];
                    HideIndicators();
                    _indicatorPlayer[1].SetActive(true);
                }
            }

            if( h == 0 && v == 0)
            {
                _selectedPlayer = null;
                HideIndicators();
            }

            if (triggerRight > 0.5f && _selectedPlayer != null && !_selectedPlayer.isAdvanced )
            {
                AllBack();
                _selectedPlayer.isAdvanced = true;
                _advancedPlayer = _selectedPlayer;
                _advancedPlayer.MoveToTarget(MonsterManager.GetInstance()._monsterList);
            
            }
            if (triggerLeft > 0.5f && _advancedPlayer != null)
            {
                _advancedPlayer.isAdvanced = false;
                _advancedPlayer.Back();
                _advancedPlayer = null;
                //Camera.main.transform.DOLookAt(initialCamPosition, 0.5f);
                //Camera.main.DOFieldOfView(60, 1f);
            }

            if (XInput.instance.getButton(0, 'A') == ButtonState.Pressed && !isButtonA && _advancedPlayer.isAdvanced && _advancedPlayer._breath > _advancedPlayer._listOfAttacks[0]._damageToBreath)
            {
                Debug.Log("toto");
                _advancedPlayer.Attack(0, MonsterManager.GetInstance()._monsterList);
                isButtonA = true;
            }else if(XInput.instance.getButton(0, 'A') == ButtonState.Released && isButtonA)
            {
                isButtonA = false;
            }

            //if (Input.GetButtonDown("B_button_1") && advancedPlayer.isAdvanced && advancedPlayer.canAttack && !isInCombo)
            //{
            //    advancedPlayer.AttackB();
            //}

            //if(Input.GetButtonDown("X_button_1") && advancedPlayer.isAdvanced && advancedPlayer.canAttack && !isInCombo)
            //{
            //    StartCoroutine(MyCombo());
            //}

            //if (Input.GetButtonDown("A_button_1") && advancedPlayer.isAdvanced && advancedPlayer.canAttack && isInCombo)
            //{
            //    advancedPlayer.AttackCombo();
            //}
        }
    }

    public void AllBack()
    {
        foreach(Player players in _playerList)
        {
            players.Back();
        }
            //Camera.main.transform.DOLookAt(_initialCamPosition, 0.5f);
            //Camera.main.DOFieldOfView(60, 1f);
    }

    void HideIndicators()
    {
        foreach (GameObject parIndicators in _indicatorPlayer)
        {
            parIndicators.SetActive(false);
        }
    }

    
}
