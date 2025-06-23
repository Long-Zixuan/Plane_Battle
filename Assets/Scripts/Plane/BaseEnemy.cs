using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : MonoBehaviour,IObjectInScene
{
    public int score;
    
    public int health;

    public float moveSpeed = 1f;

    protected AudioSource adDie;
    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.AddListener(this);
        adDie = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);
        if (health <= 0)
        {
            DieLogic();
        }
    }

    void DieLogic()
    {
        moveSpeed = 0;
        gameObject.layer = LayerMask.NameToLayer("DieEnemy");
        adDie.Play();
        GetComponent<PlaneAnimationLogic>().switchAniMachine("die");
        Invoke("DestroySelf", 1f);
    }

    void DestroySelf()
    {
        GameManager.Instance.score += score;
        Destroy(gameObject);
    }
    
    protected void OnBecameInvisible()
    {
        GameManager.Instance.score -= score;
        GameManager.Instance.RemoveListener(this);
        Destroy(gameObject);
    }

    public void Hit(int damage)
    {
        health -= damage;
    }

    public void OnGameOver()
    {
        moveSpeed = 0;
    }
}
