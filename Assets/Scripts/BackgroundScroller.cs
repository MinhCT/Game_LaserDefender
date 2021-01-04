using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    [SerializeField] float backgroundScrollSpeed = 0.5f;
    Material bgMaterial;
    Vector2 offset;

    void Start()
    {
        bgMaterial = GetComponent<Renderer>().material;
        offset = new Vector2(0, backgroundScrollSpeed);
    }

    void Update()
    {
        bgMaterial.mainTextureOffset += offset * Time.deltaTime;
    }
}
