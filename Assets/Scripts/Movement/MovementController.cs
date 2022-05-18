using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovementController : MonoBehaviour

{
    [SerializeField] private VariableJoystick variableJoystick;
    [SerializeField] private Rigidbody player;
    private float inputForward = 0;
    public float speed = 5f, speedRotation = 15f;
    [SerializeField] private bool enjineStart = false;
    [SerializeField] private Button startButton, stopButton;

    private void Start()
    {
        startButton.interactable = true;
        stopButton.interactable = false;
    }

    public void SetInputForward(float input) {
        inputForward = input;

    }
    // Update is called once per frame
    void Update()
    {
        if (enjineStart)
        {
            player.MovePosition(player.position + player.transform.forward * inputForward * speed * Time.deltaTime);

#if UNITY_EDITOR
            player.MoveRotation(Quaternion.Euler(0, player.rotation.eulerAngles.y + variableJoystick.Horizontal * speedRotation * Time.deltaTime, 0));
#else
        player.MoveRotation(Quaternion.Euler(0, player.rotation.eulerAngles.y + variableJoystick.Horizontal * speedRotation * inputForward * Time.deltaTime, 0));
#endif
        }
    }

    IEnumerator BreakCD()
    {
        yield return new WaitForSeconds(45);
        enjineStart = false;
        startButton.interactable = true;
    }

    public void SwitchEngineStart() {
        if (!enjineStart)
        {
            enjineStart = true;
            startButton.interactable = false;
            stopButton.interactable = true;
            StartCoroutine(BreakCD());
        }
    }

    public void SwitchEngineStop()
    {
        if (enjineStart)
        {
            enjineStart = false;
            stopButton.interactable = false;
            startButton.interactable = true;
        }
    }

    



}
