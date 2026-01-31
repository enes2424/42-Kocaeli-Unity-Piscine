using UnityEngine;

public class LavaScroll : MonoBehaviour
{
    public float speedY = 0.05f;

    Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    void Update()
    {
        rend.material.mainTextureOffset =
            new Vector2(0, Time.time * speedY);
    }
}
