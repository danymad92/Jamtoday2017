using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarCanvasController : MonoBehaviour {
    public static bool weaponReady;

    public Image trashCounterFill;
    public Image bulletCounterFill;
    public GameObject recycleIcon;
    public GameObject weaponIcon;

    // Use this for initialization
    void Start () {
        trashCounterFill.fillAmount = 0;
        weaponReady = false;
	}

    public void ActivateTrashCount() {
        trashCounterFill.fillAmount = 0;
        trashCounterFill.transform.parent.gameObject.SetActive(true);
    }

    public void ActivateBulletCount() {
        bulletCounterFill.fillAmount = 1;
        bulletCounterFill.transform.parent.gameObject.SetActive(true);
    }

    public void DeactivateTrashCount() {
        trashCounterFill.transform.parent.gameObject.SetActive(false);
    }

    public void DeactivateBulletCount() {
        bulletCounterFill.transform.parent.gameObject.SetActive(false);
    }

    public void UpdateTrashCount(int cnt, int totalCnt) {
        trashCounterFill.fillAmount = ((float) cnt / totalCnt);
    }

    public void UpdateBulletCount(int cnt, int totalCnt) {
        bulletCounterFill.fillAmount = ((float) cnt / totalCnt);
    }

    public void PrepareWeapon() {
        weaponReady = false;
        recycleIcon.SetActive(true);
        Invoke("WeaponPrepared", 2.0f);
    }

    public void WeaponPrepared() {
        weaponReady = true;
        recycleIcon.SetActive(false);
        weaponIcon.SetActive(true);
        SoundManager.instance.coins.Play();
    }
}
