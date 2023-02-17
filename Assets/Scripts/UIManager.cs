using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{

    public void PlayOval()
    {
        SceneManager.LoadScene("OvalTrack");
    }

    public void PlayStunt()
    {
        SceneManager.LoadScene("StuntTrack");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
