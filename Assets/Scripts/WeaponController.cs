using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FreakPool;

public class WeaponController : MonoBehaviour {
    public bool available;
    public GameObject bulletPrefab;
    public Transform weaponTransform;

    public Pool<Bullet> bullets;

    public int bulletNumber = 3;

    private Bullet bulletShooted;

    [HideInInspector]
    public CarController player;

    private void Awake() {
        player = GetComponent<CarController>();
    }

    // Use this for initialization
    void Start () {
        available = false;

        Bullet b = Instantiate(bulletPrefab, new Vector3(999999, 999999, 999999), Quaternion.identity).GetComponent<Bullet>();

        bullets = new Pool<Bullet>(b);
        bullets.SetSize(bulletNumber + 2);
        b.gameObject.SetActive(false);
	}

    public void Shoot() {

        bulletShooted = bullets.Take();
        bulletShooted.weaponController = this;
        bulletShooted.transform.position = weaponTransform.position;
        bulletShooted.gameObject.SetActive(true);
        bulletShooted.rigBody.velocity = bulletShooted.gameObject.transform.forward * -bulletShooted.bulletSpeed;

    }
}
