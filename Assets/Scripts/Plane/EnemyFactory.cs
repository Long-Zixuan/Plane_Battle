using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : MonoBehaviour,IObjectInScene
{
    public GameObject[] enemy;

    public float genEnemyCreatTime = 1f;

    public float midEnemyCreatTime = 2f;
    public float bigEnemyCreatTime = 5f;

    private bool isGaming_ = true;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(creatGenEnemy());
        StartCoroutine(creatBigEnemy());
        StartCoroutine(creatMidEnemy());
        GameManager.Instance.AddListener(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator creatGenEnemy()
    {
        while (isGaming_)
        {
            yield return new WaitForSeconds(genEnemyCreatTime);
            GameObject en = Instantiate(enemy[0]);
            en.transform.position = new Vector3(Random.Range(-2.6f,2.6f), 5, 0);
        }
    }
    
    IEnumerator creatMidEnemy()
    {
        while (isGaming_)
        {
            yield return new WaitForSeconds(midEnemyCreatTime);
            GameObject en = Instantiate(enemy[2]);
            en.transform.position = new Vector3(Random.Range(-2.6f,2.6f), 5, 0);
        }
    }
    
    IEnumerator creatBigEnemy()
    {
        while (isGaming_)
        {
            yield return new WaitForSeconds(bigEnemyCreatTime);
            GameObject en = Instantiate(enemy[1]);
            en.transform.position = new Vector3(Random.Range(-2.6f,2.6f), 5, 0);
        }
    }

    public void OnGameOver()
    {
       isGaming_ = false;
    }
}
