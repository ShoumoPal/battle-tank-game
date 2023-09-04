using System;
using System.Collections;
using UnityEditor.Timeline.Actions;
using UnityEngine;

public class BulletView : MonoBehaviour
{
    private BulletController BulletController { get; set; }
    private BulletPool BulletPool { get; set; }

    public void SetBulletController(BulletController bulletController)
    {
        BulletController = bulletController;
    }
    public Rigidbody GetRigidbody()
    {
        return GetComponent<Rigidbody>();
    }
    private void Start()
    {
        BulletPool = TankSpawner.Instance.Player.TankView.GetBulletSpawner().GetComponent<BulletPool>();
        BulletController.Fly();
        StartCoroutine(DestroyBulletAfterSeconds());
    }
    private IEnumerator DestroyBulletAfterSeconds()
    {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }
    private void Explode()
    {
        BulletModel model = BulletController.GetBulletModel();
        GameObject explosion = Instantiate(model.explosionType, gameObject.transform.position, gameObject.transform.rotation);

        if (gameObject != null)
            BulletController.GetBulletModel().explosionSource.PlayOneShot(BulletController.GetBulletModel().explosionClip);

        Destroy(explosion, 1.5f);
        Disable();
        BulletPool.ReturnItem(BulletController);
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collided with: " + collision.gameObject.name);
        if (collision.gameObject.GetComponent<TankView>())
        {
            IDamagable damagable = collision.gameObject.GetComponent<IDamagable>();
            //Tank takes damage
            damagable.TakeDamage(20);
        }
        else if (!collision.gameObject.GetComponent<BulletSpawner>())
        {
            Explode();
        }
    }

    public void Enable()
    {
        gameObject.SetActive(true);
    }

    internal void Disable()
    {
        gameObject.SetActive(false);
    }

    internal void SetParent(Transform parent)
    {
        gameObject.transform.SetParent(parent);
    }

    internal void SetTransform(Transform transform)
    {
        gameObject.transform.position = transform.position;
        gameObject.transform.localRotation = Quaternion.Euler(transform.forward);
    }
}
