using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneAnimationLogic : MonoBehaviour
{
    public Sprite[] idleframe;
    public Sprite[] dieframe;
    public Sprite[] hitframe;
    
    Sprite[] frame = null;

    private Dictionary<string, Sprite[]> aniDic;
    
    public float animationPlaySpeed = 10;
    //老师说这个用代码实现，无敌了，真的无敌了
    // Start is called before the first frame update
    void Start()
    {
        frame = idleframe;
        StartCoroutine(AnimationPlayLogic());
        aniDic = new Dictionary<string, Sprite[]>();
        aniDic.Add("idle", idleframe);
        aniDic.Add("die", dieframe);
        aniDic.Add("hit", hitframe);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    int aniFramedir_ = 0;
    IEnumerator AnimationPlayLogic()
    {
        
        while (true)
        {
            aniFramedir_ = aniFramedir_ % frame.Length;
            GetComponent<SpriteRenderer>().sprite = frame[aniFramedir_];
            aniFramedir_++;
            yield return new WaitForSeconds(1 / animationPlaySpeed);
        }
    }

    public void switchAniMachine(string tag)
    {
        try
        {
            //aniFramedir_ = 0;
            frame = aniDic[tag];
        }
        catch (System.Exception e)
        {
            print(e);
        }
        
    }
    
}
