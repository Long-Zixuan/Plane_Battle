using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationLogic : MonoBehaviour
{
    public Sprite[] frame;
    public float animationPlaySpeed = 10;
    //老师说这个用代码实现，无敌了，真的无敌了
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(AnimationPlayLogic());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator AnimationPlayLogic()
    {
        int dir = 0;
        while (true)
        {
            GetComponent<SpriteRenderer>().sprite = frame[dir];
            dir++;
            dir = dir % frame.Length;
            yield return new WaitForSeconds(1 / animationPlaySpeed);
        }
    }
    
    
}
