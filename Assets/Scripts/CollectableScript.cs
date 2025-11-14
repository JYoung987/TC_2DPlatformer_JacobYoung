using UnityEngine;

public class CollectableScript : MonoBehaviour
{
    public GameObject quizUI; // Assign in Inspector

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            quizUI.SetActive(true); // Show the quiz UI
            Destroy(gameObject);    // Remove the collectable
        }
    }
}