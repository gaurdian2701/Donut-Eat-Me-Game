using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChocchipDamageDetection : MonoBehaviour
{
    // Start is called before the first frame update
    public MobController controller;
    public EnemyHealthSystem healthSystem;
    // Start is called before the first frame update
    void Awake()
    {
    }

    // Update is called once per frame
    public void DamageDetector(float damage)
    {
        healthSystem.takeDamage(damage);
        Debug.Log(healthSystem.health);
    }
}
