/* Observers for the Observer Pattern */

public interface IObservers
{
    public void OnNotifyBullets();
    public void OnNotifyEnemy();
    public bool OnNotifyDistanceTravelled(float _distance);
}
