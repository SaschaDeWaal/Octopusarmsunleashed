using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Tools {

	
	public static Quaternion Lerp(Quaternion from, Quaternion to, float speed) {
        float distance = Mathf.Clamp( Quaternion.Angle(from, to), 0f, 100f);
        return Quaternion.RotateTowards(from, to, Mathf.Clamp(speed * distance, 5, 2000) * Time.deltaTime);
    }

    public static Vector3 Lerp(Vector3 from, Vector3 to, float speed) {
        float distance = Vector3.Distance(from, to);
        return Vector3.MoveTowards(from, to, Mathf.Clamp(speed * distance, 5, 2000) * Time.deltaTime);
    }
}
