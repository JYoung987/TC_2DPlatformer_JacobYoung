using System;
using UnityEngine;

public class StartScreen : MonoBehaviour
    
{
    public float m_Duration = 5;
    private float m_Elapsed = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    
        if(m_Elapsed < m_Duration)
        {
            Debug.Log("Running");
            Color color = gameObject.GetComponent<SpriteRenderer>().color;
            float alpha = color.a;
            alpha = Mathf.Lerp(1f, 0f, m_Elapsed / m_Duration);
            color.a = alpha;
            gameObject.GetComponent<SpriteRenderer>().color = color;
            m_Elapsed += Time.deltaTime;
        }
    }
}
