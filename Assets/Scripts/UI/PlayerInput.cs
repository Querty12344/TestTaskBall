using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInput : MonoBehaviour
{
    public event Action OnClick;
    [SerializeField] private Button _inputButton;
    
    private void Start()
    {
        _inputButton.onClick.AddListener(Click);
    }

    private void Click()
    {
        OnClick?.Invoke();
    }         
}
