using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    // Field of view from video: https://www.youtube.com/watch?v=OQ1dRX5NyM0
    public float radius = 5;
    [Range(0, 360)]public float angle = 45;
    public LayerMask targetLayer;
    public LayerMask obstructionLayer;


    public GameObject playerRef;

    public bool CanSeePlayer {
        get; private set;
    }
    // Start is called before the first frame update
    void Start()
    {
        playerRef = GameObject.FindGameObjectWIthTag("Player");
    }

    private IEnumerator FOVCeck(){
        WaitForSeconds wait = new WaitForSeconds(0.2f);

        while(true){
            yield return wait;
            FOV();
        }
    }

    private void FOV(){
        Collider2D[] rangeCheck = Physics2D.OverlapCircleAll(transform.position, radius, targetLayer);

        if(rangeCheck.Length > 0){
            Transform target = rangeCheck[0].transform;
            Vector2 directionToTraget = (target.position - transform.position).normalized;

            if(Vector2.Angle(transform.up, directionToTarget) < angle / 2){
                float distanceToTarget = Vector2.Distance(transform.position - target.position);

                if(!Physics2D.Raycast(transform.position, directionToTarget, distanceToTarget, obstructionLayer))
                    CanSeePlayer = true;
                else
                    CanSeePlayer = false;
            }
            else
                CanSeePlayer = false;
        }
        else if (CanSeePlayer)
            CanSeePlayer = false;
    }
}
