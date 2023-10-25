using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerAvatar : BaseAvatar
{

    private HealthBar healthBar;
    // Start is called before the first frame update
    void Start()
    {
        healthBar = GameManager.instance.healthBar;
        Health = 6;
        healthBar.SetHealth(Health);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);
        healthBar.SetHealth(Health);
    }

    public override void Die()
    {
        if (Health <= 0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene("Menu");
        }
        
    }
}
