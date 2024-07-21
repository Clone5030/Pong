using UnityEngine;
using UnityEngine.UI;

public class ExitGame : MonoBehaviour
{
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(OnExitClick);
    }

    void OnExitClick()
    {
        Application.Quit();
    }
}
