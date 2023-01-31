using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackManager : MonoBehaviour
{
    // Start is called before the first frame update
    public EnemyDamageCollider damageCollider;
    // Start is called before the first frame update
    private void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OpenEnemyLightDamageCollider()
    {
        damageCollider.EnableLightDamageCollider();
    }

    public void CloseEnemyLightDamageCollider()
    {
        damageCollider.DisableLightDamageCollider();
    }

    public void OpenEnemyHeavyDamageCollider()
    {
        damageCollider.EnableHeavyDamageCollider();
    }

    public void CloseEnemyHeavyDamageCollider()
    {
        damageCollider.DisableHeavyDamageCollider();
    }
}
