using UnityEngine;

public class Attack_Script : MonoBehaviour
{
    public float timeBetweenAttack = 1.2f;

    private AnimatorStateInfo currentAnimState;

    public AudioSource m_Attack1;
    public AudioSource m_Attack2;
    public AudioSource m_Attack3;
    private bool AttackLocked = false;

    public float attackCooldownTimer = 1;

    public Transform attackPos;
    public LayerMask whatIsEnemies;
    public float attackRange;
    public int damage1 = 10;
    public int damage2 = 15;
    public int damage3 = 20;

    public Animator camAnimator;
    public Animator playerAnimator;

    [HideInInspector] public bool isAttacking = false;

    private int comboStep = 0;
    private float lastAttackTime;
    public float comboResetTime = 1.8f;
    private bool canAttack = true;

    void Update()
    {
        // Reset isAttacking if combo stalls
        if (isAttacking && Time.time - lastAttackTime > comboResetTime)
        {
            isAttacking = false;
            comboStep = 0;
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (canAttack)
            {
                isAttacking = true; 

                if (Time.time - lastAttackTime > comboResetTime)
                {
                    comboStep = 0;
                }

                comboStep++;
                lastAttackTime = Time.time;
                canAttack = false;

                camAnimator.SetTrigger("shake");

                int damageToDeal = damage1;
                string animationTrigger = "attack";

                if (comboStep == 1)
                {
                    animationTrigger = "attack";
                    damageToDeal = damage1;
                    m_Attack1.Play();
                    Debug.Log("Attack triggered: " + animationTrigger);
                }
                else if (comboStep == 2)
                {
                    animationTrigger = "attack2";
                    damageToDeal = damage2;
                    m_Attack2.Play();
                }
                else if (comboStep == 3)
                {
                    animationTrigger = "attack3";
                    damageToDeal = damage3;
                    m_Attack3.Play();
                    comboStep = 0; // Reset after final hit
                }

                playerAnimator.SetTrigger(animationTrigger);

                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    enemiesToDamage[i].GetComponent<Enemy>().TakeDamage(damageToDeal);
                }
            }
        }
        else
        {
            timeBetweenAttack -= Time.deltaTime;
        }
    }

    // Called by animation event at the end of each attack animation
    public void EndAttack()
    {
        isAttacking = false;
        canAttack = true;
        Debug.Log("Combo unlocked");
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}