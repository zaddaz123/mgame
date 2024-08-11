using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
	public Transform[] movePositions; // Positions where the enemy can move randomly
	public Transform crystal; // Reference to the crystal
	public float attackRange = 2f; // Range within which the enemy will start attacking
	public float attackInterval = 3f; // Time between each attack
	public GameObject bulletPrefab; // Bullet prefab (sphere)

	private NavMeshAgent agent;
	private bool isAttacking = false;
	private Animator animator;

	void Start()
	{
		agent = GetComponent<NavMeshAgent>();
		animator = GetComponent<Animator>();

		if (agent.isOnNavMesh)
		{
			MoveToRandomPosition();
			animator.SetTrigger("run");
		}
		else
		{
			Debug.LogError("Agent is not on NavMesh at start");
		}
	}

	void Update()
	{
		// Random movement
		if (!agent.pathPending && agent.remainingDistance < 6f)
		{
			MoveToRandomPosition();
		}

		// Attack logic
		if (crystal != null && Vector3.Distance(transform.position, crystal.position) < attackRange)
		{
			if (!isAttacking)
			{
				StartCoroutine(AttackCrystal());
			}
		}
	}

	void MoveToRandomPosition()
	{
		// Move to a random position in the array
		int randomIndex = Random.Range(0, movePositions.Length);
		Vector3 targetPosition = movePositions[randomIndex].position;
		agent.SetDestination(targetPosition);
	}

	IEnumerator AttackCrystal()
	{
		isAttacking = true;
		while (true)
		{
			Debug.Log("shooting...");
			animator.SetTrigger("idle");
			yield return new WaitForSeconds(attackInterval / 2); // Adjust if needed to sync with animation timing
			ShootBullet();
			yield return new WaitForSeconds(attackInterval / 2);
		}
	}

	void ShootBullet()
	{
		animator.SetTrigger("attack");

		// Rotate the enemy to face the crystal
		Vector3 direction = (crystal.position - transform.position).normalized;
		Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
		transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 10f);

		Vector3 spawnPosition = transform.position + new Vector3(0, 1, 0); // Adjust the Y value as needed

		// Instantiate a bullet and shoot towards the crystal
		GameObject bullet = Instantiate(bulletPrefab, spawnPosition, Quaternion.identity);
		Rigidbody rb = bullet.GetComponent<Rigidbody>();
		bullet.tag = "enemyBullet";
		rb.velocity = direction * 10f; // Adjust speed as needed

		// Destroy the bullet after 1 second
		Destroy(bullet, 1f);
	}
}
