using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyDamageDetection : MonoBehaviour
{
    public MobController controller;
    public EnemyHealthSystem healthSystem;
    public Renderer[] renderers;

    // Start is called before the first frame update
    void Awake()
    {
        renderers = GetComponentsInChildren< Renderer >();
    }

    // Update is called once per frame
    public void DamageDetector(float damage)
    {      
        healthSystem.takeDamage(damage);
        StartCoroutine(EnemyDamageIndicator());
        Debug.Log(healthSystem.health);
        controller.StartKnockback();  
    }

    private IEnumerator EnemyDamageIndicator() {
        foreach( Renderer renderer in renderers ) {
            renderer.material.color = Color.red;
        }
        yield return new WaitForSeconds(0.2f);  
        foreach( Renderer renderer in renderers ) {
            renderer.material.color = Color.white;
        }
    }
}
