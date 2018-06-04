using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Puzzle : MonoBehaviour
{
    public TextMeshProUGUI text;
    public GameObject visualObject;
    public AudioSource audioSource;
    public Animator animator;

    private bool inRange = false;
    private bool triggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (visualObject.activeSelf && !triggered)
        {
            text.enabled = true;
            inRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        text.enabled = false;
        inRange = false;
    }

    private void Update()
    {
        if (inRange)
        {
            if (Input.GetKeyDown(KeyCode.E) && !triggered)
            {
                audioSource.Play();
                animator.SetTrigger("Grow");
                triggered = true;
            }
        }

        if (triggered)
        {
            visualObject.transform.Rotate(Vector3.up, 30f * Time.deltaTime, Space.Self);
        }
    }
}
