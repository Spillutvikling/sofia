using System;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class SpectralModeEffect : MonoBehaviour
{
    public PostProcessProfile spectralEffect;
    public PostProcessVolume _volume;

    private PostProcessProfile _originalProfile;
    private Vignette _vignette;
    private GameObject[] _puzzleObjects;
    private GameObject[] _onlyNormalPlayersObjects;

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
        if (_volume == null)
        {
            throw new ArgumentException($"{nameof(_volume)} is missing.");
        }

        _originalProfile = _volume.profile;
        _puzzleObjects = GameObject.FindGameObjectsWithTag("Puzzle");
        _onlyNormalPlayersObjects = GameObject.FindGameObjectsWithTag("OnlyNormalPlayers");

        ActivateAndDeactivateObjectsBasedOnSpectral(GlobalManager.instance.GetLocalPlayer()?.Spectral ?? false);
    }

    void Update()
    {
        if (GlobalManager.instance.GetLocalPlayer() == null) // There might be some initializing time before the local player is ready
            return;

        HandleSpectralToggle();
        AnimateVignette();
    }

    private void HandleSpectralToggle()
    {
        if (!GlobalManager.instance.GetLocalPlayer().Spectral)
        {
            _volume.profile = _originalProfile;
        }
        else
        {
            _volume.profile = spectralEffect;
            _volume.profile.TryGetSettings(out _vignette);
        }

        ActivateAndDeactivateObjectsBasedOnSpectral(GlobalManager.instance.GetLocalPlayer()?.Spectral ?? false);
    }

    private void ActivateAndDeactivateObjectsBasedOnSpectral(bool spectral)
    {
        SetGameObjectsActive(spectral, _puzzleObjects);
        SetGameObjectsActive(!spectral, _onlyNormalPlayersObjects);
    }

    private void SetGameObjectsActive(bool active, GameObject[] objects)
    {
        foreach (GameObject go in objects)
        {
            go.SetActive(active);
        }
    }

    private void AnimateVignette()
    {
        if (GlobalManager.instance.GetLocalPlayer().Spectral)
        {
            var value = (Mathf.Sin(0.7f * Time.realtimeSinceStartup) * 0.04f) + 0.32f;
            _vignette.intensity.Override(value);
        }
    }
}