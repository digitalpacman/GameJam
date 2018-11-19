using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crazyshooter : MonoBehaviour
{
    private Timer singleShot = new Timer(1f);
    private Timer circleShot = new Timer(5f);
    private Timer explosionShot = new Timer(2f);

    public float singleShotSpeed = 3f;
    public float circleShotSpeed = 1f;
    public float explosionShotSpeed = 1f;

    public bool enableSingleShot = false;
    public bool enableCircleShot = false;
    public bool enableExplosionShot = false;

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
            var r = transform.localScale.x / 2;
            var angle = 0f;
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
