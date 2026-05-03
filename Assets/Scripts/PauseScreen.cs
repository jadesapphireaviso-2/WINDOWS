using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem; // ← added

public class PauseScreen : MonoBehaviour
{
    [SerializeField] GameObject pausePanel;
    bool isPaused = false;

    private void Start()
    {
        pausePanel.SetActive(false);
    }

    public void Pause()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void PauseResume()
    {
        Time.timeScale = 1f;
        isPaused = false;
        pausePanel.SetActive(false);
    }

    public void PauseQuit()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Start Screen"); 
    }

    private void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame) 
        {
            if (isPaused)
                PauseResume();
            else
                Pause();
        }
    }
}