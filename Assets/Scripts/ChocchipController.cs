using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChocchipController : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    Transform target;
    [SerializeField] float turnSpeed = 5f;
    [SerializeField] Transform shootPoint;
    float fireRate = 0.2f;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        fireRate -= Time.deltaTime;
        Vector3 direction = target.position - transform.position;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), turnSpeed * Time.deltaTime);
        if(fireRate <= 0)
        {
            fireRate = 0.5f;
            Shoot();
        }
    }

    void Shoot()
    {
        Instantiate(projectile, shootPoint.position, shootPoint.rotation);
    }
}
