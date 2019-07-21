using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float moveSpeed;
    private Vector2 moveDirection;
    private Rigidbody rb;

    private void OnEnable()
    {
        Invoke("Destroy", 3f);
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        //if(moveDirection = null)
        //{
        //    transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
        //}
        //else
        //{
        TransformObject();
        //}
    }
    void TransformObject()
    {
        rb.velocity = transform.forward * moveSpeed;
    }

    public void SetMoveDirection(Vector2 dir)
    {
        moveDirection = dir;
    }
    private void Destroy()
    {
        gameObject.SetActive(false);
    }
    private void OnDisable()
    {
        CancelInvoke();
    }
}