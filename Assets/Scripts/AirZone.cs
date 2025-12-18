using UnityEngine;

public class AirZone : MonoBehaviour
{
    private Rigidbody playerRb;
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Rigidbody playerRb = other.gameObject.GetComponent<Rigidbody>();
            playerRb.AddForce(new Vector3(-150f, 10f, 0), ForceMode.Force);
        }
    }
}
