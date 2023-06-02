using UnityEngine;
public class goblinSwordDamage : MonoBehaviour
{
  public float _goblinSwordDamage;
  private playerController _playerLife;
  private void OnTriggerEnter2D(Collider2D other)
  {
    if (other.gameObject.tag == "Player")
    {
      other.gameObject.GetComponent<playerController>().TakeDamage(_goblinSwordDamage);
    }
    if (other.gameObject.tag == "Follower")
    {
      other.gameObject.GetComponent<followerController>().TakeDamageFollower(_goblinSwordDamage);
    }
  }
}