//budu se snazit napsat neco co bude mit smysl

using TMPro;
using UnityEngine;







public class npc_script : MonoBehaviour
{
    //naucil jsem se podle nejakyho tutorialu delat cool organizaci
    //takze tady mam headery a serializefieldy a tak
    //tady si deklaruju vsechny promenne co budu potrebovat
    [Header("Interaction")]
    [SerializeField] private KeyCode interactKey = KeyCode.E;
    [SerializeField] private string playerTag = "Player";

    [Header("Dialogue UI")]
    [SerializeField] private GameObject dialogueBubble;
    [SerializeField] private TMP_Text dialogueText;
    [TextArea(2, 5)]
    [SerializeField] private string npcMessage = "Wsp baby girl";
    private bool playerInZone;


    // wow crazy start methoda
    void Start()
    {
        {

                dialogueBubble.SetActive(false);

        }
    }

    // Update je uz zajimavejsi, protoze tady se bude kontrolovat jestli je hrac v zone a podle toho se bude zobrazovat text
    // slovo update mi pripomina to ze bych si mohl updatenout windows na 11-cky ale co
    private void Update()
    {
        if (playerInZone)
        {
            dialogueBubble.SetActive(true);
            dialogueText.text = npcMessage;

        }
        else
        {
            dialogueBubble.SetActive(false);
            dialogueText.text = "";
        }
    }



    //tyhle dve funkce kontrolujou, jestli je hrac v zone nebo ne a podle toho se nastavuje promenna playerInZone
    // a podle toho se pak v update zobrazuje text nebo ne
    // also ted mi doslo ze si davam jmena funkci a promennych anglicky ale pisu komentare cesky, to urcite nebude problem pak >:3
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(playerTag))
        {
            playerInZone = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag(playerTag))
        {
            playerInZone = false;

        }
    }
}
