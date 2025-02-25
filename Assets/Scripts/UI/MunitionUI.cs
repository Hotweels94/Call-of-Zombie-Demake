using TMPro;
using UnityEngine;

public class MunitionUI : MonoBehaviour
{
    [SerializeField] private Shoot Weapon;

    void Update()
    {
        if (Weapon.canReload)
        {
            GetComponent<TMP_Text>().text = Weapon.MunitionInMagazine + " / " + Weapon.MaxMunition;
        } 
        else
        {
            GetComponent<TMP_Text>().text = "reloading...";
        }
        
    }
}
