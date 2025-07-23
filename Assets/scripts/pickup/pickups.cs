using UnityEngine;

public abstract class pickups : MonoBehaviour
{
    [SerializeField] float rotationspeed = 100f;
    private void Update()
    {
        transform.Rotate(Vector3.up, rotationspeed * Time.deltaTime);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Onpickup();
            Destroy(gameObject); // Destroy the pickup after it has been collected

        }
    }
    protected abstract void Onpickup();
}
