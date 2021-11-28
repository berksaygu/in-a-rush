using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class MenuScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         
    }

    public void PlayButton()
    {
        SceneManager.LoadScene(1);
    }
    public void QuitButton()
    {
        Application.Quit(); 
    }
    public void ControlsButton()
    {
        SceneManager.LoadScene(2);
    }
    public void backToMenuButton()
    {
        SceneManager.LoadScene(0);
    }
}
