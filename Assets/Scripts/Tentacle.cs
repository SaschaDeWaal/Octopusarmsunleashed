using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tentacle : MonoBehaviour {

    private const float ROTATE_SPEED = 25;
    private const float MOVE_SPEED = 100;

	private const float MAX_DISTANCE = 0.3f;

    private const float distanceSize = 0.1f;

    public Rigidbody connected;

    public float diff = 0f;

    private Rigidbody rigidBody;
    private Tentacle tantacle;
	private CharacterController controller;

	private void Start () {
        rigidBody = GetComponent<Rigidbody>();
        tantacle = connected.GetComponent<Tentacle>();
		controller = GetComponent<CharacterController> ();

    }

	
	private void FixedUpdate() {

		OldMethode ();
		//netMethode ();
    }


	private void OldMethode(){
		Vector3 targetPosition = connected.position + (connected.transform.forward * distanceSize);

        Vector3 vel = (targetPosition - transform.position);// * MOVE_SPEED;
		controller.Move(vel);

		Quaternion rotation = Tools.Lerp(transform.rotation, connected.rotation, ROTATE_SPEED);
		rigidBody.MoveRotation (rotation);
	}
}
