using UnityEngine;

public class PlayerCollectScript : MonoBehaviour
{

    public GameObject quizUI;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Collectable"))
        {
            Time.timeScale = 0f;
            quizUI.SetActive(true);
            Destroy(other.gameObject);
        }
    }
}
