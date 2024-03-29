using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movecon : MonoBehaviour
{
    float speed = 8.0f;

    public float rotateSpeed = 6.0f;       // 회전 속도

    float h, v;

    Rigidbody playerRd;

    // Start is called before the first frame update
    void Start()
    {
        playerRd = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {


        // if(Input.GetKey(KeyCode.LeftArrow) == true){
        //     transform.Translate(Vector3.left * speed * Time.deltaTime); //(-1,0,0)
        // }
        // if (Input.GetKey(KeyCode.RightArrow) == true)
        // {
        //     transform.Translate(Vector3.right * speed * Time.deltaTime); //(1,0,0)
        // }

        // if (Input.GetKey(KeyCode.UpArrow) == true)
        // {
        //     transform.Translate(Vector3.forward * speed * Time.deltaTime); //(0,0,1)
        // }
        // if (Input.GetKey(KeyCode.DownArrow) == true)
        // {
        //     transform.Translate(Vector3.back * speed * Time.deltaTime); //(0,0,-1)
        // }

        // if(Input.GetKey(KeyCode.Space) == true){
        //     playerRd.AddForce(0, speed, 0);
        // }

        float fHorizontal = Input.GetAxis("Horizontal");
        float fVertical = Input.GetAxis("Vertical");
 
        transform.Translate(Vector3.right * Time.deltaTime * rotateSpeed * fHorizontal, Space.World);
        transform.Translate(Vector3.forward  * Time.deltaTime * rotateSpeed * fVertical, Space.World);
    }

    

    void FixedUpdate()
    {
        
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(h, 0, v); // new Vector3(h, 0, v)가 자주 쓰이게 되었으므로 dir이라는 변수에 넣고 향후 편하게 사용할 수 있게 함

        // 바라보는 방향으로 회전 후 다시 정면을 바라보는 현상을 막기 위해 설정
        if (!(h == 0 && v == 0))
        {
            // 이동과 회전을 함께 처리
            transform.position += dir * speed * Time.deltaTime;
            // 회전하는 부분. Point 1.
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(dir), Time.deltaTime * rotateSpeed);
        }
    }
}