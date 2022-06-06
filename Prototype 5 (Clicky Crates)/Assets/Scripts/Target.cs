using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
	private Rigidbody targetRb;
	private float minSpeed = 12;
	private float maxSpeed = 16;
	private float maxTorque = 10;
	private float xRange = 4;
	private float ySpawnPos = -3;

	public int targetValue;

	private GameManager gameManager;
	public ParticleSystem explosionParticle;

	// Start is called before the first frame update
	void Start()
	{
		targetRb = GetComponent<Rigidbody>();
		targetRb.AddForce(RandomUpForce(), ForceMode.Impulse);
		targetRb.AddTorque(RandomTorque(), ForceMode.Impulse);
		this.transform.position = RandomSpawnPos();

		gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
	}

	// Update is called once per frame
	void Update()
	{
		
	}

    private void OnMouseDown()
    {
		DestroyTarget();
    }
    private void OnMouseOver()
    {
		if (Input.GetKey(KeyCode.Mouse0))
			DestroyTarget();
    }

	void DestroyTarget()
    {
        if (gameManager.isGameActive)
        {
			Destroy(this.gameObject);
			Instantiate(explosionParticle, this.transform.position, explosionParticle.transform.rotation);
			gameManager.UpdateScore(targetValue);
        }
	}

    private void OnTriggerEnter(Collider other)
    {
		Destroy(this.gameObject);
		if (!this.gameObject.CompareTag("Bad"))
			gameManager.GameOver();
    }

    private Vector3 RandomUpForce()
	{
		return Vector3.up * Random.Range(minSpeed, maxSpeed);
	}
	private Vector3 RandomTorque()
	{
		return new Vector3(Random.Range(-maxTorque, maxTorque), Random.Range(-maxTorque, maxTorque), Random.Range(-maxTorque, maxTorque));
	}
	private Vector3 RandomSpawnPos()
	{
		return new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
	}
}
