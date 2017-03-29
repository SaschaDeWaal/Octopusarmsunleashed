using UnityEngine;
using System.Collections;

public class CubeSound : MonoBehaviour {

	private const float MIN_SEC = 3;

	public AudioClip[] audioClips = new AudioClip[0];

	private AudioSource audioSource = null;
	private float lastPlayed = -1f;

	private void Start(){
		audioSource = GetComponent<AudioSource> ();
	}

	private void OnCollisionEnter(Collision collider) {
		if (collider.gameObject.tag != "controller") {
			PlaySound ();
		}
	}

	private void PlaySound(){
		if (audioClips.Length > 0 && Time.time - lastPlayed > MIN_SEC && transform.parent == null) {
			audioSource.PlayOneShot (audioClips [Random.Range (0, audioClips.Length)]);
			lastPlayed = Time.time;
		}
	}
}
