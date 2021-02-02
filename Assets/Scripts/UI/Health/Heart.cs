using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class Heart : MonoBehaviour
{
    [SerializeField] private float _lerpDuration;

    private Image _image;

    private void Awake()
    {
        _image = GetComponent<Image>();
        _image.fillAmount = 1f;
    }

    public void ToFill()
    {
        StartCoroutine(Filling(0, 1, 1, (float value) => {
            _image.fillAmount = value;
        }));
    }

    public void ToEmpty()
    {
        StartCoroutine(Filling(1, 0, 1, (float value) => {
            _image.fillAmount = value;
            Destroy(gameObject);
        }));
    }

    private IEnumerator Filling(float startValue, float endValue, float duration, UnityAction<float> lerpingEnd)
    {
        float elepsed = 0;
        float nextValue;

        while (elepsed < duration)
        {
            nextValue = Mathf.Lerp(startValue, endValue, elepsed/duration);
            _image.fillAmount = nextValue;
            elepsed += Time.deltaTime;
            yield return null;
        }

        lerpingEnd.Invoke(endValue);
    }
}