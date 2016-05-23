using UnityEngine;
using System.Collections;
using DG.Tweening;
using UnityEngine.UI;
public class PlayerManager : MonoBehaviour {
    public Player[] players;
    public Player selectedPlayer;
    public Player advancedPlayer;

    public GameObject[] indicatorPlayer;
    public Vector3 initialCamPosition;
    public Quaternion initialCamRotation;
    bool isInCombo;

    bool isInSelect;

    public Image Left_Stick;
    public Image Croix;
    public Image Button_RT;
    // Use this for initialization
    void Start () {
	    for(int i = 0; i < players.Length; i++)
        {
            players[i].playerID = i;
            indicatorPlayer[i].SetActive(false);
        }
        isInCombo = false;
        initialCamPosition = Camera.main.transform.position;
        initialCamRotation = Camera.main.transform.rotation;
        isInSelect = false;

        Left_Stick.DOFade(0, 0.2f);
        Croix.DOFade(0, 0.2f);
        Button_RT.DOFade(0, 0.2f);
    }
	
	// Update is called once per frame
	void Update () {
        Debug.Log(isInCombo);
        if (Input.GetKey(KeyCode.G))
        {
            //Camera.main.DOFieldOfView(30, 1);
            
            
        }

        if (Input.GetKey(KeyCode.H))
        {
            
        }
        float h = Input.GetAxisRaw("L_YAxis_1");
        float v = Input.GetAxisRaw("L_XAxis_1");

        float triggerRight = Input.GetAxisRaw("TriggersR_1");
        float triggerLeft = Input.GetAxisRaw("TriggersL_1");

        if (TurnManager.GetInstance().whoPlays == 0)
        {
            if (Input.GetKey(KeyCode.A) || v > 0.4 && advancedPlayer == null )
            {
                if (!players[0].isAdvanced)
                {
                    selectedPlayer = players[0];
                    HideIndicators();
                    indicatorPlayer[0].SetActive(true);
                    indicatorPlayer[0].GetComponentInChildren<ParticleSystem>().Play();
                    Left_Stick.DOFade(1, 0.2f);
                    //Croix.DOFade(1, 0.2f);
                    //Button_RT.DOFade(1, 0.2f);
                }
            }
            if (Input.GetKey(KeyCode.Z) || h > 0.4 && advancedPlayer == null)
            {
                if (!players[1].isAdvanced)
                {
                    selectedPlayer = players[1];
                    HideIndicators();
                    indicatorPlayer[1].SetActive(true);
                    indicatorPlayer[1].GetComponentInChildren<ParticleSystem>().Play();
                    Left_Stick.DOFade(1, 0.2f);
                    //Croix.DOFade(1, 0.2f);
                    //Button_RT.DOFade(1, 0.2f);
                }
            }
            if (Input.GetKey(KeyCode.E) || h < -0.4 && advancedPlayer == null)
            {
                if (!players[2].isAdvanced)
                {
                    selectedPlayer = players[2];
                    HideIndicators();
                    indicatorPlayer[2].SetActive(true);
                    indicatorPlayer[2].GetComponentInChildren<ParticleSystem>().Play();
                    Left_Stick.DOFade(1, 0.2f);
                    //Croix.DOFade(1, 0.2f);
                    //Button_RT.DOFade(1, 0.2f);
                }
            }

            if( h == 0 && v == 0)
            {
                selectedPlayer = null;
                HideIndicators();
                Left_Stick.DOFade(0, 0.2f);
                Croix.DOFade(0, 0.2f);
                Button_RT.DOFade(0, 0.2f);
            }

            if (triggerRight > 0.5f && selectedPlayer != null && !selectedPlayer.isAdvanced )
            {
                allBack();
                selectedPlayer.isAdvanced = true;
                advancedPlayer = selectedPlayer;
                advancedPlayer.Advance();
                Croix.DOFade(1, 0.2f);
                Button_RT.DOFade(1, 0.2f);

            }
            if (triggerLeft > 0.5f && advancedPlayer != null)
            {
                advancedPlayer.isAdvanced = false;
                advancedPlayer.Back();
                advancedPlayer = null;
                Camera.main.transform.DOMove(initialCamPosition, 0.5f);
                Camera.main.transform.DORotateQuaternion(initialCamRotation, 0.5f);
                Camera.main.DOFieldOfView(60, 1f);
            }

            if (Input.GetButtonDown("A_button_1") && advancedPlayer.isAdvanced && advancedPlayer.canAttack && !isInCombo)
            {
                advancedPlayer.AttackA();
            }

            if (Input.GetButtonDown("B_button_1") && advancedPlayer.isAdvanced && advancedPlayer.canAttack && !isInCombo)
            {
                advancedPlayer.AttackB();
            }

            if(Input.GetButtonDown("X_button_1") && advancedPlayer.isAdvanced && advancedPlayer.canAttack && !isInCombo)
            {
                StartCoroutine(MyCombo());
            }

            if (Input.GetButtonDown("A_button_1") && advancedPlayer.isAdvanced && advancedPlayer.canAttack && isInCombo)
            {
                advancedPlayer.AttackCombo();
            }
        }
    }

    public void allBack()
    {
        for (int i = 0; i < players.Length; i++)
        {
            players[i].Back();
        }

            Camera.main.transform.DOMove(initialCamPosition, 0.5f);
            Camera.main.transform.DORotateQuaternion(initialCamRotation, 0.5f);
            Camera.main.DOFieldOfView(60, 1f);
    }

    void HideIndicators()
    {
        for(int i =0; i < indicatorPlayer.Length; i++)
        {
            indicatorPlayer[i].SetActive(false);
        }
    }

    IEnumerator MyCombo()
    {
        isInCombo = true;
        float timer = 1;
        while (timer > 0)
        {
            timer -= Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        isInCombo = false;
        yield break;
    }
}
