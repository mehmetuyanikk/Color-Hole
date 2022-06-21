using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DestroyCollider : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {

        if (!Game.isGameOver)
        {
            if (other.gameObject.CompareTag("article"))
            {
                Level.Instance._objectsInScene--;
                UIManager.Instance.UpdateLevelProgress();

                Magnet.Instance.RemoveFromMagnetField(other.attachedRigidbody);

                Destroy(other.gameObject);

                if (Level.Instance._objectsInScene == 0)
                {

                    UIManager.Instance.ShowLevelCompleted();

                    Invoke("NextLevel", 2f);

                }

            }

            if (other.gameObject.CompareTag("obsticle"))
            {
                Game.isGameOver = true;
                Level.Instance.RestartLevel();
            }
        }
    }

    void NextLevel()
    {
        Level.Instance.LoadNextLevel();
    }

}
