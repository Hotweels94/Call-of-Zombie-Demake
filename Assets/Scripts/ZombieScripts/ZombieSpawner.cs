using System.Threading;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    [SerializeField] private GameObject Zombie;
    [SerializeField] private PlayerScript Player;
    [SerializeField] private float TimeToSpawn;
    private float _timer;

    private void Update()
    {
        _timer += Time.deltaTime;
        if (_timer > TimeToSpawn)
        {
            GameObject zombie = Instantiate(Zombie, transform.position, Quaternion.identity);
            zombie.GetComponent<ZombieScript>().Player = Player;
            _timer = 0;
        }
    }
}
