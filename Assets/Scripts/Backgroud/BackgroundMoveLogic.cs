using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMoveLogic : MonoBehaviour
{
    public float speed = 1f;

    private float bgHeight = 8;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0,-speed * Time.deltaTime, 0);
    }

    private void OnBecameInvisible()
    {
        //print(gameObject.name+":Invisible");
        transform.position = new Vector3(0, bgHeight, 0);
    }
}
