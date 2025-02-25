using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float MoveSpeed;
    public float RotationSpeed;
    public float JumpHeight;

    [SerializeField] GameObject cam;
    [SerializeField] float lookSpeed;
    private Vector3 cameraRot;
    private Vector3 playerRot;

    private int _objectsUnderPlayer;

    public int HealthPoint;

    public int ActualPoints;
    public int TotalPoints;

    public bool IsDead = false;
    public float SurvivedTimer = 0;
    void Update()
    {
        cameraRot = cam.transform.rotation.eulerAngles;
        cameraRot.x += -Input.GetAxis("Mouse Y") * lookSpeed;
        cameraRot.x = Mathf.Clamp((cameraRot.x <= 180) ? cameraRot.x : -(360 - cameraRot.x), -80f, 80f);
        cam.transform.rotation = Quaternion.Euler(cameraRot);
        playerRot.y = Input.GetAxis("Mouse X") * lookSpeed;
        transform.Rotate(playerRot);

        Vector3 CurrentSpeed =
            transform.forward * Input.GetAxis("Vertical") * MoveSpeed +
            transform.right * Input.GetAxis("Horizontal") * MoveSpeed;

        CurrentSpeed.y = GetComponent<Rigidbody>().linearVelocity.y;

        if (Input.GetKeyDown(KeyCode.Space) && _objectsUnderPlayer > 0)
        {
            CurrentSpeed.y += JumpHeight;
        }

        GetComponent<Rigidbody>().linearVelocity = CurrentSpeed;

        if(IsDead == false)
        {
            SurvivedTimer += Time.deltaTime;
        }
    }

    private void Start()
    {
        TotalPoints = ActualPoints;
    }

    private void OnTriggerEnter(Collider other)
    {
        _objectsUnderPlayer++;
    }
    private void OnTriggerExit(Collider other)
    {
        _objectsUnderPlayer--;
    }
}
