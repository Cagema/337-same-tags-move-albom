using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationBehaviour : MonoBehaviour
{
    [SerializeField] float _rotSpeed;

    Vector2 _mousePos;
    private void Update()
    {
        if (GameManager.Single.GameActive)
        {
            if (Input.GetMouseButton(0))
            {
                _mousePos = GameManager.Single.MainCamera.ScreenToWorldPoint(Input.mousePosition);
                if (_mousePos.x > 0)
                {
                    transform.Rotate(0, 0, -_rotSpeed * Time.deltaTime);
                }
                else
                {
                    transform.Rotate(0, 0, _rotSpeed * Time.deltaTime);
                }
            }
        }
    }
}
