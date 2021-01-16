using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int _helth = 1;

    public void ApplyDamage(int damage)
    {
        _helth -= damage;
        if (_helth <= 0)
            Die();
    }

    private void Die()
    {

    }
}