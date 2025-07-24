using UnityEngine;
public class collisionplayer : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] float collisioncooldown = 1f;
    float cooldowntimer = 0f;
    const string trigger = "Hit";
    levelgenerator lg;
    void Start()
    {
        lg = FindFirstObjectByType<levelgenerator>();
    }
    void Update()
    {
        cooldowntimer+= Time.deltaTime;
    }
    void OnCollisionEnter(Collision other)
    {
        if (cooldowntimer < collisioncooldown) return;
        lg.changemovespeed(-2f);
        animator.SetTrigger(trigger);
        cooldowntimer = 0f;
    }
}
