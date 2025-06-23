using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlaneLogic : MonoBehaviour
{
    public GameObject bullet;
    public float bulletSpeed = 5f;
    
    private Transform mainGun_;
    private Transform leftGun_;
    private Transform rightGun_;
    // Start is called before the first frame update
    void Start()
    {
        mainGun_ = GameObject.Find("MainGun").transform;
        leftGun_ = GameObject.Find("LeftGun").transform;
        rightGun_ = GameObject.Find("RightGun").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }
    }

    void Fire()
    {
        GameObject bul = initBullet(leftGun_, bullet);
        bul.GetComponent<Rigidbody2D>().velocity = new Vector2(0,bulletSpeed);
        bul = initBullet(rightGun_, bullet);
        bul.GetComponent<Rigidbody2D>().velocity = new Vector2(0,bulletSpeed);
    }

    GameObject initBullet(Transform gun, GameObject bullet)
    {
        GameObject bul = Instantiate(bullet);
        bul.transform.position = gun.position;
        return bul;
    }
    
}
