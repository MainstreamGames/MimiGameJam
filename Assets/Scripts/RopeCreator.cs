using UnityEngine;
using System.Collections;

public class RopeCreator : MonoBehaviour {

	public GameObject node;
	public int seqments;
	public GameObject player1;
	public GameObject player2;

	// Use this for initialization
	void Start () {
		createRope (player1, player2);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void createRope(GameObject from, GameObject to) {
		GameObject current = createNode (from, to, 1);
		SpringJoint2D spring = (SpringJoint2D) from.AddComponent<SpringJoint2D> ();
		spring.distance = 0.1f;
		spring.dampingRatio = 1;
		spring.frequency = 10;
		spring.connectedBody = current.GetComponent<Rigidbody2D>();
		for (int i = 2; i < seqments; i++) {
			GameObject next = createNode (from, to, i);
			current.GetComponent<SpringJoint2D> ().connectedBody = next.GetComponent<Rigidbody2D>();
			current = next;
		}
		current.GetComponent<SpringJoint2D> ().connectedBody = to.GetComponent<Rigidbody2D>();
	}

	public GameObject createNode(GameObject from, GameObject to, int n) {
		Vector3 pos = (to.transform.position - from.transform.position) * (n / seqments);
		return (GameObject)GameObject.Instantiate (node, pos, Quaternion.identity);
	}
}
