using UnityEngine;
using UnityEngine.Events;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] private string _animationTrigger = "OnCollisionEnter";
    [SerializeField] private Animator _animator;
    
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _animator.SetTrigger(_animationTrigger);
        }
    }
}