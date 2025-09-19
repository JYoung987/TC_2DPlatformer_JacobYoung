using UnityEngine;

public class Parallax_scrolling1 : MonoBehaviour
{
    [System.Serializable]
    public class ParallaxLayer
    {
        public Transform[] sprites; // Two copies of the seamless background
        public float parallaxSpeed = 0.5f;
        [HideInInspector] public float spriteWidth;
    }

    public ParallaxLayer[] layers;
    public Transform cameraTransform;

    private Vector3 previousCamPos;

    void Start()
    {
        if (cameraTransform == null)
            cameraTransform = Camera.main.transform;

        previousCamPos = cameraTransform.position;

        // Calculate width of each layer
        foreach (var layer in layers)
        {
            if (layer.sprites.Length > 0)
            {
                SpriteRenderer sr = layer.sprites[0].GetComponent<SpriteRenderer>();
                layer.spriteWidth = sr.bounds.size.x;
            }
        }
    }

    void LateUpdate()
    {
        Vector3 smoothedPosition = Vector3.Lerp(previousCamPos, cameraTransform.position, Time.deltaTime * 5f);
        Vector3 delta = smoothedPosition - previousCamPos;
        delta.x = Mathf.Clamp(delta.x, -0.5f, 0.5f);



        foreach (var layer in layers)
        {
            foreach (var sprite in layer.sprites)
            {
                sprite.position += new Vector3(delta.x * layer.parallaxSpeed * 0.1f, 0, 0);

            }

            // Looping logic
            Transform left = layer.sprites[0];
            Transform right = layer.sprites[1];

            if (cameraTransform.position.x > right.position.x)
            {
                left.position = new Vector3(right.position.x + layer.spriteWidth, left.position.y, left.position.z);
                Swap(layer.sprites);
            }
            else if (cameraTransform.position.x < left.position.x)
            {
                right.position = new Vector3(left.position.x - layer.spriteWidth, right.position.y, right.position.z);
                Swap(layer.sprites);
            }
        }

        previousCamPos = cameraTransform.position;
    }

    void Swap(Transform[] array)
    {
        Transform temp = array[0];
        array[0] = array[1];
        array[1] = temp;
    }
}
