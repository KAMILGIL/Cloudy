using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;
using Vector4 = System.Numerics.Vector4;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rigidbody;

    private Vector3 acceleration; 

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            rigidbody.MovePosition(transform.position + Vector3.left * 20f * Time.deltaTime);
        }
        
        if (Input.GetKey(KeyCode.D))
        {
            rigidbody.MovePosition(transform.position + Vector3.right * 20f * Time.deltaTime);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (rigidbody.velocity.x > 1)
        {
            return;
        }

        rigidbody.velocity = Vector3.zero;
        rigidbody.angularVelocity = Vector3.zero;
        rigidbody.angularDrag = 0f;
        Vector3 force = Vector3.up * 6300f + Vector3.forward * 1200f;

        rigidbody.AddForce(force);
        acceleration = force / rigidbody.mass;

        print(acceleration.y.ToString() + " " + acceleration.z.ToString());
    }
}
