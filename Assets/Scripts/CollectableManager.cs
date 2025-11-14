using UnityEngine;
using UnityEngine.UI;
public class CollectableManager : MonoBehaviour
{
    public int CollectableCount;
    public Text CollectableText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CollectableText.text =  CollectableCount.ToString();
    }
}
