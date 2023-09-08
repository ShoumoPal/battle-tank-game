using System.Collections.Generic;
using UnityEngine;

/* Subject class for Observer Pattern */

public abstract class Subject : MonoBehaviour
{
    private List<IObservers> _observers = new List<IObservers>();

    public void AddObserver(IObservers observer)
    {
        _observers.Add(observer);
    }
    public void RemoveObserver(IObservers observer)
    {
        _observers.Remove(observer);
    }
    protected void NotifyObservers()
    {
        _observers.ForEach((observer) => { observer.OnNotify(); });
    }
}
