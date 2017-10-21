using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FreakPool;

public class Bullet : MonoBehaviour, IPooleableObject {

    [HideInInspector]
    public Rigidbody rigBody;

    public float bulletSpeed;

    [HideInInspector]
    public WeaponController weaponController;

    public void DestroyObject() {
        Destroy(this.gameObject);
    }

    public IPooleableObject Generate() {
        GameObject copy = Instantiate<GameObject>(this.gameObject, new Vector3(999999, 999999, 999999), Quaternion.Euler(new Vector3(0, 180, 0)));
        copy.SetActive(false);
        return copy.GetComponent<Bullet>();
    }

    void Awake() {
        rigBody = GetComponent<Rigidbody>();
    }

    void OnEnable() {
        StartCoroutine(WaitForDesactive(5));
    }

    void OnDisable() {
        StopAllCoroutines();
    }

    IEnumerator WaitForDesactive(float time) {

        yield return new WaitForSeconds(time);

        weaponController.bullets.Release(this);

    }

    private void OnTriggerEnter(Collider other) {

        if (other.CompareTag("Enemy")) {
            other.gameObject.SetActive(false);
            weaponController.bullets.Release(this);
            gameObject.SetActive(false);
        } else if (other.CompareTag("Barrel")) {

        } else if (other.CompareTag("Player")) {
            if (!other.gameObject.GetComponent<CarController>().playerNumber.Equals(weaponController.player.playerNumber)) {
                gameObject.SetActive(false);
            }
        }

    }
}
