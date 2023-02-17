using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickPlayerExample : MonoBehaviour
{
    [Header("Color Player")]
    public TypePlayer typePlayerColor;

    public enum TypePlayer
    {
        PlayerRed,
        PlayerBlue,
        PlayerGreen,
        Yellow

    }
    public float speed;
    public VariableJoystick variableJoystick;
    public Rigidbody rb;

    public void FixedUpdate()
    {
        Vector3 direction = Vector3.forward * variableJoystick.Vertical + Vector3.right * variableJoystick.Horizontal;
        //rb.AddForce(direction * speed * Time.fixedDeltaTime, ForceMode.VelocityChange);
        transform.Translate(direction * speed * Time.fixedDeltaTime);
    }
}