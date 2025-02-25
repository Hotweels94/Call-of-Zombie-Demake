using TMPro;
using UnityEngine;

public class WallUI : MonoBehaviour
{
    [SerializeField] private BuyWall Wall;

    private void Start()
    {
        GetComponent<TMP_Text>().text = "Points to open the door : " + Wall.PointsToOpen + " Press E";
    }

}
