using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private Vector3 movementDirection;
    [SerializeField] private float movementSpeed;
    [SerializeField] private float timeComeAndBack;
    private float timer;
    private Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.linearVelocity = movementDirection * movementSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= timeComeAndBack)
        {
            //movementDirection = movementDirection * -1
            movementDirection *= -1;
            rb.linearVelocity = movementDirection * movementSpeed;
            timer = 0;
        }
    }
}
