using TMPro;
using UnityEngine;

public class InteractText : MonoBehaviour
{

    public TextMeshProUGUI text;

    private void Update()
    {
        text.enabled = GlobalManager.instance.GetCachedLocalPlayer()?.CanInteract ?? false;
    }
}
