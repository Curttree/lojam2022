using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IObserver
{
    void onNotify(eEvent triggeredEvent);
}
