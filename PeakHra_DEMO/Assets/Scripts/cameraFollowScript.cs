using UnityEngine;
using UnityEngine.InputSystem.Controls;

public class cameraFollowScript : MonoBehaviour
{
    public float followSpeed = 2f;
    public Transform target;

    // Update is called once per frame
    void Update()
    {
        Vector3 novaPos = new Vector3(target.position.x, target.position.y, -10f);
        transform.position = Vector3.Slerp(transform.position, novaPos, followSpeed * Time.deltaTime);
    }
}
