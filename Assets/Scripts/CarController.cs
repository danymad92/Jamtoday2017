using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PLAYER_NUMBER {
    ONE,
    TWO
}

public class CarController : MonoBehaviour {
    private Vector3 movementDirection;
    private CarObjectManager objManager;
    //private Rigidbody rgd;
    private WeaponController weapon;

    public PLAYER_NUMBER playerNumber;

	public bool firstPosition;

	// Use this for initialization
	void Start () {
        objManager = GetComponent<CarObjectManager>();
        movementDirection = Vector3.zero;
        weapon = GetComponent<WeaponController>();
        //rgd = GetComponent<Rigidbody>();
	}
	
    public void ReleaseObject() {
		if (objManager.IsObjectReady()) {
            objManager.ReleaseObject();
        }
    }

    public void MoveTo(Vector3 direction) {
        movementDirection = direction;
    }

    public void Shoot() {
        weapon.Shoot();
    }

	public void setFirstPosition(bool isFirstPosition) {
		this.firstPosition = isFirstPosition;
	}

	public bool getFirstPosition() {
		return this.firstPosition;
	}

    private void FixedUpdate() {
        //rgd.AddForce((movementDirection + Vector3.forward) * CarManager.advanceSpeed * Time.fixedDeltaTime);
        transform.position += ((movementDirection * CarManager.movementSpeed) + (Vector3.forward * CarManager.forwardSpeed)) * Time.fixedDeltaTime;
        movementDirection = Vector3.zero;
    }

	void OnCollisionEnter(Collision other) {
		if (other.gameObject.CompareTag ("Item")) {
			other.gameObject.SetActive (false);
			if (this.getFirstPosition()) {
				ScoreManager.addItem ();
			}
		}
	}
}
