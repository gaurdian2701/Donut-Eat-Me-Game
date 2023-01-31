using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackManager : MonoBehaviour
{
    public PlayerDamageCollider damageCollider;
    // Start is called before the first frame update
    private void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenPlayerLightDamageCollider()
    {
        damageCollider.EnableLightDamageCollider();
    }

    public void ClosePlayerLightDamageCollider()
    {
        damageCollider.DisableLightDamageCollider();
    }

    public void OpenPlayerHeavyDamageCollider()
    {
        damageCollider.EnableHeavyDamageCollider();
    }

    public void ClosePlayerHeavyDamageCollider()
    {
        damageCollider.DisableHeavyDamageCollider();
    }


}
