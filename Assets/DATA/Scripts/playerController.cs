using UnityEngine;

[RequireComponent(typeof(playerMotor))]
public class playerController : MonoBehaviour {

    [SerializeField]
    private float speed = 5f;
    [SerializeField]
    private float lookSensitivity = 3f;
    private playerMotor motor;

    void Start ()
    {
        //Cursor.lockState = CursorLockMode.Locked; // Locks the mouse pointer in center and make it invisible.
        motor = GetComponent<playerMotor>();
    }

    void Update ()
    {
        //Calculate movement velocity as a 3D vector
        float _xMov = Input.GetAxisRaw("Horizontal");
        float _zMov = Input.GetAxisRaw("Vertical");

        Vector3 _movHorizontal = transform.right * _xMov;
        Vector3 _movVertical = transform.forward * _zMov;

        //Final movement vector
        Vector3 _velocity = (_movHorizontal + _movVertical).normalized * speed;

        //Apply movement
        motor.Move(_velocity);

        //Calculate rotation as a 3D vector (Turning around)
        float _yRot = Input.GetAxisRaw("Mouse X");

        Vector3 _rotation = new Vector3(0f, _yRot, 0f) * lookSensitivity;
        // Apply rotation
        motor.Rotate(_rotation);

        //Calculate camera rotation as a 3D vector (Turning around)
        float _xRot = Input.GetAxisRaw("Mouse Y");

        float _cameraRotationX = _xRot * lookSensitivity;
        // Apply rotation
        motor.Rotate(_rotation);
        motor.RotateCamera(_cameraRotationX);

        // Unlock the mouse pointer when ESC is pressed
        //if (Input.GetKeyDown("escape"))
        //    Cursor.lockState = CursorLockMode.None;
    }
}
