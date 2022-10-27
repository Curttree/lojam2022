using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Subject
{
    List<IObserver> observers = new List<IObserver>();
    public void AddObserver(ref IObserver ob)
    {
        observers.Add(ob);
    }
    public void RemoveObserver(ref IObserver ob)
    {
        observers.Remove(ob);
    }
    public void Notify(eEvent triggeredEvent)
    {
        foreach(IObserver observer in observers)
        {
            observer.onNotify(triggeredEvent);
        }
    }
}
