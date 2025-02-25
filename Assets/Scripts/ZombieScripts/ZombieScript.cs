using UnityEngine;
using UnityEngine.AI;

public class ZombieScript : MonoBehaviour
{
    public PlayerScript Player;
    public int HealthPoint;

    public bool PlayerDead;

    public int PointsToPlayer;

    [SerializeField] private int Damage;
    [SerializeField] private float DelayDamage;
    private bool CanAttack = false;
    private float _timer;

    [SerializeField] private AudioClip HurtSound;
    [SerializeField] private float HurtSoundVolume;

    void Update()
    {
        GetComponent<NavMeshAgent>().SetDestination(Player.transform.position);
        _timer += Time.deltaTime;
        if (_timer >= DelayDamage)
        {
            CanAttack = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && CanAttack == true)
        {
            Player.HealthPoint -= Damage;
            AudioSource.PlayClipAtPoint(HurtSound, transform.position, HurtSoundVolume);
            CanAttack = false;
            _timer = 0;
            if(Player.HealthPoint <= 0)
            {
                Player.IsDead = true;
                Time.timeScale = 0;
            }
        }
    }
}
