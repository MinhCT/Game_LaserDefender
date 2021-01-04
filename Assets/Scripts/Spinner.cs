using UnityEngine;

public class Spinner : MonoBehaviour
{
    [SerializeField] float spinSpeed = 1f;

    private void Update()
    {
        transform.Rotate(0, 0, spinSpeed * Time.deltaTime);
    }
}
