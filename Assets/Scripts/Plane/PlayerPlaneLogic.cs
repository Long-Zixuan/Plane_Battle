using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlaneLogic : MonoBehaviour,IObjectInScene
{
    public float fireTime = 0.5f;
    
    public GameObject bullet;
    public float bulletSpeed = 5f;

    private AudioSource adFire;

    public bool IsDie
    {
        get
        {
            return isDie_;
        }
    }

    private bool isDie_;

    private bool canMove = true;
    
    private Transform mainGun_;
    private Transform leftGun_;
    private Transform rightGun_;
    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.AddListener(this);
        mainGun_ = GameObject.Find("MainGun").transform;
        leftGun_ = GameObject.Find("LeftGun").transform;
        rightGun_ = GameObject.Find("RightGun").transform;
        adFire = GetComponent<AudioSource>();
        InvokeRepeating("Fire", 0.1f, fireTime);;
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }*/
        Move();
    }

    void Fire()
    {
        GameObject bul = initBullet(leftGun_, bullet);
        bul.GetComponent<Rigidbody2D>().velocity = new Vector2(0,bulletSpeed);
        bul = initBullet(rightGun_, bullet);
        adFire.Play();
        bul.GetComponent<Rigidbody2D>().velocity = new Vector2(0,bulletSpeed);
    }

    GameObject initBullet(Transform gun, GameObject bullet)
    {
        GameObject bul = Instantiate(bullet);
        bul.transform.position = gun.position;
        return bul;
    }

    void Move()
    {
        if (Input.GetMouseButton(0) && canMove)
        {
            Vector3 planePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (planePos.x < -2.6f)
                planePos.x = -2.6f;
            if (planePos.x >2.6f)
                planePos.x = 2.6f;
            if (planePos.y>4.4f)
                planePos.y = 4.4f;
            if (planePos.y<-4.4f)
                planePos.y =-4.4f;
            transform.position = new Vector3(planePos.x, planePos.y, 0);
        }
    }

    public void OnGameOver()
    {
        canMove = false;
        CancelInvoke("Fire");
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            isDie_ = true;
            GetComponent<PlaneAnimationLogic>().switchAniMachine("die",false);
        }
    }
    
    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            isDie_ = true;
            GetComponent<PlaneAnimationLogic>().switchAniMachine("die",false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            isDie_ = true;
            GetComponent<PlaneAnimationLogic>().switchAniMachine("die",false);
        }
    }
    
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            isDie_ = true;
            GetComponent<PlaneAnimationLogic>().switchAniMachine("die",false);
        }
    }
}
