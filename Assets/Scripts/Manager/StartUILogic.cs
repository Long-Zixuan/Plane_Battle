using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartUILogic : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void StartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Scenes/SampleScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    
}
