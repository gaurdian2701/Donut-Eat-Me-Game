using Newtonsoft.Json.Bson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerDamageCollider : MonoBehaviour
{
    public BoxCollider LightdamageCollider;
    public BoxCollider HeavydamageCollider;
    [SerializeField] private float damage = 10f;
    [SerializeField] private EnemyDamageDetection detector;
    [SerializeField] private string hurtbox_name;
    // Start is called before the first frame update
    private void Awake()
    {
        //damageCollider.gameObject.SetActive(true);
        LightdamageCollider.isTrigger = true;
        HeavydamageCollider.isTrigger = true;
        LightdamageCollider.enabled = false;
        HeavydamageCollider.enabled = false;
    }

    public void EnableLightDamageCollider()
    {
        LightdamageCollider.enabled = true;
    }

    public void DisableLightDamageCollider()
    {
        LightdamageCollider.enabled = false;
    }

    public void EnableHeavyDamageCollider()
    {
        HeavydamageCollider.enabled = true;
    }

    public void DisableHeavyDamageCollider()
    {
        HeavydamageCollider.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == hurtbox_name)
        {
            other.gameObject.GetComponentInParent<EnemyDamageDetection>().DamageDetector(damage);
            StartCoroutine(IgnoreCollision(other));
        }
    }

    private IEnumerator IgnoreCollision(Collider col)
    {
        Physics.IgnoreCollision(col, GetComponent<BoxCollider>());
        yield return new WaitForSeconds(0.5f);
        Physics.IgnoreCollision(col, GetComponent<BoxCollider>(), false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }

}
