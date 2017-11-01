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
	private CarCanvasController carCanvasController;
	private int totalItem;

    public PLAYER_NUMBER playerNumber;
	public bool firstPosition;

    public AudioSource shootSound;

    public Animator animator;

    private bool turningLeft = false;
    private bool turningRight = false;

	// Use this for initialization
	void Start () {
        objManager = GetComponent<CarObjectManager>();
        movementDirection = Vector3.zero;
        weapon = GetComponent<WeaponController>();
        //rgd = GetComponent<Rigidbody>();
		carCanvasController = GetComponentInChildren<CarCanvasController> ();
		carCanvasController.DeactivateBulletCount ();
		carCanvasController.ActivateTrashCount ();
		totalItem = 3;
		if (!firstPosition) {
			carCanvasController.DeactivateTrashCount ();
		}
	}
	
    public void ReleaseObject() {
        if (objManager.IsObjectReady()) {
            objManager.ReleaseObject();
        }
    }

    public void MoveTo(Vector3 direction) {
        movementDirection = direction;

        if (movementDirection.x < 0 && !turningLeft) {
			//Debug.Log("Left True");
            animator.SetTrigger("TurnLeft");
            turningLeft = true;
            turningRight = false;
        } else if(movementDirection.x > 0 && !turningRight) {

			//Debug.Log("Left False 1");
            animator.SetTrigger("TurnRight");
            turningRight = true;
            turningLeft = false;
        } else if(movementDirection.Equals(Vector3.zero)) {

			//Debug.Log("Left False 2");
            turningRight = false;
            turningLeft = false;
        }

        //transform.Rotate(Vector3.up, direction.x * 0.5f);
    }

    public void Shoot() {
		if (!weapon.Shoot ()) {
			carCanvasController.DeactivateBulletCount ();
		}
    }
    
    private void FixedUpdate() {
        //rgd.AddForce((movementDirection + Vector3.forward) * CarManager.advanceSpeed * Time.fixedDeltaTime);

        if (movementDirection.Equals(Vector3.zero) && !turningRight && !turningLeft) {
            
            animator.SetTrigger("Idle");
            
        }

        transform.position += ((movementDirection * CarManager.movementSpeed) + (Vector3.forward * CarManager.forwardSpeed)) * Time.fixedDeltaTime;
        movementDirection = Vector3.zero;
    }

	public void setFirstPosition(bool isFirstPosition) {
		this.firstPosition = isFirstPosition;
	}

	public bool isFirstPosition() {
		return this.firstPosition;
	}

	void OnCollisionEnter(Collision other) {
		if (other.gameObject.CompareTag ("Item")) {
			other.gameObject.SetActive (false);
			if (this.isFirstPosition ()) {
				ScoreManager.addItem ();
				carCanvasController.UpdateTrashCount (ScoreManager.getItems (), totalItem);
			}
		} else if (other.gameObject.CompareTag ("Weapon")) {
			if (!this.isFirstPosition ()) {
				other.gameObject.SetActive (false);
				carCanvasController.ActivateBulletCount ();
				this.weapon.ActivateWeapon();
			}
		}
	}
}
