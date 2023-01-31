using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;
using UnityEngine.AI;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class EnemyHealthSystem : MonoBehaviour, IDamageable<float>
{
    public float health = 100;
    public Animator animator;
    private EnemySoundManager enemySounds;

    // Start is called before the first frame update
    void Start()
    {
        enemySounds = GetComponent<EnemySoundManager>();
   }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            OnDied();
            this.enabled = false;
        }
    }

    public void takeDamage(float Damage)
    {
        health -= Damage;
        Debug.Log("mob hurts");
    }

    public void OnDied()
    {
        StartCoroutine(WaitForDeath());
        animator.SetTrigger("isDead");
        enemySounds.PlayDeathSound();
    }

    private IEnumerator WaitForDeath()
    {
        yield return new WaitForSeconds(1f);
        Debug.Log("mob destroyed");
        Destroy(gameObject);
    }
}
