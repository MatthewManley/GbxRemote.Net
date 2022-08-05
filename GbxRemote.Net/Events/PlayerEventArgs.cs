﻿using System;

namespace GbxRemoteNet.Events;

public class PlayerEventArgs : EventArgs
{
    /// <summary>
    /// Login name/id of the player.
    /// </summary>
    public string Login { get; set; }
}