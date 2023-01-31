using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageCollider : MonoBehaviour
{
    public BoxCollider LightdamageCollider;
    public BoxCollider HeavydamageCollider;
    [SerializeField] private float damage = 0f;
    [SerializeField] private PlayerDamageDetection detector;
    [SerializeField] private string hurtbox_name;
    private Vector3 pushDirection;
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
            pushDirection = other.transform.position - transform.position;
            if (gameObject.tag == "ladoo_Hitbox")
            {
                detector.DamageDetector(0, -pushDirection, 5);
                return;
            }
            detector.DamageDetector(damage, -pushDirection, 1);
            StartCoroutine(IgnoreCollision(other));
        }
    }

    private IEnumerator IgnoreCollision(Collider col)
    {
        Physics.IgnoreCollision(col, GetComponent<BoxCollider>());
        yield return new WaitForSeconds(0.5f);
        Physics.IgnoreCollision(col, GetComponent<BoxCollider>(), false);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
