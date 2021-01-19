using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private int _helth = 3;

    public event UnityAction<int> HelthChanged;
    public event UnityAction Died;

    private void Start()
    {
        HelthChanged?.Invoke(_helth);
    }

    public void ApplyDamage(int damage)
    {
        _helth -= damage;
        HelthChanged?.Invoke(_helth);
        if (_helth <= 0)
            Die();
    }

    private void Die()
    {
        Died?.Invoke();
    }
}