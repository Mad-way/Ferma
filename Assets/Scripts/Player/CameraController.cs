using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Joystick joysticK;
    private float mouseX;

    [Header("Чувствительность")]
    public float sensivityMouse = 200f;

    public Transform Player;
    

    void Update()
    {
        mouseX = joysticK.Horizontal * sensivityMouse * Time.deltaTime;
        Player.Rotate(mouseX * new Vector3(0, 1, 0));
    }
}
