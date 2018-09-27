using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeypadPuzzle : MonoBehaviour, IPuzzle {

    public KeypadSolution solution;

    private void Start()
    {
    }

	private void Update () {
		
	}

    public bool IsSolved()
    {
        throw new System.NotImplementedException();
    }
}

public class Puzzlse
{
    public static class Puzzle1
    {
        // 1-index based, because they represent a phone dial (and we dont use 0 on the phone dial)
        public static List<int> Keypad1Solution = new List<int> { 1, 2 };
    }
}