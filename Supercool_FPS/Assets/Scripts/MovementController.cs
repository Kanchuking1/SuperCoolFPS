using UnityEngine;

public class MovementController : MonoBehaviour
{
    Rigidbody rb;
    public float speed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 Movement = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        //Debug.Log(Movement);
        Movement = Movement.normalized * speed * Time.deltaTime;
        transform.position = transform.position + Movement;
    }
}