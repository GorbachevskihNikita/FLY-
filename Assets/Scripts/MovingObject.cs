using UnityEngine;


[DisallowMultipleComponent]
public class MovingObject : MonoBehaviour
{
    [SerializeField] private Vector3 movementVector;
    [SerializeField] private float movementSpeed;
    [SerializeField] [Range(0, 1)] private float movementProgress;
    private Vector3 _startPosition;

        // Start is called before the first frame update
    void Start()
    {
        _startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        movementProgress = Mathf.PingPong(Time.time * movementSpeed, 1);
        Vector3 displacement = movementVector * movementProgress;
        transform.position = _startPosition + displacement;
    }
}
