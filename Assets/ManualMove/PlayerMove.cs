using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // Start is called before the first frame update

    private float moveX;
    private float moveZ;
    private Vector3 dir;
    public float speed;
    void Start()
    {
        moveX = 0;
        moveZ = 0;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerInput();
        Vector3 move = speed * new Vector3(dir.x, 0, dir.z);
        transform.Translate(move * Time.deltaTime);
    }

    public void PlayerInput()
    {
        moveX = Input.GetAxisRaw("Horizontal");
        moveZ = Input.GetAxisRaw("Vertical");
        dir = new Vector3(moveX, 0, moveZ);
        dir = dir.normalized;
    }
}
