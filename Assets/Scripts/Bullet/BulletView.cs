using UnityEngine;

public class BulletView : MonoBehaviour
{
    private BulletController BulletController { get; set; }

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
        BulletController.Fly();
    }
    private void OnCollisionEnter(Collision collision)
    {
        //explode
        if(collision.gameObject.GetComponent<TankView>() == null)
        {
            BulletModel model = BulletController.GetBulletModel();
            GameObject explosion = Instantiate(model.explosionType, gameObject.transform.position, gameObject.transform.rotation);
            Destroy(gameObject);
            Destroy(explosion, 1.5f);
        }
    }
}
