using System.Collections;
using UnityEngine;

public class TDPlayerController : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform bulletDirection;
    [SerializeField] private float movementVelocity = 3f;
    [SerializeField] private GameObject _bullets;

    private TDActions controls;
    private bool canShoot = true;
    private Camera mainCamera;
    private void Awake()
    {
        controls = new TDActions();
    }
    void Start()
    {
        controls.Player.Shoot.performed += _ => PlayerShoot();
        mainCamera = Camera.main;
    }


    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    
    private void PlayerShoot()
    {
        if(!canShoot) return;
        Vector2 mousePosition = controls.Player.MousePosition.ReadValue<Vector2>();
        mousePosition = mainCamera.ScreenToWorldPoint(mousePosition);
        GameObject g = Instantiate(bullet, bulletDirection.position, bulletDirection.rotation, _bullets.transform);
        g.SetActive(true);
        StartCoroutine(CanShoot());
    }

    IEnumerator CanShoot()
    {
        canShoot = false;
        yield return new WaitForSeconds(.2f);
        canShoot = true;
    }
    
    void Update()
    {
        //Rotation
        Vector2 mouseScreenPosition = controls.Player.MousePosition.ReadValue<Vector2>();
        Vector3 mouseWorldPosition = mainCamera.ScreenToWorldPoint(mouseScreenPosition);
        Vector3 targetDirection = mouseWorldPosition - transform.position;
        float angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0f,0f,angle));
        //Movement
        Vector3 movement = controls.Player.Movement.ReadValue<Vector2>() * movementVelocity;
        transform.position += Time.deltaTime * movement;
    }
}
