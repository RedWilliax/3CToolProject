using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum AxisCode
{
    MouseX,
    MouseY,
    None

}

public static class TCT_AxisRecuperator
{
    static Vector2 mousePosition = Vector2.zero;

    static float reduceFactor = 1;

    public static float GetAxis(AxisCode _axisCode, float _sensibility = 1, float _deadZone = 0)
    {
        switch (_axisCode)
        {
            case AxisCode.MouseX:
                return MouseX(_sensibility, _deadZone);
            case AxisCode.MouseY:
                return MouseY(_sensibility, _deadZone);
            default:
                break;
        }

        return 0;
    }

    static float MouseX(float _sensibility = 1, float _deadZone = 0)
    {
        if (mousePosition == Vector2.zero)
        {
            mousePosition = Input.mousePosition;
            return 0;
        }

        float _currentX = Input.mousePosition.x - mousePosition.x;

        if (Mathf.Abs(_currentX) < _deadZone) return 0;

        mousePosition = Input.mousePosition;

        return _currentX * _sensibility * reduceFactor;
    }

    static float MouseY(float _sensibility = 1, float _deadZone = 0)
    {
        if (mousePosition == Vector2.zero)
        {
            mousePosition = Input.mousePosition;
            return 0;
        }

        float _currentY = Input.mousePosition.y - mousePosition.y;

        if (Mathf.Abs(_currentY) < _deadZone) return 0;

        mousePosition = Input.mousePosition;

        return _currentY * _sensibility * reduceFactor;
    }


}