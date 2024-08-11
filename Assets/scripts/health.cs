using UnityEngine;

public class Health : MonoBehaviour
{
	public float maxHealth = 100f;
	public float currentHealth;

	void Start()
	{
		currentHealth = maxHealth;
	}

	public void TakeDamage(float amount)
	{
		currentHealth -= amount;
		currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

		if (currentHealth <= 0)
		{
			// Handle destruction
		}
	}
}
