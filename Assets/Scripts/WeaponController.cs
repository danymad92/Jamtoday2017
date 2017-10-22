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

    private int shootedBulletsCnt;
    private Bullet bulletShooted;

    [HideInInspector]
    public CarController player;
    [HideInInspector]
    public CarCanvasController carCanvas;

    private void Awake() {
        player = GetComponent<CarController>();
        carCanvas = GetComponentInChildren<CarCanvasController>();
    }

    // Use this for initialization
    void Start () {
        available = false;
        shootedBulletsCnt = 0;

        Bullet b = Instantiate(bulletPrefab, new Vector3(999999, 999999, 999999), Quaternion.identity).GetComponent<Bullet>();

        bullets = new Pool<Bullet>(b);
        bullets.SetSize(bulletNumber + 2);
        b.gameObject.SetActive(false);
	}

    public void ActivateWeapon() {
        available = true;
        shootedBulletsCnt = 0;
    }

    public bool Shoot() {
        if (available) {

            bulletShooted = bullets.Take();
            bulletShooted.weaponController = this;
            bulletShooted.transform.position = weaponTransform.position;
            bulletShooted.gameObject.SetActive(true);
            bulletShooted.rigBody.velocity = bulletShooted.gameObject.transform.forward * -bulletShooted.bulletSpeed;
            ++shootedBulletsCnt;

            player.shootSound.Play();

            carCanvas.UpdateBulletCount(bulletNumber - shootedBulletsCnt, bulletNumber);

            if (shootedBulletsCnt == bulletNumber) {
                available = false;
                shootedBulletsCnt = 0;
            }
        }

		return available;
    }
}
