using System;
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
        if (gameObject.layer == LayerMask.NameToLayer("DieEnemy"))
        {
            return;
        }
        moveSpeed = 0;
        gameObject.layer = LayerMask.NameToLayer("DieEnemy");
        adDie.Play();
        GetComponent<PlaneAnimationLogic>().switchAniMachine("die",false);
        GameManager.Instance.score += score;
        Invoke("DestroySelf", 1f);
    }

    void DestroySelf()
    {
        GameManager.Instance.RemoveListener(this);
        Destroy(gameObject);
    }

    private bool isVisable_ = false;
    
    protected void OnBecameInvisible()
    {
        if (isVisable_ && health > 0)
        {
            print(gameObject.name+":missed");
            GameManager.Instance.score -= score;
        }
        DestroySelf();
    }

    private void OnBecameVisible()
    {
        isVisable_ = true;
    }

    public void Hit(int damage)
    {
        health -= damage;
        StartCoroutine(hitEnemyAniLogic(this.gameObject));
    }

    IEnumerator hitEnemyAniLogic(GameObject obj)
    {
        if (health > 0)
        {
            obj.GetComponent<PlaneAnimationLogic>().switchAniMachine("hit");
        }
        yield return new WaitForSeconds(0.2f);
        if(health > 0)
        {
            obj.GetComponent<PlaneAnimationLogic>().switchAniMachine("idle");
        }
    }

    public void OnGameOver()
    {
        moveSpeed = 0;
    }
}
