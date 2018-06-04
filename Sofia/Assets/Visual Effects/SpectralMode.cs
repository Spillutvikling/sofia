using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class SpectralMode : MonoBehaviour
{
    public PostProcessProfile spectralEffect;

    PostProcessVolume m_Volume;
    PostProcessProfile originalProfile;
    Vignette m_Vignette;
    GameObject[] puzzleObjects;
    public bool spectralEnabled = false;


    public static SpectralMode instance;
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
        m_Volume = GetComponent<PostProcessVolume>();
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
        if (Input.GetKeyDown(KeyCode.L))
        {
            if (spectralEnabled)
            {
                m_Volume.profile = originalProfile;
                spectralEnabled = false;
            }
            else
            {
                m_Volume.profile = spectralEffect;
                m_Volume.profile.TryGetSettings(out m_Vignette);
                spectralEnabled = true;
            }

            SetPuzzleObjectsActive(spectralEnabled);
        }
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
        if (spectralEnabled)
        {
            var value = (Mathf.Sin(0.7f * Time.realtimeSinceStartup) * 0.04f) + 0.32f;
            m_Vignette.intensity.Override(value);
        }
    }
}