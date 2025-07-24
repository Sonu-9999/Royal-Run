using System.Collections;
using Unity.Cinemachine;
using UnityEngine;

public class cameracontroller : MonoBehaviour
{
    [SerializeField] ParticleSystem speedupparticle;
    [SerializeField] float minFOV = 20f;
    [SerializeField] float maxFOV = 120f;
    [SerializeField] float zoomduration = 0.5f;
    [SerializeField] float zoomspeed = 10f;
    CinemachineCamera cinemachinecamera;
    void Awake()
    {
        cinemachinecamera = GetComponent<CinemachineCamera>();
        speedupparticle.Stop(); // Ensure the particle system is stopped at the start
    }
    public void ChangeCameraFOV(float speed)
    {
        StopAllCoroutines(); // Stop any ongoing FOV changes to ensure smooth transitions
        StartCoroutine(changeFOV(speed));
        if (speed > 0)
        {
            speedupparticle.Play();
        }
    }
    IEnumerator changeFOV(float speed)
    {
        float startFOV = cinemachinecamera.Lens.FieldOfView;
        float targetFOV = Mathf.Clamp(startFOV + speed* zoomspeed, minFOV, maxFOV);
        float elapsedTime = 0f;
        while (elapsedTime < zoomduration)
        {
            elapsedTime += Time.deltaTime;
            float newFOV = Mathf.Lerp(startFOV, targetFOV, elapsedTime);
            cinemachinecamera.Lens.FieldOfView = newFOV;
            yield return null;
        }
        
    }
}
