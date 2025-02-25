using UnityEngine;

public class CanvasActivationWall : MonoBehaviour
{
    [SerializeField] private Canvas WallCanvas;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            WallCanvas.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            WallCanvas.gameObject.SetActive(false);
        }
    }
}
