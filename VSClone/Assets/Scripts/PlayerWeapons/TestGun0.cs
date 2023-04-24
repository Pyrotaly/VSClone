using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestGun0 : Gun
{
    protected override void OnGunReload()
    {
        //Add gun reload effect here
        AudioManager.Instance.PlaySFX("Reload");
    }

    protected override void OnGunShot()
    {
        AudioManager.Instance.PlaySFX("PistolShot");
    }
}
