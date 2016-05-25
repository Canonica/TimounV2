using UnityEngine;
using System.Collections;
using DG.Tweening;

public class MoveMonster : MonoBehaviour {

    public Transform _monster;
    public Transform _start;
    public Transform _end;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider _collider)
    {
        Debug.Log("toto");
        if (_collider.gameObject.tag == "Player")
        {
            
            ShowMonster();
        }
    }

    void ShowMonster()
    {
        
        _monster.DOMove(_end.position, 1.0f).OnComplete(() => HideMonster());
    }

    void HideMonster()
    {
        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.5f);
        _monster.DOMove(_start.position, 1.0f);
    }
}
