using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Heart _heartPrefab;

    private List<Heart> _hearts = new List<Heart>();

    private void OnEnable()
    {
        _player.HelthChanged += OnHelthChanget;
    }

    private void OnDisable()
    {
        _player.HelthChanged -= OnHelthChanget;
    }

    private void OnHelthChanget(int value)
    {

        if (_hearts.Count < value)
        {
            int heartLehghtCreate = value - _hearts.Count;
            for (int i = 0; i < heartLehghtCreate; i++)
            {
                CreateHeart();
            }
        }
        else if (_hearts.Count > value && _hearts.Count != 0)
        {
            int heartLehghtDelete = _hearts.Count - value;
            for (int i = 0; i < heartLehghtDelete; i++)
            {
                DestroyHeart(_hearts[_hearts.Count - 1]);
            }
        }
    }

    private void DestroyHeart(Heart heart)
    {
        _hearts.Remove(heart);
        heart.ToEmpty();
    }

    private void CreateHeart()
    {
        Heart newHeart = Instantiate(_heartPrefab, transform);
        _hearts.Add(newHeart);
        newHeart.ToFill();
    }
}