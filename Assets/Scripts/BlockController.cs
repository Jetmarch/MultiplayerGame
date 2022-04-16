using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour
{

    [SerializeField]
    private float currentHealth;

    [SerializeField]
    private float maxHealth;

    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        currentHealth = maxHealth;
    }

    public void GetDamage(float amount)
    {
        currentHealth -= amount;

        Debug.Log(255f - 255f * (currentHealth / maxHealth));

        spriteRenderer.color = new Color(1.0f, 1.0f * (currentHealth / maxHealth), 1.0f * (currentHealth / maxHealth));

        if(currentHealth <= 0)
        {
            Crash();
        }
    }

    private void Crash()
    {
        //Заспавнить этот блок для того, чтобы игрок мог поднять его в инвентарь
        Destroy(gameObject);
    }
}
