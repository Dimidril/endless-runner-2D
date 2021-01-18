using UnityEngine;
using TMPro;

public class HelthDisplay : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private TMP_Text _helthDisplay;

    private void OnEnable()
    {
        _player.HelthChanged += OnHelthChanged;
    }

    private void OnDisable()
    {
        _player.HelthChanged -= OnHelthChanged;
    }

    private void OnHelthChanged(int helth)
    {
        _helthDisplay.text = helth.ToString();
    }
}