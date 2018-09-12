using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneNameLabel : MonoBehaviour
{

    public TextMeshProUGUI text;

    void Start()
    {
        text.text = SceneManager.GetActiveScene().name;
    }
}
