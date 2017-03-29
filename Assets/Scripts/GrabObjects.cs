using UnityEngine;
using System.Collections;

public class GrabObjects : MonoBehaviour {

	private const float THROW_SPEED = 4000;

	private GameObject closeObject;
	private SteamVR_ControllerManager manager = null;
	private SteamVR_TrackedObject trackedObject = null;

	private Vector3 oldPosition = Vector3.zero;
	private Vector3 oldRotation = Vector3.zero;
	private bool holdingObject = false;

	private void Awake () {
		trackedObject = GetComponent<SteamVR_TrackedObject> ();
	}
	
	private void Update () {
		Controller ((int)trackedObject.index);
		oldPosition = transform.position;
	}

	private void Controller(int index){
		if (trigger (index)) {
			if (closeObject != null && !holdingObject) {
				Grab ();
			}

		} else if (closeObject != null && holdingObject){
			Drop ();
		}
	}

	private void Grab(){
		closeObject.GetComponent<Rigidbody> ().isKinematic = true;
		oldRotation = closeObject.transform.eulerAngles;
		closeObject.transform.parent = transform;
		holdingObject = true;
	}

	private void Drop(){
		Vector3 vel = (transform.position - oldPosition) * THROW_SPEED;

		closeObject.GetComponent<Rigidbody> ().isKinematic = false;
		closeObject.GetComponent<Rigidbody> ().AddForce (vel);
		closeObject.transform.parent = null;
		closeObject = null;
		holdingObject = false;
	}

	private bool trigger(int index){
		return index > 0 && SteamVR_Controller.Input (index).GetPress (SteamVR_Controller.ButtonMask.Trigger);
	}

	private void OnTriggerEnter(Collider collider) {
		closeObject = collider.gameObject;
	}

	private void OnTriggerExit(Collider collider){
		if (!holdingObject && collider.gameObject.Equals (closeObject)) {
			closeObject = null;
		}
	}

}
