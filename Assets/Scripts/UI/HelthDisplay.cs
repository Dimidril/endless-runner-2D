using UnityEngine;
using TMPro;

[RequireComponent(typeof(TMP_Text))]
public class HelthDisplay : MonoBehaviour
{
    [SerializeField] private Player _player;

    private TMP_Text _helthDisplay;

    private void Awake()
    {
        _helthDisplay = GetComponent<TMP_Text>();
    }

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