using System;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class LerpDemo : MonoBehaviour
{
    public enum ChangeStyle
    {
        Direct,
        Clamped,
        Lerp,
    }

    private const int MAX_VALUE = 100, CHANGE_MIN = 20, CHANGE_MAX = 50;
    private const float TIME = 1.25f; // change values every half second

    public Slider Slider;
    [Range(0, 1f)] public float LerpWeight;
    public float Increment = 2f;

    public ChangeStyle Style;


    private float _goal = MAX_VALUE;
    private float _nextChange = TIME;

    private void Update () {
        _nextChange -= Time.deltaTime;

        if (_nextChange < 0f) {
            _nextChange = TIME;
            _goal = (_goal + Random.Range(CHANGE_MIN, CHANGE_MAX)) % MAX_VALUE;
        }

        if (Mathf.Abs(Slider.value - _goal) > 0.1f) { AdjustSlider(); }
    }

    private void AdjustSlider () {
        switch (Style) {
            case ChangeStyle.Direct:
                Slider.value = _goal;
                break;
            case ChangeStyle.Clamped:
                if (Slider.value < _goal) {
                    Slider.value += Mathf.Min(Increment, _goal - Slider.value);
                } else {
                    Slider.value += Mathf.Max(-Increment, _goal - Slider.value);
                }
                break;
            case ChangeStyle.Lerp:
                var newval = Mathf.Lerp(Slider.value, _goal, LerpWeight);
                Slider.value = newval;
                break;
            default: throw new ArgumentOutOfRangeException();
        }
    }
}
