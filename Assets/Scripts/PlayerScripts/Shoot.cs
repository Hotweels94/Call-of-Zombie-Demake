using System;
using System.Collections;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    private RaycastHit hit;
    [SerializeField] private Camera cam;

    [SerializeField] private float shootRate;
    private bool canShoot = true;
    private float _timer;

    [SerializeField] private int damageWeapon;

    public ZombieScript Zombie;
    public PlayerScript Player;

    public int MunitionInMagazine;
    public int MaxMunition;
    [SerializeField] private float TimeToReload;
    public bool canReload = true;

    [SerializeField] private GameObject GunShotSmoke;
    [SerializeField] private AudioClip GunShotSound;
    [SerializeField] private float GunShotSoundVolume;

    [SerializeField] private AudioClip GunReloadSound;

    void Update()
    {
        Fire();
    }
    private void Fire()
    {
        _timer += Time.deltaTime;
        if(_timer >= shootRate)
        {
            canShoot = true;
        }

        if(Input.GetMouseButton(0) && canShoot == true)
        {
            if(MunitionInMagazine > 0)
            {
                canShoot = false;
                _timer = 0;

                Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, 300f);
                MunitionInMagazine--;

                GameObject smoke = Instantiate(GunShotSmoke);

                AudioSource.PlayClipAtPoint(GunShotSound, transform.position, GunShotSoundVolume);

                smoke.transform.position = transform.position + transform.forward * 0.5f;
                smoke.transform.rotation = transform.rotation;
                Destroy(smoke, 1);

                if (hit.collider != null && hit.collider.gameObject.tag == "Enemy")
                {
                    Zombie.HealthPoint -= damageWeapon;
                    if (Zombie.HealthPoint <= 0)
                    {
                        Player.ActualPoints += Zombie.PointsToPlayer;
                        Player.TotalPoints += Zombie.PointsToPlayer;
                        Destroy(hit.collider.gameObject);
                    }
                }
            }
            if (MunitionInMagazine <= 0 && canReload)
            {
                StartCoroutine(Reload());
            }
        }
    }

    private IEnumerator Reload()
    {
        canReload = false;
        AudioSource.PlayClipAtPoint(GunReloadSound, transform.position);
        yield return new WaitForSeconds(TimeToReload);
        MunitionInMagazine = MaxMunition;
        canReload = true;
    }

    private void Start()
    {
        MunitionInMagazine = MaxMunition;
    }
}
