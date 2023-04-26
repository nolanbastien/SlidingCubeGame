using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    public float forwardForce;
    [SerializeField] float sidewaysForce;
    [SerializeField] float torqueAmount;
    [SerializeField] float jumpAmount;
    [SerializeField] AudioSource winSoundFX;
    bool canControl = true;
    /*  private bool jumped = false; */

    void OnCollisionEnter(Collision other) {
        
        if (other.gameObject.tag == "Obstacle") {
            canControl = false;
            FindObjectOfType<GameManager>().EndGameLost();
        }

        // jumped = false;
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Victory") {
            winSoundFX.time = 0.1f;
            winSoundFX.Play();
            Spin();
            canControl = false;
            FindObjectOfType<GameManager>().EndGameVictory();
        }
    }


    private void Spin() {
        rb.AddTorque(0, torqueAmount * Time.deltaTime, 0);
    }

    void FixedUpdate()
    {
        if (canControl) {
            Control();
        }

        if (Input.GetKey(KeyCode.Escape)) {
            FindObjectOfType<GameManager>().ReturnToSelectLevel();
        }

        if (rb.position.y < -1) {
            canControl = false;
            FindObjectOfType<GameManager>().EndGameLost();
        }

    }

    private void Control() {
        rb.AddForce(0, 0, forwardForce * Time.deltaTime);

        if (Input.GetKey(KeyCode.LeftArrow)) 
        {
            rb.AddForce(- sidewaysForce * Time.deltaTime, 0, 0);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0);   
        }

        /* if (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.LeftControl) && !jumped)
        {
            rb.AddForce(0, jumpAmount * Time.deltaTime, 0); 
            jumped = true;
        } */
    }
    
}
