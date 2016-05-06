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
        //float h = Input.GetAxisRaw("L_YAxis_1");
        //float v = Input.GetAxisRaw("L_XAxis_1");

        //float triggerRight = Input.GetAxisRaw("TriggersR_1");
        //float triggerLeft = Input.GetAxisRaw("TriggersL_1");

        if (TurnManager.GetInstance()._whoPlays == 0)
        {
            //if (Input.GetKey(KeyCode.A) || v > 0.4 && advancedPlayer == null )
            //{
            //    if (!players[0].isAdvanced)
            //    {
            //        selectedPlayer = players[0];
            //        HideIndicators();
            //        indicatorPlayer[0].SetActive(true);
            //    }
            //}
            //if (Input.GetKey(KeyCode.Z) || h > 0.4 && advancedPlayer == null)
            //{
            //    if (!players[1].isAdvanced)
            //    {
            //        selectedPlayer = players[1];
            //        HideIndicators();
            //        indicatorPlayer[1].SetActive(true);
            //    }
            //}
            //if (Input.GetKey(KeyCode.E) || h < -0.4 && advancedPlayer == null)
            //{
            //    if (!players[2].isAdvanced)
            //    {
            //        selectedPlayer = players[2];
            //        HideIndicators();
            //        indicatorPlayer[2].SetActive(true);
            //    }
            //}

            //if( h == 0 && v == 0)
            //{
            //    selectedPlayer = null;
            //    HideIndicators();
            //}

            //if (triggerRight > 0.5f && selectedPlayer != null && !selectedPlayer.isAdvanced )
            //{
            //    allBack();
            //    selectedPlayer.isAdvanced = true;
            //    advancedPlayer = selectedPlayer;
            //    advancedPlayer.Advance();
              
            //}
            //if (triggerLeft > 0.5f && advancedPlayer != null)
            //{
            //    //advancedPlayer.isAdvanced = false;
            //    //advancedPlayer.Back();
            //    advancedPlayer = null;
            //    Camera.main.transform.DOLookAt(initialCamPosition, 0.5f);
            //    Camera.main.DOFieldOfView(60, 1f);
            //}

            //if (Input.GetButtonDown("A_button_1") && advancedPlayer.isAdvanced && advancedPlayer.canAttack && !isInCombo)
            //{
            //    advancedPlayer.AttackA();
            //}

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
            //players.Back();
        }
            //Camera.main.transform.DOLookAt(initialCamPosition, 0.5f);
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
