using UnityEngine;
using UnityEngine.UI;

//UI
//Keys
//Flashlight?
//Batteries


public class Collectables : MonoBehaviour
{
    [Header("Keys")]
    public int keysCollected = 0;
    public int totalKeys = 3;

    [Header("Key Icons")]
    [SerializeField] Image keyIcon1;
    [SerializeField] Image keyIcon2;
    [SerializeField] Image keyIcon3;
    
    [Header("Colors")]
    [SerializeField] Color dimColor = new Color(1, 1, 1, 0.2f);   // dim = not collected
    [SerializeField] Color brightColor = new Color(1, 1, 1, 1f);  // bright = collected

    private void Awake()
    {
        // persist across scenes like PlayerLife
        if (FindObjectsByType<Collectables>(FindObjectsInactive.Include).Length > 1)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
        ResetKeyIcons();
    }

    void ResetKeyIcons()
    {
        keyIcon1.color = dimColor;
        keyIcon2.color = dimColor;
        keyIcon3.color = dimColor;
    }

    public void CollectKey()
    {
        if (keysCollected >= totalKeys) return;

        keysCollected++;
        UpdateKeyUI();

        // TODO: play sound here later

        if (keysCollected >= totalKeys)
            Debug.Log("All keys collected!"); // we'll hook up win condition later
    }

    void UpdateKeyUI()
    {
        if (keysCollected >= 1) keyIcon1.color = brightColor;
        if (keysCollected >= 2) keyIcon2.color = brightColor;
        if (keysCollected >= 3) keyIcon3.color = brightColor;
    }
}
