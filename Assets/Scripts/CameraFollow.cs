using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    private GameObject Player;
    private GameObject followPoint;
    [SerializeField] private float speed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        followPoint = Player.transform.Find("FollowPoint").gameObject;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Follow();
    }

    private void Follow()
    {
        gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, followPoint.transform.position, Time.deltaTime * speed);
        gameObject.transform.LookAt(Player.transform.position);
    }
}
