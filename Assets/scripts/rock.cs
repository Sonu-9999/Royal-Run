using Unity.Cinemachine;
using UnityEngine;

public class rock : MonoBehaviour
{
    CinemachineImpulseSource impulseSource;
    [SerializeField] ParticleSystem collisionParticleSystem;
    [SerializeField] AudioSource collisioinAudioSource;
    [SerializeField] float impulsefactor = 8f;
    void Awake()
    {
        impulseSource = GetComponent<CinemachineImpulseSource>();
    }
    void OnCollisionEnter(Collision collision)
    {
        camerashake(collision);
        collisionFX(collision);
        playaudio();
    }

    private void camerashake(Collision collision)
    {
        float distanceofcollision = Vector3.Distance(collision.transform.position, Camera.main.transform.position);
        // Calculate the impulse strength based on the distance of the collision
        float impulsestrength = (1f / distanceofcollision) * impulsefactor;
        float shakeintensity = Mathf.Min(impulsestrength, 2.5f);// Limit the intensity to a maximum of 2
        impulseSource.GenerateImpulse(shakeintensity);
    }
    void collisionFX(Collision collision)
    {
        ContactPoint contact = collision.contacts[0]; //gives the vector3 pos of where the collision happened
        collisionParticleSystem.transform.position = contact.point; //moves the particle system to the collision point
        collisionParticleSystem.Play();
    }
    void playaudio()
    {
        if (collisioinAudioSource.isPlaying == false)
        {
            collisioinAudioSource.Play();
        }
       
    }
}