using UnityEngine;
using UnityEditor;

public class bulletAbilities : Ability
{
    private WeaponController gameController;
    public GameObject procetile;
    public int[] bulletSpawnQueue;

    public int level_One;

    public override void Initialize(GameObject obj)
    {
        throw new System.NotImplementedException();
    }

    public override void TriggerAbility()
    {
        throw new System.NotImplementedException();
    }
    public void levelOne(int[] spawnQueue, GameObject projectile)
    {
        // if 3 spawn Queues
        // 3 bullets will queue to spawn by the checker
    }
}

/* Based on score for the Fun Time gamemode. 
 * (0 score) First level, single shot, add bullet damage 10, every x points
 * Second level, two bullets, 
 * [1, 2, 3]
*/
