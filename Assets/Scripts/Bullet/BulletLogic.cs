using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletLogic : MonoBehaviour,IObjectInScene
{
    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.AddListener(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnBecameInvisible()
    {
        GameManager.Instance.RemoveListener(this);
        Destroy(gameObject);
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            try
            {
                StartCoroutine(hitEnemyLogic(other.gameObject));
                //other.gameObject.GetComponent<BaseEnemy>().Hit(1);
                //other.gameObject.GetComponent<PlaneAnimationLogic>().switchAniMachine("hit");
            }
            catch (Exception e)
            {
                print(e.ToString());
            }
        }
        Destroy(gameObject);
    }

    IEnumerator hitEnemyLogic(GameObject obj)
    {
        obj.GetComponent<BaseEnemy>().Hit(1);
        obj.GetComponent<PlaneAnimationLogic>().switchAniMachine("hit");
        yield return new WaitForSeconds(0.2f);
        obj.GetComponent<PlaneAnimationLogic>().switchAniMachine("idle");
    }

    public void OnGameOver()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }
}
