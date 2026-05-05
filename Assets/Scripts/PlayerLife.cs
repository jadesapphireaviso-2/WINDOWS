using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class PlayerLife : MonoBehaviour
{
    //TESTING FOR LIVES
    /*if (Keyboard.current.lKey.wasPressedThisFrame)
    GetComponent<PlayerLife>().LoseLife();
    */

    [Header("Lives")]
    [SerializeField] int maxLives = 3;
    int currentLives;

    [Header("Hearts")]
    [SerializeField] Image heart1;
    [SerializeField] Image heart2;
    [SerializeField] Image heart3;

    [Header("Fade")]
    [SerializeField] Image fadePanel;
    [SerializeField] float fadeDuration = 1.5f;

    [Header("Story Messages")]
    [SerializeField] TextMeshProUGUI storyMessage;
    string[] lostLifeMessages = {
        "Don't give up... you're still fighting.",
        "You're slipping away... hold on.",
        "You've let go..."
    };

    // respawn
    Vector3 respawnPoint;

    private void Awake()
    {
        // only one PlayerLife exists across all scenes
        if (FindObjectsByType<PlayerLife>(FindObjectsSortMode.None).Length > 1)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
        currentLives = maxLives;
        respawnPoint = transform.position;
    }

    public void SetRespawnPoint(Vector3 point)
    {
        respawnPoint = point;
    }

    public void LoseLife()
    {
        if (currentLives <= 0) return;

        currentLives--;
        UpdateHearts();

        if (currentLives <= 0)
            StartCoroutine(GameOver());
        else
            StartCoroutine(LostLifeSequence());
    }

    void UpdateHearts()
    {
        // fade out hearts based on lives lost
        if (currentLives < 3) heart3.color = new Color(1, 0, 0, 0.2f);
        if (currentLives < 2) heart2.color = new Color(1, 0, 0, 0.2f);
        if (currentLives < 1) heart1.color = new Color(1, 0, 0, 0.2f);
    }

    IEnumerator LostLifeSequence()
    {
        // show message
        storyMessage.text = lostLifeMessages[maxLives - currentLives - 1];

        // fade to black
        yield return StartCoroutine(Fade(1f));

        // wait so player can read message
        yield return new WaitForSeconds(2f);

        // respawn player
        transform.position = respawnPoint;

        // fade back in
        storyMessage.text = "";
        yield return StartCoroutine(Fade(0f));
    }

    IEnumerator GameOver()
    {
        // show final message
        storyMessage.text = lostLifeMessages[2];

        // fade to black permanently
        yield return StartCoroutine(Fade(1f));
        yield return new WaitForSeconds(2f);

        // load death screen
        SceneManager.LoadScene("DeathScreen");
    }

    IEnumerator Fade(float targetAlpha)
    {
        float startAlpha = fadePanel.color.a;
        float time = 0f;

        while (time < fadeDuration)
        {
            time += Time.deltaTime;
            float alpha = Mathf.Lerp(startAlpha, targetAlpha, time / fadeDuration);
            fadePanel.color = new Color(0, 0, 0, alpha);
            yield return null;
        }

        fadePanel.color = new Color(0, 0, 0, targetAlpha);
    }
}