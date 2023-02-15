using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitButtonGame : MonoBehaviour
{
    public string creditScene;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void endGame()
    {
        SceneManager.LoadScene(creditScene);
    }
}
