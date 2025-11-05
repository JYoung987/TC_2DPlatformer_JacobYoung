using NUnit.Framework.Constraints;
using UnityEngine;
using UnityEngine.UIElements;

public class Cloud_MoveScript : MonoBehaviour
{
    public float scrollSpeed = 2f;
    private float spriteWidth;
    private Vector3 startPosition;

    public Transform cloudDelete;

    void Start()
    {
        spriteWidth = GetComponent<SpriteRenderer>().bounds.size.x;
        startPosition = transform.position;
    }

    void Update()
    {
        transform.Translate(Vector2.left * scrollSpeed * Time.deltaTime);

        if (transform.position.x <= cloudDelete.transform.position.x)
        {
            transform.position += new Vector3(spriteWidth * 4f, 0f, 0f);
        }

    }

}