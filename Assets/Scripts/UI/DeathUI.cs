using TMPro;
using UnityEngine;

public class DeathUI : MonoBehaviour
{
    [SerializeField] private PlayerScript Player;

    private void Update()
    {
        GetComponent<TMP_Text>().text = "You are Dead ! \n\n You've survived for : " + Mathf.FloorToInt(Player.SurvivedTimer) + " Seconds. \n\n Total of your points : " + Player.TotalPoints;
    }
}
