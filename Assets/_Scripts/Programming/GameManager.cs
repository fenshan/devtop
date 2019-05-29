using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Singleton

    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            return instance;
        }
        private set
        {
            instance = value;
        }
    }

    #endregion Singleton

    public Player player;
    public Coroutine execution;
    public bool executing;

    private void Start()
    {
        #region Singleton
        if ((instance != null) && (instance != this)) 
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        #endregion

        player = FindObjectOfType<Player>();
        executing = false;
    }

    public void Play()
    {
        if (!executing) execution = StartCoroutine(Execute());
    }

    public void Stop()
    {
        if (executing)
        {
            StopCoroutine(execution);
            executing = false;
        }

        //Reset position player and items

    }

    public void EraseCommands()
    {
        if (!executing) ListaComandos.EraseAllComands();
    }

    IEnumerator Execute()
    {
        executing = true;
        foreach (CommandTypes c in ListaComandos.ComandosUsed)
        {
            switch (c)
            {
                case CommandTypes.MoveForward: player.Move(1, 0); break;
                case CommandTypes.MoveBackward: player.Move(-1, 0); break;
                case CommandTypes.MoveUp: player.Move(0, 1); break;
                case CommandTypes.MoveDown: player.Move(0, -1); break;
                case CommandTypes.Interact: player.Interact(); break;
            }
            yield return new WaitForSeconds(0.5f);
        }
        executing = false;
        yield return null;
    }

}
