using System.Collections.Generic;
using UnityEngine;

public class BuyWall : MonoBehaviour
{

    [SerializeField] private List<ZombieSpawner> SpawnersToActivate;

    public int PointsToOpen;
    [SerializeField] private PlayerScript Player;
    private bool InZoneToBuy = false;

    [SerializeField] private AudioClip BuyWallSound;
    [SerializeField] private float BuyWallSoundVolume;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            InZoneToBuy = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            InZoneToBuy = false;
        }
    }

    private void Update()
    {
        if (InZoneToBuy == true)
        {
            if (Input.GetKeyDown(KeyCode.E) && Player.ActualPoints >= PointsToOpen)
            {
                Player.ActualPoints -= PointsToOpen;
                AudioSource.PlayClipAtPoint(BuyWallSound, Player.transform.position, BuyWallSoundVolume);
                foreach (var spawner in SpawnersToActivate)
                {
                    spawner.gameObject.SetActive(true);
                }
                Destroy(gameObject, 2);
                GetComponent<Animator>().SetTrigger("IsBuy");
            }
        }
    }
}
