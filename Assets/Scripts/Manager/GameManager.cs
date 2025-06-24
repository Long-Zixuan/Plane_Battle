using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int score;

    public bool isGameOver;

    public List<IObjectInScene> listeners = new List<IObjectInScene>();

    public PlayerPlaneLogic player;


    private float top_;
    private float botton_;
    private float left_;
    private float right_;

    public float Top
    {
        get { return top_; }
    }

    public float Botton
    {
        get { return botton_; }
    }

    public float Left
    {
        get { return left_; }
    }

    public float Right
    {
        get { return right_; }
    }
    
    
    public void AddListener(IObjectInScene listener)
    {
        listeners.Add(listener);
    }

    public void RemoveListener(IObjectInScene listener)
    {
        listeners.Remove(listener);
    }
    
    public static GameManager Instance
    {
        get
        {
            return instance_s;
        }
    }
    private static GameManager instance_s;
    
    private void Awake()
    {
        Camera cam = Camera.main;
        Vector3 topLeft = cam.ViewportToWorldPoint(new Vector3(1, 1, cam.nearClipPlane));
        Vector3 bottonRight = cam.ViewportToWorldPoint(new Vector3(0, 0, cam.nearClipPlane));
        top_ = topLeft.y;
        botton_ = bottonRight.y;
        left_ = bottonRight.x;
        right_ = topLeft.x;
        print("top:"+top_);
        print("botton:"+botton_);
        print("left:"+left_);
        print("right:"+right_);
        if (instance_s != null)
        {
            Destroy(this);
            return;
        }
        instance_s = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.IsDie)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        foreach (var l in listeners)
        {
            l.OnGameOver();
        }
    }
}
