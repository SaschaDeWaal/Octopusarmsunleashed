using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetTentacle : MonoBehaviour {

    private const float Distance = 2f;

    private List<GameObject> carry = new List<GameObject>();
    private List<Vector3> offset = new List<Vector3>();

	private void Start () {
		
	}

    private void Update () {
		for(int i = 0; i < carry.Count; i++) {

            if(Vector3.Distance(transform.position, carry[i].transform.position) > Vector3.Distance(Vector3.zero, offset[i]) + (Distance * Time.deltaTime)) {
                carry[i].GetComponent<Rigidbody>().isKinematic = false;
                carry.RemoveAt(i);
                offset.RemoveAt(i);
                return;
            } else {
                carry[i].transform.position = transform.position + offset[i];
            }
        }
	}

    private void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.tag == "grabObject") {
            carry.Add(collision.gameObject);
            offset.Add(collision.transform.position - transform.position);
            collision.gameObject.GetComponent<Rigidbody>().isKinematic = true;
        }
    }


}
