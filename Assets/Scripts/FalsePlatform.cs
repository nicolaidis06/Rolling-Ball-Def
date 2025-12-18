using UnityEngine;
using System.Collections;

public class FalsePlatform : MonoBehaviour
{
    private Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (UnityEngine.Random.value < 0.5f)
            {
                StartCoroutine(DestroyTime());
            }
        }
    }

    IEnumerator DestroyTime()
    {
        rb.isKinematic = false;
        yield return new WaitForSeconds(3);
        Destroy(this.gameObject);
    }
}
