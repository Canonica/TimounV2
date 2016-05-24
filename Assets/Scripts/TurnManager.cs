using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using DG.Tweening;
public class TurnManager : MonoBehaviour {

    private static TurnManager instance = null;

    public Image _timer;
    public float _maxTimeTurn;
    public float _currentTimeTurn;
    public bool _isPlaying;

    public int _whoPlays;
    bool m_changingTurn;

    public Text _textTurn;
    public PlayerManager _allPlayers;

    public static TurnManager GetInstance()
    {
        return instance;
    }

    void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
        _maxTimeTurn = 10;
        _currentTimeTurn = _maxTimeTurn;
        _isPlaying = false;
        _whoPlays = 0;
        _textTurn.text = "Player Turn";
    }

    void Update()
    {
        _currentTimeTurn -= Time.deltaTime;
        if (!_isPlaying)
        {
            _isPlaying = true;
            StartCoroutine(WaitForCdfloat(_maxTimeTurn));
        }
        if(_currentTimeTurn <= 0 && !m_changingTurn)
        {
            
            StartCoroutine(WaitBetweenTurn(1.0f));
            //changeTurn();
        }
    }

    void changeTurn()
    {
        m_changingTurn = false;
        _currentTimeTurn = _maxTimeTurn;
        _timer.fillAmount = 1;
        StartCoroutine(WaitForCdfloat(_maxTimeTurn));
        if(_whoPlays == 0)
        {
            _whoPlays = 1;
            _textTurn.text = "Monster Turn";
            
        }
        else if (_whoPlays == 1)
        {
            _whoPlays = 0;
            _textTurn.text = "Player Turn";
        }
        _textTurn.transform.DOShakePosition(0.1f, 10);
    }
    public IEnumerator WaitBetweenTurn(float parCdTimer)
    {
        m_changingTurn = true;
        PlayerManager.GetInstance().AllBack();
        //_allPlayers.AllBack();
        PlayerManager.GetInstance()._advancedPlayer = null;
        yield return new WaitForSeconds(parCdTimer);
        changeTurn();
    }

    public IEnumerator WaitForCdfloat(float parCdTimer)
    {
            _timer.fillAmount = 1;
            yield return StartCoroutine(fillIcon(_timer, parCdTimer));
    }

    public IEnumerator fillIcon(Image parIcon, float parCdTimer)
    {
        float _timer = _maxTimeTurn;
        while (_timer <= parCdTimer)
        {
            parIcon.fillAmount = _timer / parCdTimer;
            _timer -= Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        _timer = 0;
    }
}
