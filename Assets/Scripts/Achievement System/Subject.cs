using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/* Subject class for Observer Pattern */

public abstract class Subject : MonoBehaviour
{
    public List<IObservers> _observers = new List<IObservers>();

    public void AddObserver(IObservers observer)
    {
        _observers.Add(observer);
    }
    public void RemoveObserver(IObservers observer)
    {
        _observers.Remove(observer);
    }
    public void NotifyBulletObservers()
    {
        _observers.ForEach((observer) => { observer.OnNotifyBullets(); });
    }
    public void NotifyEnemyObservers()
    {
        _observers.ForEach((observer) => { observer.OnNotifyEnemy(); });
    }
    public void NotifyDistanceTravelled(float _distance, out bool _stopRunning)
    {
        _stopRunning = _observers.First().OnNotifyDistanceTravelled(_distance);
    }
}
