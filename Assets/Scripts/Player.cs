using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

	public float maxHealth = 100;
	public float currentHealth;

	public HealthBar healthBar;
	public float Damage;
	public float Heal;
	public float safeHeight;
	float damage;
	List<int> keys;
	GameObject door;
	Animator animator;

    // Start is called before the first frame update
    void Start()
    {
		keys = new List<int>();
		currentHealth = maxHealth*(0.9999f);
		healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
		if(transform.position.y < safeHeight)
		{
			damage = Damage;
		}
		else
		{
			damage = - Heal;
		}

		if(currentHealth > 0 && currentHealth < maxHealth)
		{
			TakeDamage(damage*Time.deltaTime);
		}
		else if(currentHealth==0)
		{
			Application.Quit(0);
		}
		else if(currentHealth >= maxHealth)
		{currentHealth = maxHealth * 0.9999f;}
    }

	void OnCollisionEnter2D(Collision2D other)
	{
		if(other.gameObject.CompareTag("coin"))
		{
			Destroy(other.gameObject);
		}
		if(other.gameObject.CompareTag("key"))
		{
			keys.Add(other.gameObject.GetComponent<Key>().number);
			Destroy(other.gameObject);
		}
		if(other.gameObject.CompareTag("door"))
		{
			if(keys.Contains(other.gameObject.GetComponent<Key>().number))
			{
				door = other.gameObject;
				Destroy(door.GetComponent<BoxCollider2D>());
				Open();
			}
		}
	}
	void TakeDamage(float damage)
	{
			currentHealth -= damage;

			healthBar.SetHealth(currentHealth);
	}
	void Open()
	{
		animator = door.GetComponent<Animator>();
		animator.SetFloat("Blend", 1);
		Invoke("StayOpen", 1f); 
	}
	void StayOpen()
	{
		animator.SetFloat("Blend", 2f);
	}
}
