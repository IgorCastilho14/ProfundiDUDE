using UnityEngine;

public class SpaceshipMenu : MonoBehaviour
{
    [SerializeField] private float amplitude = 0.5f;     
    [SerializeField] private float speed = 1f;           

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        float yOffset = Mathf.Sin(Time.time * speed) * amplitude;
        transform.position = startPosition + new Vector3(0f, yOffset, 0f);
    }
}
