using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using DG.Tweening;
public class Monster : MonoBehaviour {
    public int healthMax;
    public int health;
    public ParticleSystem particles;
    public Canvas myManaCanvas;
    public Text manaText;
    public ParticleSystem particlesCombo;
    // Use this for initialization
    void Start () {
        healthMax = 40;
        health = healthMax;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void GetDamage(int damage, bool isCombo)
    {
        //Camera.main.DOKill(true);
        //Camera.main.DOShakePosition(0.5f, 2, 10, 30);
        health -= damage;
        if(health <= 0)
        {
            Dead();
        }

        if (isCombo)
        {
            particlesCombo.Play();
        }
        else
        {
            particles.Play();
        }
    }

    void Dead()
    {
        this.gameObject.SetActive(false);
    }
}
