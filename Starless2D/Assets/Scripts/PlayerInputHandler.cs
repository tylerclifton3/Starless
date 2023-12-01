using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputHandler : MonoBehaviour
{

    [SerializeField] Movement movement;
    [SerializeField] PlayerCombat playerCombat;
    [SerializeField] ProjectileShooter projectileShooter;
    public bool isSprinting = false;

    public float attackRate = 2f;
    float nextAttackTime = 0f;

    void Awake()
    {

    }

    void Update()
    {     
        Vector3 vel = Vector3.zero;
        if (Input.GetKey(KeyCode.W)) {
            vel.y = 1;
        } else if (Input.GetKey(KeyCode.S)) {
            vel.y = -1;
        }
        if (Input.GetKey(KeyCode.A)) {
            vel.x = -1;
        } else if (Input.GetKey(KeyCode.D)) {
            vel.x = 1;
        }
        if (Input.GetKey(KeyCode.LeftShift)) { // sprint
            isSprinting = true;
        } else {
            isSprinting = false;
        }
        //movement.MoveTransform(vel);
        if(isSprinting) {
            movement.MoveRB(vel.normalized * 2);
        } else {
            movement.MoveRB(vel.normalized);
        }

        if (Input.GetKeyDown(KeyCode.Mouse0)) {
            if(Time.time >= nextAttackTime) {
                playerCombat.Attack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
        
        //use weapon handler (didnt use, no time for more weapons ;-; so i just left it as arrows that do nothing)
        if (Input.GetKeyDown(KeyCode.Q)) {
            projectileShooter.Shoot(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        }
    }
}
