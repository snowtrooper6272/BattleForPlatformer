using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flipper : MonoBehaviour
{
    private Quaternion _leftLook = Quaternion.Euler(0, 180, 0);
    private Quaternion _rightLook = Quaternion.Euler(0, 0, 0);

    public void Flip(float axisDirection) 
    {
        if (axisDirection > 0)
        {
            transform.rotation = _rightLook;
        }
        else if(axisDirection < 0)
        {
            transform.rotation = _leftLook;
        }
    }
}
