using TMPro;
using UnityEngine;

public class PlayerLifeUI : MonoBehaviour
{
    [SerializeField] private PlayerScript Player;

    private void Update()
    {
        GetComponent<TMP_Text>().text = "Life " + Player.HealthPoint + " / 3";
    }
}
