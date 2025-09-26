using UnityEngine;

public class Attack_Script : MonoBehaviour
{
    private float timeBetweenAttack;
    public float startTimeBetweenAttack;

    private AnimatorStateInfo currentAnimState;

    private bool comboLocked = false;

    private bool isComboWindowOpen = false;
    private float comboWindowStartTime;
    public float comboWindowDelay = 0.3f; // Time after attack starts before next input allowed

    public Transform attackPos;
    public LayerMask whatIsEnemies;
    public float attackRange;
    public int damage1 = 10;
    public int damage2 = 8;
    public int damage3 = 20;

    public Animator camAnimator;
    public Animator playerAnimator;

    [HideInInspector] public bool isAttacking = false;

    private int comboStep = 0;
    private float lastAttackTime;
    public float comboResetTime = 1f;

    void Update()
    {
        // Reset isAttacking if combo stalls
        if (isAttacking && Time.time - lastAttackTime > comboResetTime)
        {
            isAttacking = false;
            comboStep = 0;
        }

        if (timeBetweenAttack <= 0)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                // Reset combo if too slow
                if (Time.time - lastAttackTime > comboResetTime)
                {
                    comboStep = 0;
                }

                comboStep++;
                lastAttackTime = Time.time;
                isAttacking = true;

                camAnimator.SetTrigger("shake");

                int damageToDeal = damage1;
                string animationTrigger = "attack";

                if (comboStep == 1)
                {
                    animationTrigger = "attack";
                    damageToDeal = damage1;
                    Debug.Log("Attack triggered: " + animationTrigger);
                }
                else if (comboStep == 2)
                {
                    animationTrigger = "attack2";
                    damageToDeal = damage2;
                }
                else if (comboStep == 3)
                {
                    animationTrigger = "attack3";
                    damageToDeal = damage3;
                    comboStep = 0; // Reset after final hit
                }

                playerAnimator.SetTrigger(animationTrigger);

                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    enemiesToDamage[i].GetComponent<Enemy>().TakeDamage(damageToDeal);
                }

                timeBetweenAttack = startTimeBetweenAttack;
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
        comboLocked = false;
        isAttacking = false;
        Debug.Log("Combo unlocked");
        comboStep = 0;
        playerAnimator.ResetTrigger("attack");
        playerAnimator.ResetTrigger("attack2");
        playerAnimator.ResetTrigger("attack3");

    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}