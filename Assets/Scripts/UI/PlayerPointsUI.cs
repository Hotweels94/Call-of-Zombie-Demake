using TMPro;
using UnityEngine;

public class PlayerPointsUI : MonoBehaviour
{
    [SerializeField] private PlayerScript Player;

    private void Update()
    {
        GetComponent<TMP_Text>().text = "" + Player.ActualPoints;
    }
}
