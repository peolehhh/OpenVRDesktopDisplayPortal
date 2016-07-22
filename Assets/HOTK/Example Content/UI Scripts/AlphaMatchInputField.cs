﻿using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(InputField))]
public class AlphaMatchInputField : MonoBehaviour
{
    public HOTK_Overlay Overlay;
    public InputValue Value;
    
    public InputField InputField
    {
        get { return _inputField ?? (_inputField = GetComponent<InputField>()); }
    }

    private InputField _inputField;

    public void OnEnable()
    {
        if (Overlay == null) return;
        switch (Value)
        {
            case InputValue.AlphaStart:
                InputField.text = Overlay.Alpha.ToString();
                break;
            case InputValue.AlphaEnd:
                InputField.text = Overlay.Alpha2.ToString();
                break;
            case InputValue.AlphaSpeed:
                InputField.text = Overlay.AlphaSpeed.ToString();
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    public void OnAlphaChanged()
    {
        float f;
        if (!float.TryParse(InputField.text, out f)) return;
        if (Overlay == null) return;
        switch (Value)
        {
            case InputValue.AlphaStart:
                if (f >= 0)
                {
                    Overlay.Alpha = f;
                }
                else
                {
                    InputField.text = Overlay.Alpha.ToString();
                }
                break;
            case InputValue.AlphaEnd:
                if (f >= 0)
                {
                    Overlay.Alpha2 = f;
                }
                else
                {
                    InputField.text = Overlay.Alpha2.ToString();
                }
                break;
            case InputValue.AlphaSpeed:
                if (f >= 0)
                {
                    Overlay.AlphaSpeed = f;
                }
                else
                {
                    InputField.text = Overlay.AlphaSpeed.ToString();
                }
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    public enum InputValue
    {
        AlphaStart,
        AlphaEnd,
        AlphaSpeed
    }
}
