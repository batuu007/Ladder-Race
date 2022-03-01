using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LevelProgressUI : MonoBehaviour
{
    [Header("UI References :")] 
    [SerializeField] private Image _uiFillImage;
    [SerializeField] private TextMeshProUGUI _uiStartText;
    [SerializeField] private TextMeshProUGUI _uiEndText;

    [Header("Player & EndLine References :")] 
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private Transform _endLineTransform;

    private Vector3 _endLinePosition;

    private float fullDistance;

    private void Start()
    {
        _endLinePosition = _endLineTransform.position;
        fullDistance = GetDistance();
    }

    public void SetLevelTexts(int level)
    {
        _uiStartText.text = level.ToString();
        _uiEndText.text = (level + 1).ToString();
    }

    private float GetDistance()
    {
        //return Vector3.Distance(_playerTransform.position, _endLinePosition);
        return (_endLinePosition - _playerTransform.position).sqrMagnitude;
    }

    private void UpdateProgressFill(float value)
    {
        _uiFillImage.fillAmount = value;
    }

    private void Update()
    {
        if (_playerTransform.position.z<=_endLinePosition.z)
        {
            float newDistance = GetDistance();
            float progressValue = Mathf.InverseLerp(fullDistance, 0f, newDistance);
        
            UpdateProgressFill(progressValue);
        }
    }
}
