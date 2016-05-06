using UnityEngine;
using System.Collections;

public class TestManager : MonoBehaviour {
    
    public Entity _player;
	
	void Update () {
	    if(Input.GetButton(_player.GetComponent<SimpleAttack>()._input))
        {
            _player.GetComponent<SimpleAttack>().Execute(_player);
        }
	}
}
