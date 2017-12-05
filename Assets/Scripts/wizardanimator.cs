using UnityEngine;
using System.Collections;

public class wizardanimator: MonoBehaviour 
{
    Animator anim;
	int trigger = 0;
	int idle_hash = Animator.StringToHash("wizard-idle");
    int move_hash = Animator.StringToHash("wizard-move");
    int attack_hash = Animator.StringToHash("wizard-attack");


    void Start ()
    {
        anim = GetComponent<Animator>();
    }


    void Update ()
    {
        //float move = Input.GetAxis ("Vertical");
        //anim.SetFloat("Speed", move);

        AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);
        if(stateInfo.nameHash == idle_hash && trigger == 1)
        {
            anim.SetTrigger (move_hash);
        }
    }
}
