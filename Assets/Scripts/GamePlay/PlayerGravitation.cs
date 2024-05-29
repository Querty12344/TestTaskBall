using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerGravitation : MonoBehaviour
{
    private PlayerInput _input;
    [SerializeField] private Rigidbody2D _rigidbody;
    private Vector3 _lastEnertion;
    
    public void Construct(PlayerInput input)
    {
        _input = input;
        _input.OnClick += ChangeGravitation;
    }

    public void ChangeGravitation()
    {
        _rigidbody.gravityScale = -_rigidbody.gravityScale;
    }
    public void Remove()
    {
        _input.OnClick -= ChangeGravitation;
        if(this != null)
         Destroy(gameObject);
    }

    public void SetPause(bool pause)
    {
        if (pause)
        {
            _lastEnertion = _rigidbody.velocity;
            _rigidbody.Sleep();
        }
        else
        {
            _rigidbody.WakeUp();
            _rigidbody.velocity = _lastEnertion;

        }
    }
}
