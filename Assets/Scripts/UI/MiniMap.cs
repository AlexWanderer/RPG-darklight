using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMap : MonoBehaviour {

    private Camera miniMapCamera;
    private Transform player;

    private void Awake()
    {
        miniMapCamera = GameObject.FindGameObjectWithTag(Tags.minimapCamera).GetComponent<Camera>();
        player = GameObject.FindGameObjectWithTag(Tags.player).GetComponent<Transform>();
    }

	// Update is called once per frame
	void Update () {
        miniMapCamera.transform.position = new Vector3(player.position.x, miniMapCamera.transform.position.y, player.position.z);
	}

    public void ZoomInClick()
    {
        miniMapCamera.orthographicSize -= 0.2f;
        if (miniMapCamera.orthographicSize <= 5)
        {
            miniMapCamera.orthographicSize = 5;
        }
    }

    public void ZoomOutClick()
    {
        miniMapCamera.orthographicSize += 0.2f;
        if (miniMapCamera.orthographicSize >= 15)
        {
            miniMapCamera.orthographicSize = 15;
        }
    }
}
