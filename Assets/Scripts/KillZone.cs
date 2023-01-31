using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZone : MonoBehaviour
{
    public HealthSystem hs;

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "KillZone") {
            Debug.Log("killzone - " + other);
            Debug.Log("Entered killzone");
            hs.OnDied();
        }
    }
}