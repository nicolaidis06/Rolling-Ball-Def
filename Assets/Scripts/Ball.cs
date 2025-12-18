using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    [SerializeField] private GameObject coinWall;
    [SerializeField] private AudioClip jumpSound;
    [SerializeField] private AudioClip deathSound;
    [SerializeField] private float movementForce = 5f;
    [SerializeField] private float interactionRadius;
    [SerializeField] private int wallUnlock;
    private Rigidbody rb;
    private int coinTotal;
    private float hInput;
    private float vInput;
    private Vector3 interactionPoint;
    private Vector3 initialPosition;
    private AudioSource audioSource;

    void Start()
    {
        initialPosition = transform.position;
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(Physics.Raycast(transform.position, Vector3.down, transform.localScale.y + 0.1f))
            {
                AudioManager.instance.PlaySFX(jumpSound);
                rb.AddForce(Vector3.up.normalized * movementForce, ForceMode.Impulse);
            }
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            interactionPoint = transform.position + transform.forward * 0.2f;
            Collider[] results = Physics.OverlapSphere(interactionPoint, interactionRadius);
            if (results.Length > 0) //At least one collider detected
            {
                foreach (Collider result in results)
                {
                    if (result.gameObject.TryGetComponent(out Button buttonScript))
                    {
                        result.gameObject.GetComponent<Button>().OpenDoor();
                    }
                }
            }
        }

        if (coinTotal >= wallUnlock)
        {
            Destroy(coinWall);
        }
    }

    //Every 0.02 seconds. Meant to work with constant forces.
    private void FixedUpdate()
    {
        hInput = Input.GetAxisRaw("Horizontal");
        vInput = Input.GetAxisRaw("Vertical");
        rb.AddForce(new Vector3(hInput, 0, vInput).normalized * movementForce, ForceMode.Force);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("GoldCube"))
        {
            coinTotal++;
            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("Kill"))
        {
            AudioManager.instance.PlaySFX(deathSound);
            transform.position = initialPosition;
        }
        else if (other.gameObject.CompareTag("Goal"))
        {
            SceneManager.LoadScene("Level2");
        }
        else if (other.gameObject.CompareTag("Goal2"))
        {
            SceneManager.LoadScene("Level3");
        }
        else if (other.gameObject.CompareTag("Goal3"))
        {
            SceneManager.LoadScene("Level4");
        }
        else if (other.gameObject.CompareTag("Goal4"))
        {
            SceneManager.LoadScene("Level5");
        }
        else if (other.gameObject.CompareTag("Goal5"))
        {
            SceneManager.LoadScene("Level6");
        }
        else if (other.gameObject.CompareTag("Goal6"))
        {
            SceneManager.LoadScene("Level7");
        }
        else if (other.gameObject.CompareTag("Goal7"))
        {
            SceneManager.LoadScene("Level8");
        }
        else if (other.gameObject.CompareTag("Goal8"))
        {
            SceneManager.LoadScene("Level9");
        }
        else if (other.gameObject.CompareTag("Goal9"))
        {
            SceneManager.LoadScene("Level10");
        }
        else if (other.gameObject.CompareTag("Goal10"))
        {
            SceneManager.LoadScene("WinScreen");
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(interactionPoint, interactionRadius);
    }
}
