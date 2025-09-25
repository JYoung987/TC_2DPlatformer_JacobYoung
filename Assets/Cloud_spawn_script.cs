using UnityEngine;


public class Cloud_spawn_script : MonoBehaviour
{
    public GameObject Cloud;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Instantiate(Cloud, transform.position, transform.rotation);
        
    }
}
