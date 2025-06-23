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
