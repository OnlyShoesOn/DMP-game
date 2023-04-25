using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour
{
    
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }
    private Animator anim;
    private bool dead;
    private UIManager uiManager;
    public AudioClip deathClip;

    
    [SerializeField] private int numberOfFlashes;
    private SpriteRenderer spriteRend;

    
    [SerializeField] private Behaviour[] components;
    private bool invulnerable;

    
    [SerializeField] private AudioClip deathSound;
    [SerializeField] private AudioClip hurtSound;

    private void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
        uiManager = FindObjectOfType<UIManager>();
        
        
    }
    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        if (currentHealth > 0)
        {
            anim.SetTrigger("hurt");
        }
        else
        {
            if (!dead)
            {
                //Deactivate all attached component classes
                foreach (Behaviour component in components)
                    component.enabled = false;

                anim.SetBool("grounded", true);
                anim.SetTrigger("die");

                dead = true;
                AudioSource.PlayClipAtPoint (deathClip, transform.position);

                uiManager.GameOver();
                return;
               
            }
        }
    }
      
    private void Deactivate()
    {
        gameObject.SetActive(false);
    }

    
}