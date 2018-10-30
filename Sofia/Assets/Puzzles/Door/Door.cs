using System;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(Animator), typeof(AudioSource))]
public class Door : MonoBehaviour
{
    public PuzzlePartBase[] _puzzleParts;

    public bool Open { get; private set; }

    private Animator animator;
    private const string OPEN_ANIMATION_NAME = "Open";

    private AudioSource audioSource;
    public AudioClip openSound;

    private void Start()
    {
        if (_puzzleParts.Length < 1)
        {
            throw new Exception("Door should have atleast one puzzle part. PuzzleParts array was empty.");
        }

        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();

        InvokeRepeating("CheckPuzzlePartsStatus", 0, 1f); // Only need to check this once pr second.
    }

    private void CheckPuzzlePartsStatus()
    {
        if (Open) return;

        Open = _puzzleParts.All(x => x.IsSolved());

        if (Open)
            PlayOpenAnimation();
    }

    private void PlayOpenAnimation()
    {
        animator.SetTrigger(OPEN_ANIMATION_NAME);
        audioSource.PlayOneShot(openSound);
    }
}