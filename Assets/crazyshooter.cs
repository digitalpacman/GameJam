using System.Collections;
using UnityEngine;

public class crazyshooter : MonoBehaviour
{
    private Timer singleShot = new Timer(1f);
    private Timer circleShot = new Timer(1f);
    private Timer explosionShot = new Timer(1f);
    private Timer slam = new Timer(1f);
    private float circleOffset = 0;

    public float singleShotSpeed = 3f;
    public float circleShotSpeed = 1f;
    public float explosionShotSpeed = 1f;
    public float slamSpeed = 1f;

    public bool enableSingleShot = false;
    public bool enableCircleShot = false;
    public bool enableExplosionShot = false;
    public bool enableSlam = false;

    public GameObject bullet;
    public GameObject player;
    public float bulletsPerCircle = 10;
    public float bulletsPerExplosion = 10;


    // Update is called once per frame
    void Update()
    {
        if (singleShot.IsReady(Time.deltaTime) && enableSingleShot)
        {
            var newBullet = Instantiate(bullet);
            newBullet.transform.position = transform.position;
            var trajectory = player.transform.position - transform.position;
            newBullet.GetComponent<Rigidbody2D>().velocity = trajectory.normalized * singleShotSpeed;
        }

        if (circleShot.IsReady(Time.deltaTime) && enableCircleShot)
        {
            var distance = 2 * Mathf.PI / bulletsPerCircle;
            var r = transform.localScale.x / 1.5f;
            var angle = circleOffset;
            for (var i = 0; i < bulletsPerCircle; i++)
            {
                var x = transform.position.x + r * Mathf.Cos(angle);
                var y = transform.position.y + r * Mathf.Sin(angle);
                angle += distance;
                var newBullet = Instantiate(bullet);
                newBullet.transform.position = new Vector3(x, y, 0);
                var trajectory = (newBullet.transform.position - transform.position).normalized * circleShotSpeed;
                newBullet.GetComponent<Rigidbody2D>().velocity = trajectory;
            }

            circleOffset += distance / 2;
        }

        if (explosionShot.IsReady(Time.deltaTime) && enableExplosionShot)
        {
            var newBullet = Instantiate(bullet);
            newBullet.transform.position = transform.position;
            var trajectory = player.transform.position - transform.position;
            newBullet.GetComponent<Rigidbody2D>().velocity = trajectory.normalized * explosionShotSpeed;
            var exploder = newBullet.AddComponent<DestinationExploder>();
            exploder.bullet = bullet;
            exploder.destination = player.transform.position;
            exploder.explosionBullets = bulletsPerExplosion;
        }
    }

    private void FixedUpdate()
    {
        if (enableSlam)
        {
            var rayCasts = Physics2D.BoxCastAll(transform.position, new Vector2(4, 4), 0, new Vector2(0, 0));
            for (var i = 0; i < rayCasts.Length; i++)
            {
                if (rayCasts[i].transform.gameObject.tag == "Player")
                {
                    Debug.Log("Player damaged");
                    //var velocity = (Vector2)(rayCasts[i].transform.position - transform.position).normalized * 10f;
                    //rayCasts[i].rigidbody.velocity += velocity;
                    enableSlam = false;
                    break;
                }
            }
        }
    }
}

public class Timer
{
    private float _elapsed;
    private float _trigger;

    public Timer(float trigger)
    {
        _trigger = trigger;
    }

    public bool IsReady(float deltaTime)
    {
        _elapsed += deltaTime;
        if (_elapsed >= _trigger)
        {
            _elapsed = 0;
            return true;
        }
        return false;
    }
}