using UnityEngine;


public class Cloud_spawn_script : MonoBehaviour
{
    public GameObject Cloud;
    public float spawnRate = 2;
    private float timer = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawnRate)
        {
            timer = timer + Time.deltaTime;
        }
        else
        {
            Instantiate(Cloud, transform.position, transform.rotation);
            timer = 0;
        }
        
        
    }
}
