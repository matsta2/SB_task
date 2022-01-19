using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderRotation : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private GameObject _gameObject;
    public float xLimit = 45f;
    void Start()
    {
        _slider.onValueChanged.AddListener(delegate
        {
            RotateMe();
        });
    }

    public void RotateMe()
    {
        _gameObject.transform.localEulerAngles = new Vector3(0, _slider.value * xLimit, 0);
    }
}
