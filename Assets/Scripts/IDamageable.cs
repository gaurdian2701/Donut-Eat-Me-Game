using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable<T>
{
    void takeDamage(float damage);
    void OnDied();
}