using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Uzi : Weapon
{
    [SerializeField] private float _delay;
    [SerializeField] private int _maxShotCount;

    private int _shotCount;
    private Transform _shotPointTemp;

    private void MultiShot()
    {
        Instantiate(Bullet, _shotPointTemp.position, Quaternion.identity);
        _shotCount++;

        if (_shotCount != _maxShotCount)
            Invoke("MultiShot", _delay);
    }

    public override void Shot(Transform shotPoint)
    {
        _shotCount = 0;
        _shotPointTemp = shotPoint;

        Instantiate(Bullet, shotPoint.position, Quaternion.identity);
        _shotCount++;

        Invoke("MultiShot", _delay);
    }
}
