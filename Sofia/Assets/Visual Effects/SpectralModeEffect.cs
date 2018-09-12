using System;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class SpectralModeEffect : MonoBehaviour
{
    public PostProcessProfile spectralEffect;
    public PostProcessVolume m_Volume;

    PostProcessProfile originalProfile;
    Vignette m_Vignette;
    GameObject[] puzzleObjects;

    public static SpectralModeEffect instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;

        else if (instance != this)
        {
            Debug.LogError("Tried to create another instance of " + GetType() + ". Destroying.");
            Destroy(gameObject);
        }
    }

    void Start()
    {
        if (m_Volume == null)
        {
            throw new ArgumentException($"{nameof(m_Volume)} is missing.");
        }

        originalProfile = m_Volume.profile;
        puzzleObjects = GameObject.FindGameObjectsWithTag("Puzzle");

        SetPuzzleObjectsActive(false);
    }

    void Update()
    {
        HandleSpectralToggle();
        AnimateVignette();
    }

    private void HandleSpectralToggle()
    {
        if (!GlobalManager.instance.GetLocalPlayer().Spectral)
        {
            m_Volume.profile = originalProfile;
        }
        else
        {
            m_Volume.profile = spectralEffect;
            m_Volume.profile.TryGetSettings(out m_Vignette);
        }

        SetPuzzleObjectsActive(GlobalManager.instance.GetLocalPlayer().Spectral);
    }


    private void SetPuzzleObjectsActive(bool active)
    {
        foreach (GameObject go in puzzleObjects)
        {
            go.SetActive(active);
        }
    }

    private void AnimateVignette()
    {
        if (GlobalManager.instance.GetLocalPlayer().Spectral)
        {
            var value = (Mathf.Sin(0.7f * Time.realtimeSinceStartup) * 0.04f) + 0.32f;
            m_Vignette.intensity.Override(value);
        }
    }
}