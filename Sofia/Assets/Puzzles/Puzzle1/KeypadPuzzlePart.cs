using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class KeypadPuzzlePart : PuzzlePartBase
{
    public List<int> SelectedKeys { get; private set; } = new List<int>();

    private GameObject[] keyObjects = null;
    private List<MeshRenderer> keyObjectMeshRenderers = new List<MeshRenderer>();
    private List<int> SelectedKeysLastFrame { get; set; }

    private void Start()
    {
        keyObjects = transform.Cast<Transform>().Select(x => x.gameObject).ToArray();

        for (int i = 0; i < keyObjects.Length; i++)
        {
            int keyIndex = i + 1;
            keyObjects[i].GetComponent<Interactable>().SetInteractAction(() => ToggleKeyNumber(keyIndex));

            keyObjectMeshRenderers.Add(keyObjects[i].GetComponent<MeshRenderer>());
        }
    }

    private void Update()
    {
        for (int i = 0; i < keyObjects.Length; i++)
        {
            keyObjectMeshRenderers[i].material.SetColor("_EmissiveColor", Color.red);
        }

        foreach (var selectedKey in SelectedKeys)
        {
            keyObjectMeshRenderers[selectedKey - 1].material.SetColor("_EmissiveColor", Color.green);
        }
    }

    public void ToggleKeyNumber(int key)
    {
        if (key > 9 || key < 1)
            throw new ArgumentException($"ToggleKeyNumber requires a number between 1-9. Input was {key}");

        if (SelectedKeys.Contains(key))
        {
            SelectedKeys.Remove(key);
        }
        else
        {
            SelectedKeys.Add(key);
        }
    }

    public override bool IsSolved()
    {
        return PuzzlesConfig.Puzzle1.PuzzlePart1_KeypadSolution.All(SelectedKeys.Contains);
    }
}

