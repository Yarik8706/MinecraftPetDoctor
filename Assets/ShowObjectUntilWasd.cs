using UnityEngine;
using YG;

public class ShowObjectUntilWasd : MonoBehaviour
{
    [SerializeField] private GameObject targetObject;

    private void Start()
    {
        targetObject.SetActive(YandexGame.EnvironmentData.isDesktop);
        enabled = YandexGame.EnvironmentData.isDesktop;
    }

    private void Update()
    {
        if (!Input.GetKeyDown(KeyCode.W) && !Input.GetKeyDown(KeyCode.A) &&
            !Input.GetKeyDown(KeyCode.S) && !Input.GetKeyDown(KeyCode.D)) return;
        targetObject.SetActive(false);
    }
}