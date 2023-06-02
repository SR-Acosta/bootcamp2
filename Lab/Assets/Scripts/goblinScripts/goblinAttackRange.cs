using UnityEngine;
public class goblinAttackRange : MonoBehaviour
{
    private Animator _animator;
    private void Start()
    {
        _animator = GetComponentInParent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            _animator.SetBool("isAttacking",true);
        }
        if (other.gameObject.tag == "Follower")
        {
            _animator.SetBool("isAttacking",true);
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            _animator.SetBool("isAttacking",true);
        }
        if (other.gameObject.tag == "Follower")
        {
            _animator.SetBool("isAttacking",true);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            _animator.SetBool("isAttacking",false);
        }
        if (other.gameObject.tag == "Follower")
        {
            _animator.SetBool("isAttacking",false);
        }
    }
}