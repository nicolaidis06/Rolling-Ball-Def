using UnityEngine;

public class PushCylinder : MonoBehaviour
{
    [SerializeField] private float impulseForce = 500f;
    private Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddTorque(Vector3.up * impulseForce, ForceMode.VelocityChange);
    }
}
