using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    public float speed;
    private float dazedTime;
    public float startDazedTime;
    public AudioSource m_DeathSound;

    
    public GameObject bloodEffect;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(dazedTime <= 0)
        {
            speed = 0;
        }
        else
        {
            speed = 1;
            dazedTime -= Time.deltaTime;
        }
        if (health <= 0)
        {
            m_DeathSound.Play();
            Destroy(gameObject);
        }
        transform.Translate(Vector2.left * speed * Time.deltaTime);

    }

    public void TakeDamage(int damage)
    {
        dazedTime += startDazedTime;
        Instantiate(bloodEffect, transform.position, Quaternion.identity);
        health -= damage;
        Debug.Log("damage taken");
    }
}