using UnityEngine;
using System.Collections;
using DG.Tweening;
using XInputDotNetPure;
public class ObjetBRrrrr : MonoBehaviour {

    bool isEnter;
    public CanvasGroup canvasGroup;
    bool isButtonA;
	// Use this for initialization
	void Start () {
        canvasGroup.DOFade(0, 0f);
    }
	
	// Update is called once per frame
	void Update () {
        this.transform.DOShakeRotation(0.1f, 1f, 5).OnComplete(() => this.transform.DOKill());
        if (XInput.instance.getButton(0, 'A') == ButtonState.Pressed && isEnter && !isButtonA)
        {
            isButtonA = true;
            canvasGroup.DOFade(0, 0.3f);
            Destroy(this.gameObject);

        }else if (XInput.instance.getButton(0, 'A') == ButtonState.Released && isButtonA)
        {
            isButtonA = false;
        }
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            canvasGroup.DOFade(1, 0.3f);
            isEnter = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            canvasGroup.DOFade(0, 0.3f);
            isEnter = false;
        }
    }
}
