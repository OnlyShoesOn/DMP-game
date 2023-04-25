using UnityEngine;

public class TestEnemyCollisions : MonoBehaviour
{
    public int damage = 10; // Damage dealt to the player upon collision
    private GameObject player;
    private TestPlayerHealth playerHealth;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<TestPlayerHealth>();
    }

    void Update()
    {
        CheckCollision();
    }

    private void CheckCollision()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);
        float collisionRadius = GetComponent<Collider>().bounds.extents.magnitude;

        if (distance <= collisionRadius)
        {
            playerHealth.TakeDamage(damage);
        }
    }
}