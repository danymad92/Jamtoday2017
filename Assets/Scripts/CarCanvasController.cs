using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarCanvasController : MonoBehaviour {
    public Image trashCounterFill;
    public Image bulletCounterFill;

    // Use this for initialization
    void Start () {
        trashCounterFill.fillAmount = 0;
	}

    public void ActivateTrashCount() {
        trashCounterFill.fillAmount = 1;
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
}
