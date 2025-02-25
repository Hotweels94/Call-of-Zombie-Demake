using UnityEngine;

public class CanvasActivationDeath : MonoBehaviour
{
    [SerializeField] private PlayerScript Player;
    [SerializeField] private Canvas DeathCanvas;
    [SerializeField] private Canvas PlayerCanvas;

    private void Update()
    {
        if (Player.IsDead == true)
        {
            DeathCanvas.gameObject.SetActive(true);
            PlayerCanvas.gameObject.SetActive(false);
        }
    }
}
