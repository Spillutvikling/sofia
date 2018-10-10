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
            //keyObjects[i].GetComponent<Interactable>().SetInteractAction(() => ToggleKeyNumber(i+1), "Key " + (i+1));
            keyObjectMeshRenderers.Add(keyObjects[i].GetComponent<MeshRenderer>());
        }

        // TODO: Why the fuck doesnt setting this dynamically in the loop above work? InteractAction on interactables get overriden/point to the same ToggleKeyNumber.
        keyObjects[0].GetComponent<Interactable>().SetInteractAction(() => ToggleKeyNumber(1), "Key " + (1));
        keyObjects[1].GetComponent<Interactable>().SetInteractAction(() => ToggleKeyNumber(2), "Key " + (2));
        keyObjects[2].GetComponent<Interactable>().SetInteractAction(() => ToggleKeyNumber(3), "Key " + (3));
        keyObjects[3].GetComponent<Interactable>().SetInteractAction(() => ToggleKeyNumber(4), "Key " + (4));
        keyObjects[4].GetComponent<Interactable>().SetInteractAction(() => ToggleKeyNumber(5), "Key " + (5));
        keyObjects[5].GetComponent<Interactable>().SetInteractAction(() => ToggleKeyNumber(6), "Key " + (6));
        keyObjects[6].GetComponent<Interactable>().SetInteractAction(() => ToggleKeyNumber(7), "Key " + (7));
        keyObjects[7].GetComponent<Interactable>().SetInteractAction(() => ToggleKeyNumber(8), "Key " + (8));
        keyObjects[8].GetComponent<Interactable>().SetInteractAction(() => ToggleKeyNumber(9), "Key " + (9));
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

    public bool IsKeyOn(int key)
    {
        return SelectedKeys.Contains(key);
    }

    public override bool IsSolved()
    {
        return PuzzlesConfig.Puzzle1.PuzzlePart1_KeypadSolution.All(SelectedKeys.Contains);
    }
}

