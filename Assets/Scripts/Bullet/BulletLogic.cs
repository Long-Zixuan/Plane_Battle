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
                other.gameObject.GetComponent<BaseEnemy>().Hit(1);
            }
            catch (Exception e)
            {
                print(e.ToString());
            }
        }
        Destroy(gameObject);
    }

    

    public void OnGameOver()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }
}
