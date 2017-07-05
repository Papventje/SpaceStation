using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMovement : MonoBehaviour {

    private Vector2 mouselook;
    private Vector2 smoothV;

    public float sensitivity = 4.0f;
    public float smoothing = 2.0f;

    private GameObject player;

	// Use this for initialization
	void Start () {
        player = transform.parent.gameObject;
	}
	
	// Update is called once per frame
	void Update () {
        var md = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

        md = Vector2.Scale(md, new Vector2(sensitivity * smoothing, sensitivity * smoothing));
        smoothV.x = Mathf.Lerp(smoothV.x, md.x, 1f / smoothing);
        smoothV.y = Mathf.Lerp(smoothV.y, md.y, 1f / smoothing);
        mouselook += smoothV;
        mouselook.y = Mathf.Clamp(mouselook.y, -45f, 45f);

        transform.localRotation = Quaternion.AngleAxis(-mouselook.y, Vector3.right);
        player.transform.localRotation = Quaternion.AngleAxis(mouselook.x, player.transform.up);

	}
}
