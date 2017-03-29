using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateTentacles : MonoBehaviour {

    public GameObject part;
    public int lenght = 10;

    private List<Tentacle> tantacles = new List<Tentacle>();

	private void Start () {
        tantacles.Add(part.GetComponent<Tentacle>());

        for(int i = 0; i < lenght; i++) {
            tantacles.Add(CreatePart());
        }
	}

    private Tentacle CreatePart() {
		GameObject obj    = Instantiate(part, part.transform.position, part.transform.rotation) as GameObject;
        Tentacle tentacle = obj.GetComponent<Tentacle>();

        tentacle.connected = tantacles[tantacles.Count - 1].GetComponent<Rigidbody>();

        obj.transform.parent = tantacles[tantacles.Count - 1].transform.parent;
        obj.name = "part" + tantacles.Count.ToString();

        return tentacle;
    }
	

}
