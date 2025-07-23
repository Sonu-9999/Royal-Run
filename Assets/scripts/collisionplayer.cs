using UnityEngine;

public class collisionplayer : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] float collisioncooldown = 1f;
    float cooldowntimer = 0f;
    const string trigger = "Hit";
    void Update()
    {
        cooldowntimer+= Time.deltaTime;
    }
    void OnCollisionEnter(Collision other)
    {
        if (cooldowntimer < collisioncooldown) return;
        animator.SetTrigger(trigger);
        cooldowntimer = 0f;
    }
}
