using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    protected const float INTERPOLATION = 10;
    protected const float BACKWARDS_RUN_SCALE = 0.66f;
    protected const float MIN_JUMP_INTERVAL = 0.25f;

    protected float _currentV;
    protected float _currentH;

    protected bool _isGrounded;
    protected bool _wasGrounded;
    protected bool _canDoubleJump;
    protected float _jumpTimeStamp;

    protected CharacterStateLibrary _characterStateLibrary;
    protected CharacterState _currCharacterState;
    protected InputControl _inputControl;

    protected Animator _animator;
    protected Rigidbody _rigidbody;

    protected CharacterStats _characterStats;
    protected GameObject _characterModel;



    protected void handleInput()
    {
        _currCharacterState.handleInput();
    }


    public void Move()
    {

    }

    public bool Jump()
    {
        bool jumpCooldownOver = Time.time - _jumpTimeStamp >= MIN_JUMP_INTERVAL;

        if (!jumpCooldownOver || (!_isGrounded && !_canDoubleJump)) { return false; }

        if (jumpCooldownOver && _isGrounded)
        {
            _jumpTimeStamp = Time.time;
            _rigidbody.AddForce(Vector3.up * _characterStats.JumpForce, ForceMode.Impulse);
            return true;
        }

        if (_canDoubleJump && !_isGrounded)
        {
            double kinetic = 0.5 * _rigidbody.mass * Math.Pow(_rigidbody.velocity.y, 2);
        }




    }

    public virtual void JumpingAndLanding()
    {
        bool jumpCooldownOver = (Time.time - _jumpTimeStamp) >= MIN_JUMP_INTERVAL;

        if (jumpCooldownOver && m_isGrounded && usedSpace)
        {
            m_jumpTimeStamp = Time.time;
            m_rigidBody.AddForce(Vector3.up * m_jumpForce, ForceMode.Impulse);
        }

        if (canDoubleJump && character.characterStats.EnergyRemaining > character.characterStats.SpecialMovementCost && !m_isGrounded && usedSpace)
        {
            m_rigidBody.AddForce(Vector3.up * m_jumpForce, ForceMode.Impulse);
            canDoubleJump = false;
            character.characterStats.RemoveSpecialMovementEnergy();
            m_animator.SetBool("Grounded", !m_isGrounded);
            m_animator.SetTrigger("Jump");

            jumped = true;
        }

        if (!m_wasGrounded && m_isGrounded)
        {
            m_animator.SetTrigger("Land");
            jumped = false;
        }

        if (!m_isGrounded && m_wasGrounded)
        {
            m_animator.SetTrigger("Jump");
            jumped = true;
        }
    }

    private void crowdControl(int effect, float duration, params float[] intensity)
    {
        switch(effect)
        {
            case SwitchID.Stun:
                StartCoroutine(Stun(duration));
                break;
            case SwitchID.Slow:
                StartCoroutine(Slow(duration, intensity[0]));
                break;
            case SwitchID.Silence:
                StartCoroutine(Silence(duration));
                break;
            case SwitchID.Disarm:
                StartCoroutine(Disarm(duration));
                break;
        }
    }

    private IEnumerator Stun(float duration)
    {
        _inputControl.lockGameplayInput();
        yield return new WaitForSeconds(duration);
        _inputControl.unlockGameplayInput();
    }

    private IEnumerator Slow(float duration, float intensity)
    {
        float originalSpeed = _characterStats.MovementSpeed;
        _characterStats.MovementSpeed *= intensity;
        _animator.speed *= intensity;

        yield return new WaitForSeconds(duration);

        _characterStats.MovementSpeed = originalSpeed;
        _animator.speed = 1;
    }

    private IEnumerator Silence(float duration)
    {
        _inputControl.lockSpecial();
        yield return new WaitForSeconds(duration);
        _inputControl.unlockSpecial();
    }

    private IEnumerator Disarm(float duration)
    {
        _inputControl.lockAttack();
        yield return new WaitForSeconds(duration);
        _inputControl.unlockAttack();
    }

    public virtual void OnCollisionEnter(Collision collision)
    {
        ContactPoint[] contactPoints = collision.contacts;
        for (int i = 0; i < contactPoints.Length; i++)
        {
            if (Vector3.Dot(contactPoints[i].normal, Vector3.up) > 0.5f)
            {
                if (!m_collisions.Contains(collision.collider))
                {
                    m_collisions.Add(collision.collider);
                }
                m_isGrounded = true;

                canDoubleJump = true;
            }
        }
    }

    public virtual void OnCollisionStay(Collision collision)
    {
        ContactPoint[] contactPoints = collision.contacts;
        bool validSurfaceNormal = false;
        for (int i = 0; i < contactPoints.Length; i++)
        {
            if (Vector3.Dot(contactPoints[i].normal, Vector3.up) > 0.5f)
            {
                validSurfaceNormal = true; break;
            }
        }

        if (validSurfaceNormal)
        {
            m_isGrounded = true;
            if (!m_collisions.Contains(collision.collider))
            {
                m_collisions.Add(collision.collider);
            }
        }
        else
        {
            if (m_collisions.Contains(collision.collider))
            {
                m_collisions.Remove(collision.collider);
            }
            if (m_collisions.Count == 0) { m_isGrounded = false; }
        }
    }

    public virtual void OnCollisionExit(Collision collision)
    {
        if (m_collisions.Contains(collision.collider))
        {
            m_collisions.Remove(collision.collider);
        }
        if (m_collisions.Count == 0) { m_isGrounded = false; }
    }

}
