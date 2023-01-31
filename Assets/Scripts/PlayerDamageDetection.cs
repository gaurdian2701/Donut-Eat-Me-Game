using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageDetection : MonoBehaviour
{
    public HealthSystem healthSystem;
    [SerializeField] private PlayerController controller;
    [SerializeField] private Rigidbody rb;

    private Vector3 pushDirection;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    public void DamageDetector(float damage, Vector3 pushDirection, float magnitude)
    {
        healthSystem.takeDamage(damage);
        controller.StartKnockBack(pushDirection, magnitude);
    }

    //public void DamageUpdate()
    //{
    //    healthSystem.takeDamage(5);
    //}
}
