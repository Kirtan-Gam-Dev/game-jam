using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartLevel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void ResetLevel()
    {
        SceneManager.LoadScene("Main");
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
