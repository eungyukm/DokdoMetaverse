using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DLLTest;
public class ResetForward : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }
    public Transform forward;
    public Transform player;
    public Transform myCamera;
    // Update is called once per frame
    void Update()
    {
        //transform.Translate(Vector3.ProjectOnPlane(myCamera.forward, Vector3.up).normalized * Time.deltaTime * -moveSpeed, Space.World);

        Move();
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            //Debug.Log("11: " + Vector3.ProjectOnPlane(myCamera.forward, Vector3.up));
            //Debug.Log("22: " + Vector3.ProjectOnPlane(myCamera.forward, Vector3.up).normalized);
            ResetForwards();
            MyUtil myUtil = new MyUtil();
            Debug.Log( MyUtil.GenerateRandom(1, 10));
        }
       
    }
    Vector2 virtualMoveDirection;
    public void VirtualMoveInput(Vector2 virtualMoveDirection)
    {
        this.virtualMoveDirection = virtualMoveDirection;
        Debug.Log("virtualMoveDirection: " + virtualMoveDirection);
        
    }

    public void Move()
    {
        transform.Translate(Vector3.ProjectOnPlane(myCamera.forward, Vector3.up).normalized * Time.deltaTime * virtualMoveDirection.y * moveSpeed, Space.World);
        transform.Translate(Vector3.ProjectOnPlane(myCamera.right, Vector3.up).normalized * Time.deltaTime * virtualMoveDirection.x * moveSpeed, Space.World);
    }

    public float moveSpeed = 5f;
    public void ClickForward()
    {
        transform.Translate(Vector3.ProjectOnPlane(myCamera.forward, Vector3.up).normalized * Time.deltaTime * moveSpeed);
    }
    public void ClickBack()
    {
        transform.Translate(Vector3.ProjectOnPlane(myCamera.forward, Vector3.up).normalized * Time.deltaTime * -moveSpeed);
    }
    public void ClickSetSpeed(float moveSpeed)
    {
        this.moveSpeed = moveSpeed;
    }

    public void ResetForwards()
    {
        //Debug.Log("11: " + Vector3.ProjectOnPlane(myCamera.forward, Vector3.up));
        //Debug.Log("22: " + Vector3.ProjectOnPlane(myCamera.forward, Vector3.up).normalized);
        Vector3 forwardNormal = Vector3.ProjectOnPlane(forward.forward, Vector3.up);
        Vector3 cameraNormal = Vector3.ProjectOnPlane(myCamera.forward, Vector3.up);
        //Vector3 tt = forwardNormal - cameraNormal;
        //Quaternion quat = Quaternion.Euler(tt * 360f);

        //Vector3 v = myCamera.position - forward.position;
        var vv =  Vector3.Angle(forwardNormal, cameraNormal);
        //var vv = GetAngle(forward.position, myCamera.position);
        Debug.Log("myCamera.eulerAngles: " + myCamera.eulerAngles.y);
        Debug.Log("Angle: "+ vv);
        if(myCamera.eulerAngles.y > 180f)
        {
            Debug.Log("11");
            player.eulerAngles += Vector3.up * vv;
        }
        else
        {
            Debug.Log("22");
            player.eulerAngles -= Vector3.up * vv;
        }
        //AngleToDirection(Angle);


        //player.rotation *= quat;
        //player.LookAt();
        //player.LookAt(player.position + normal);
    }
    private void AngleToDirection(float angle)
    {
        Vector3 direction = Vector3.up;
        // 정면을 기준으로 한다면 transform.forward; 를 입렵하면 된다.

        var quaternion = Quaternion.Euler(0, angle, 0);
        player.rotation *= quaternion;

        //return newDirection;
    }

    float GetAngle(Vector3 start, Vector3 end)
    {
        Vector3 v2= end - start;
        //v2 = v2.normalized;
        Debug.Log("v2: " + v2);
        return Mathf.Atan2(v2.z, v2.x) * Mathf.Rad2Deg;
    }


}
