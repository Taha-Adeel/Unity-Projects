using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public float speed = 5.0f;
	private Rigidbody playerRb;
	private float forwardInput;
	private float horizontalInput;
	public float slope = 0.1f;

	private bool hasPowerup;
	public float powerupStrength = 50;
	public int powerupDuration = 7;
	public GameObject powerupIndicator;

	// Start is called before the first frame update
	void Start()
	{
		playerRb = GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void Update()
	{
		horizontalInput = Input.GetAxis("Horizontal");
		forwardInput = Input.GetAxis("Vertical");
		playerRb.AddForce(Vector3.right * speed * horizontalInput);
		playerRb.AddForce(Vector3.forward * speed * forwardInput);

		playerRb.AddForce(transform.position * Physics.gravity.y * slope);

		powerupIndicator.transform.position = this.transform.position + new Vector3(0, -0.5f, 0);
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
			hasPowerup = true;
			Destroy(other.gameObject);
			StartCoroutine(PowerupCountdownRoutine());
			powerupIndicator.gameObject.SetActive(true);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy") && hasPowerup)
        {
			Rigidbody enemyRb = collision.gameObject.GetComponent<Rigidbody>();
			Vector3 awayFromPlayer = collision.gameObject.transform.position - this.transform.position;

			enemyRb.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);
        }
    }

	IEnumerator PowerupCountdownRoutine()
    {
		yield return new WaitForSeconds(powerupDuration);
		hasPowerup = false;
		powerupIndicator.gameObject.SetActive(false);
    }
}
