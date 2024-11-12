using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int _health = 10;
    // Read only property
    public int Health => _health;

    private float _strength = 10f;
    public float Strength => _strength;

    private float _speed = 5f;
    public float Speed => _speed;

    private float _oringinalSpeed;
    private float _speedBoostDuration = 0f;
    private float _speedBoostTimer = 0f;
    private bool _isSpeedBoostActive;

    [SerializeField] TextMeshProUGUI healthTxt, strengthTxt, speedTxt;

    private void Start()
    {
        _oringinalSpeed = _speed;
        UpdateHealthText();
        UpdateStrengthText();
        UpdateSpeedText();
    }

    private void Update()
    {
        UpdateSpeedBoostTimer();
    }

    private void UpdateSpeedBoostTimer()
    {
        if (_isSpeedBoostActive)
        {
            _speedBoostTimer += Time.deltaTime;
            Debug.Log("+++Speed Boost...");
            if (_speedBoostTimer >= _speedBoostDuration)
            {
                _speed = _oringinalSpeed;
                _isSpeedBoostActive = false;
                UpdateSpeedText();
                Debug.Log("Speed boost ended. Speed reset.");
            }
        }
    }

    public void PowerUp(int healthIncrease)
    {
        _health += healthIncrease;
        UpdateHealthText();
        Debug.Log($"Health increase by {healthIncrease}, New health : {_health}");
    }

    public void PowerUp(float strengthMultiplier)
    {
        _strength *= strengthMultiplier;
        UpdateStrengthText();
        Debug.Log($"Strength increase by {strengthMultiplier * 100}%, New Strength : {_strength}");
    }

    public void PowerUp(float speedMultiplier, float duration)
    {
        _speed *= speedMultiplier;
        _isSpeedBoostActive = true;
        _speedBoostDuration = duration;
        _speedBoostTimer = 0f;
        UpdateSpeedText();
        Debug.Log($"Speed boosted by {speedMultiplier * 100}% for {duration} seconds.");
    }

    public void UpdateHealthText()
    {
        healthTxt.text = $"Health : {_health}";
    }

    public void UpdateStrengthText()
    {
        strengthTxt.text = $"Strength : {_strength}";
    }

    public void UpdateSpeedText()
    {
        speedTxt.text = $"Speed : {_speed}";
    }
}
