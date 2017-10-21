using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarCanvasController : MonoBehaviour {
    public static CarCanvasController _instance;

    public Image trashCounterFill;
    public Image bulletCounterFill;

    void Awake() {
        _instance = this;
    }

    // Use this for initialization
    void Start () {
        trashCounterFill.fillAmount = 0;
	}

    public static void ActivateTrashCount() {
        _instance.trashCounterFill.transform.parent.gameObject.SetActive(true);
    }

    public static void ActivateBulletCount() {
        _instance.bulletCounterFill.transform.parent.gameObject.SetActive(true);
    }

    public static void DeactivateTrashCount() {
        _instance.trashCounterFill.transform.parent.gameObject.SetActive(false);
    }

    public static void DeactivateBulletCount() {
        _instance.bulletCounterFill.transform.parent.gameObject.SetActive(false);
    }

    public static void UpdateTrashCount(int cnt, int totalCnt) {
        _instance.trashCounterFill.fillAmount = (cnt / totalCnt);
    }

    public static void UpdateBulletCount(int cnt, int totalCnt) {
        _instance.bulletCounterFill.fillAmount = (cnt / totalCnt);
    }
}
