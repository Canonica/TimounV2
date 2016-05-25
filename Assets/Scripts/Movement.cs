using UnityEngine;
using System.Collections;
using XInputDotNetPure;

[RequireComponent(typeof(CharacterController))]
public class Movement : MonoBehaviour {

    CharacterController characterController;
    public Camera _camera;

    Quaternion _lastCameraRotation;

    Vector3 _velocity;
    public float _speed;
    public float _rotateSpeed;

    public float m_hLeft;
    public float m_vLeft;

    public float m_hRight;
    public float m_vRight;

    // Use this for initialization
    void Start () {
        characterController = GetComponent<CharacterController>();
        _lastCameraRotation = _camera.transform.rotation;
    }
	
	// Update is called once per frame
	void Update () {


        m_vLeft = XInput.instance.getYStickLeft(0);
        m_hLeft = XInput.instance.getXStickLeft(0);

        m_hRight = XInput.instance.getXStickRight(0);
        m_vRight = XInput.instance.getYStickRight(0);

        Vector3 _movHorizontal = transform.right * m_hLeft;
        Vector3 _movVertical = transform.forward * m_vLeft;

        Vector3 _rightVelocity = new Vector3(-m_hLeft, 0.0f, m_vLeft);
        float s = Mathf.Atan2(
            Vector3.Dot(Vector3.up, Vector3.Cross(_camera.transform.forward, _rightVelocity)),
            Vector3.Dot(_camera.transform.forward, _rightVelocity));
        float angle = s * Mathf.Rad2Deg;
        //float angleTLeft = Mathf.Atan2(m_hLeft, m_vLeft);

        _velocity = new Vector3(m_hLeft, 0.0f, m_vLeft);
        _velocity = _camera.transform.TransformDirection(_velocity);
        _velocity = new Vector3(_velocity.x, 0.0f, _velocity.z);
        _velocity *= _speed;

        //_velocity = (_movHorizontal + _movVertical).normalized;
        if(m_hLeft !=0 || m_vLeft != 0)
        {
            transform.rotation = Quaternion.LookRotation(new Vector3(_camera.transform.forward.x, transform.forward.y, _camera.transform.forward.z));
            characterController.Move(_velocity * Time.deltaTime);
        }

        if (m_hRight == 0 && m_vRight == 0 && (m_hLeft != 0 || m_vLeft != 0))
        {

            playerRotate(-angle);
        }  
    }

    private void playerRotate(float parAngle)
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0f, parAngle, 0f), _rotateSpeed);
     

    }
}
