using UnityEngine;

public class Key : MonoBehaviour
{
    bool isActivated = false;

    // call this when puzzle is solved or room is explored
    public void ActivateKey()
    {
        isActivated = true;
        // TODO: add glow effect here later when you have your key model
        Debug.Log("Key activated! Walk over it to collect.");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isActivated) return;

        if (other.CompareTag("Player"))
        {
            Collectables collectables = other.GetComponent<Collectables>();
            if (collectables != null)
                collectables.CollectKey();

            Destroy(gameObject);
        }
    }
}