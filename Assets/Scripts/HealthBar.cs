using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Button Button;
    private Slider _healthSlider;
    private void Start()
    {
        _healthSlider = GetComponent<Slider>();
        Button.onClick.AddListener(delegate { OnButtonClick(); });
    }

    private void OnButtonClick()
    {
        if(_healthSlider.value >=_healthSlider.minValue && _healthSlider.value <=_healthSlider.maxValue)
        {
            _healthSlider.value -= 10;
        }
    }
}
