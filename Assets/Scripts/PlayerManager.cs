using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using XInputDotNetPure;
public class PlayerManager : MonoBehaviour {
    private static PlayerManager _instance = null;

    public Player _selectedPlayer;
    public Player _advancedPlayer;
    public Player _focusedCharacter;
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
        //_playerList.Reverse();
        HideIndicators();
        _initialCamPosition = Camera.main.transform.position;
    }

    void SelectPlayer(float parh, float parV)
    {
        if (Input.GetKey(KeyCode.Z) || parh > 0.4 && _advancedPlayer == null)
        {
            if (!_playerList[0].isAdvanced)
            {
                _selectedPlayer = (Player)_playerList[0];
                HideIndicators();
                _indicatorPlayer[0].SetActive(true);
            }
        }
        if (Input.GetKey(KeyCode.E) || parh < -0.4 && _advancedPlayer == null)
        {
            if (!_playerList[1].isAdvanced)
            {
                _selectedPlayer = (Player)_playerList[1];
                HideIndicators();
                _indicatorPlayer[1].SetActive(true);
            }
        }

        if (parh == 0 && parV == 0)
        {
            _selectedPlayer = null;
            HideIndicators();
        }
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

        #region playerturn
        if (TurnManager.GetInstance()._whoPlays == 0)
        {
            /*if (v > 0.4 && _advancedPlayer == null)
            {
                if (!_playerList[0].isAdvanced)
                {
                    
                    _selectedPlayer = (Player)_playerList[0];
                    HideIndicators();
                    _indicatorPlayer[0].SetActive(true);
                }
            }*/
            /*if (Input.GetKey(KeyCode.Z) || h > 0.4 && _advancedPlayer == null)
            {
                if (!_playerList[0].isAdvanced)
                {
                    _selectedPlayer = (Player)_playerList[0];
                    HideIndicators();
                    _indicatorPlayer[0].SetActive(true);
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
            }*/
            SelectPlayer(h, v);

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
        #endregion
        #region monsterturn
        else if (TurnManager.GetInstance()._whoPlays == 1)
        {
            if(_focusedCharacter !=null)
            {
                if(XInput.instance.getButton(0, 'B') == ButtonState.Pressed)
                {
                    _focusedCharacter._paradeDiviser = 2;
                }else if(XInput.instance.getButton(0, 'B') == ButtonState.Released)
                {
                    _focusedCharacter._paradeDiviser = 1;
                }
            }
        }
        #endregion
    }

    public void AllBack()
    {
        _focusedCharacter = null;
        foreach(Player players in _playerList)
        {
            players.Back();
        }
       
            //Camera.main.transform.DOLookAt(_initialCamPosition, 0.5f);
            //Camera.main.DOFieldOfView(60, 1f);
    }

    public void HideIndicators()
    {
        foreach (GameObject parIndicators in _indicatorPlayer)
        {
            parIndicators.SetActive(false);
        }
    }

    
}
