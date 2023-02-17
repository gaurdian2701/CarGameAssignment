using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public GameObject pauseMenu;
    public bool isPaused;
    private CarControls carControls;
    private InputAction menu;
    // Start is called before the first frame update
    void Awake()
    {
        pauseMenu.SetActive(false);
        carControls = new CarControls();
    }

    private void OnEnable()
    {
        menu = carControls.Menu.Escape;
        menu.Enable();
        menu.performed += PauseGame;
    }

    private void OnDisable()
    {
        menu.Disable();
    }

    void Update()
    {
        //if (Keyboard.current[Key.Escape].isPressed)
        //{
        //    Debug.Log("ESC");
        //    if (isPaused)
        //        ResumeGame();
        //    else
        //        PauseGame();
        //}
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void PauseGame(InputAction.CallbackContext context)
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }
    // Update is called once per frame
    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }
}
