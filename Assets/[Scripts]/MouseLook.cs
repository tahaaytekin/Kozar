using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    float x;
    float y;
    public float sensivity = -1f;
    private Vector3 rotate;

    private void Update()
    {
        y = Input.GetAxis("Mouse X");
        x = Input.GetAxis("Mouse Y");
        rotate = new Vector3(x, y * sensivity, 0);
        transform.eulerAngles = transform.eulerAngles - rotate;
    }


}