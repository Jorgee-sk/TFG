using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private static float _speed;
    private Rigidbody2D _rigidbody2D;
    private float _lastFire;
    public BgPoolController bgPoolController;
    private static float _defaultSpeed = 5;
    private static int _maxHealth = 10;
    private static int _health = 10;
    [SerializeField] private GameObject bullet;
    [SerializeField] private float bulletSpeed;
    private static float _maxFireDelay = 0.5f;
    private static float _fireDelay = 0.5f;

    public static float Speed
    {
        get => _speed;
        set => _speed = value;
    }

    public static int Health
    {
        get => _health;
        set => _health = value;
    }

    public static float FireDelay
    {
        get => _fireDelay;
        set => _fireDelay = value;
    }

    public static float MaxFireDelay
    {
        get => _maxFireDelay;
        set => _maxFireDelay = value;
    }

    public static int MaxHealth
    {
        get => _maxHealth;
        set => _maxHealth = value;
    }

    public static float DefaultSpeed
    {
        get => _defaultSpeed;
        set => _defaultSpeed = value;
    }

    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _speed = _defaultSpeed;
    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        float xShoot = Input.GetAxis("ShootHorizontal");
        float yShoot = Input.GetAxis("ShootVertical");

        if ((xShoot != 0 || yShoot != 0) && Time.time > _lastFire + _fireDelay)
        {
            Shoot(xShoot, yShoot, x, y);
            _lastFire = Time.time;
        }

        _rigidbody2D.velocity = new Vector2(x * _speed, y * _speed);
    }

    void Shoot(float xShoot, float yShoot, float xDirection, float yDirection)
    {
        Transform playerTransform = transform;
        GameObject bulletToShoot = bgPoolController.GetPooledObject();
        if (bulletToShoot != null)
        {
            bulletToShoot.transform.position = playerTransform.position;
            bulletToShoot.transform.rotation = playerTransform.rotation;
            bulletToShoot.SetActive(true);

            float auxBulletSpeedX = 1f;
            float auxBulletSpeedY = 1f;
            if ((xShoot < 0 && xDirection < 0) || (xDirection > 0 && xShoot > 0))
            {
                auxBulletSpeedX = 1.4f;
            }

            if ((yShoot < 0 && yDirection < 0) || (yDirection > 0 && yShoot > 0))
            {
                auxBulletSpeedY = 1.4f;
            }

            bulletToShoot.GetComponent<Rigidbody2D>().velocity = new Vector2(
                xShoot < 0
                    ? Mathf.Floor(xShoot) * bulletSpeed * auxBulletSpeedX
                    : Mathf.Ceil(xShoot) * bulletSpeed * auxBulletSpeedX,
                yShoot < 0
                    ? Mathf.Floor(yShoot) * bulletSpeed * auxBulletSpeedY
                    : Mathf.Ceil(yShoot) * bulletSpeed * auxBulletSpeedY
            );
        }
    }
}