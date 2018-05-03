using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Prototype.NetworkLobby;

public class NetLobbyHook : LobbyHook
{

    public override void OnLobbyServerSceneLoadedForPlayer(NetworkManager mananger,
                                                          GameObject lobbyPlayer,
                                                          GameObject gamePlayer)
    {
        LobbyPlayer lobby = lobbyPlayer.GetComponent<LobbyPlayer>();
        SetupLocalPlayer localPlayer = gamePlayer.GetComponent<SetupLocalPlayer>();

        localPlayer.pname = lobby.playerName;
        localPlayer.playerColor = lobby.playerColor;
    }
}
