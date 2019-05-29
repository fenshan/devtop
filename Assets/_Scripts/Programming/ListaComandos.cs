using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum CommandTypes { MoveForward, MoveBackward, MoveUp, MoveDown, Interact }

public class ListaComandos : MonoBehaviour
{
    public static List<CommandTypes> ComandosUsed;
    public static List<GameObject> ComandosUI;

    public GameObject parentUI;
    public GameObject prefab;
    public Sprite[] sprites;

    public void Start()
    {
        ComandosUsed = new List<CommandTypes>();
        ComandosUI = new List<GameObject>();
    }

    public void NewCommand(int type)
    {
        if (!GameManager.Instance.executing)
        {
            //Lista interna
            ComandosUsed.Add((CommandTypes)type);

            //UI
            GameObject aux = Instantiate(prefab);
            int i = ComandosUI.Count;

            /*Parameters button*/
            aux.name = i.ToString();
            aux.transform.SetParent(parentUI.transform, false);
            aux.GetComponent<Button>().onClick.AddListener(delegate { EraseCommand(aux); });
            aux.GetComponent<Comando>().type = (CommandTypes)type;
            aux.GetComponent<Image>().sprite = sprites[type];

            ComandosUI.Add(aux);
        }
    }

    public static void EraseCommand(GameObject aux)
    {
        if (!GameManager.Instance.executing)
        {
            int pos = ComandosUI.FindIndex(x => (x == aux));

            //UI
            Destroy(ComandosUI[pos]);
            ComandosUI.RemoveAt(pos);

            //Lista interna
            ComandosUsed.RemoveAt(pos);
        }
    }

    public static void EraseAllComands()
    {
        if (!GameManager.Instance.executing)
        {
            for (int i = 0; i < ComandosUsed.Count; ++i)
            {
                Destroy(ComandosUI[i]);
            }

            ComandosUsed = new List<CommandTypes>();
            ComandosUI = new List<GameObject>();
        }
    }


}
