﻿using System.Threading.Tasks;
using GbxRemoteNet.Structs;
using GbxRemoteNet.XmlRpc;

namespace GbxRemoteNet;

/// <summary>
///     Method Category: Votes
/// </summary>
public partial class GbxRemoteClient
{
    /// <summary>
    ///     Call a vote for a cmd. The command is a XML string corresponding to an XmlRpc request. Only available to Admin.
    /// </summary>
    /// <param name="cmd"></param>
    /// <returns></returns>
    public async Task<bool> CallVoteAsync(string cmd)
    {
        return (bool) XmlRpcTypes.ToNativeValue<bool>(
            await CallOrFaultAsync("CallVote", cmd)
        );
    }

    /// <summary>
    ///     Extended call vote. Same as CallVote, but you can additionally supply specific parameters for this vote: a ratio, a
    ///     time out and who is voting. Special timeout values: a ratio of '-1' means default; a timeout of '0' means default,
    ///     '1' means indefinite; Voters values: '0' means only active players, '1' means any player, '2' is for everybody,
    ///     pure spectators included. Only available to Admin.
    /// </summary>
    /// <param name="cmd"></param>
    /// <param name="ratio"></param>
    /// <param name="timeout"></param>
    /// <param name="who"></param>
    /// <returns></returns>
    public async Task<bool> CallVoteExAsync(string cmd, double ratio, int timeout, int who)
    {
        return (bool) XmlRpcTypes.ToNativeValue<bool>(
            await CallOrFaultAsync("CallVoteEx", cmd, ratio, timeout, who)
        );
    }

    /// <summary>
    ///     Used internally by game.
    /// </summary>
    /// <returns></returns>
    public async Task<bool> InternalCallVoteAsync()
    {
        return (bool) XmlRpcTypes.ToNativeValue<bool>(
            await CallOrFaultAsync("InternalCallVote")
        );
    }

    /// <summary>
    ///     Cancel the current vote. Only available to Admin.
    /// </summary>
    /// <returns></returns>
    public async Task<bool> CancelVoteVoteAsync()
    {
        return (bool) XmlRpcTypes.ToNativeValue<bool>(
            await CallOrFaultAsync("CancelVoteVote")
        );
    }

    /// <summary>
    ///     Returns the vote currently in progress. The returned structure is { CallerLogin, CmdName, CmdParam }.
    /// </summary>
    /// <returns></returns>
    public async Task<TmCurrentCallVote> GetCurrentCallVoteAsync()
    {
        return (TmCurrentCallVote) XmlRpcTypes.ToNativeValue<TmCurrentCallVote>(
            await CallOrFaultAsync("GetCurrentCallVote")
        );
    }

    /// <summary>
    ///     Set a new timeout for waiting for votes. A zero value disables callvote. Only available to Admin. Requires a map
    ///     restart to be taken into account.
    /// </summary>
    /// <param name="timeout"></param>
    /// <returns></returns>
    public async Task<bool> SetCallVoteTimeOutAsync(int timeout)
    {
        return (bool) XmlRpcTypes.ToNativeValue<bool>(
            await CallOrFaultAsync("SetCallVoteTimeOut", timeout)
        );
    }

    /// <summary>
    ///     Get the current and next timeout for waiting for votes. The struct returned contains two fields 'CurrentValue' and
    ///     'NextValue'.
    /// </summary>
    /// <returns></returns>
    public async Task<TmCurrentNextValue<int>> GetCallVoteTimeOutAsync()
    {
        return (TmCurrentNextValue<int>) XmlRpcTypes.ToNativeValue<TmCurrentNextValue<int>>(
            await CallOrFaultAsync("GetCallVoteTimeOut")
        );
    }

    /// <summary>
    ///     Set a new default ratio for passing a vote. Must lie between 0 and 1. Only available to Admin.
    /// </summary>
    /// <param name="ratio"></param>
    /// <returns></returns>
    public async Task<bool> SetCallVoteRatioAsync(double ratio)
    {
        return (bool) XmlRpcTypes.ToNativeValue<bool>(
            await CallOrFaultAsync("SetCallVoteRatio", ratio)
        );
    }

    /// <summary>
    ///     Get the current default ratio for passing a vote. This value lies between 0 and 1.
    /// </summary>
    /// <param name="ratio"></param>
    /// <returns></returns>
    public async Task<double> GetCallVoteRatioAsync()
    {
        return (double) XmlRpcTypes.ToNativeValue<double>(
            await CallOrFaultAsync("GetCallVoteRatio")
        );
    }

    /// <summary>
    ///     Set the ratios list for passing specific votes. The parameter is an array of structs {string Command, double
    ///     Ratio}, ratio is in [0,1] or -1 for vote disabled. Only available to Admin.
    /// </summary>
    /// <param name="ratio"></param>
    /// <returns></returns>
    public async Task<bool> SetCallVoteRatiosAsync(TmCallVoteRatio[] ratios)
    {
        return (bool) XmlRpcTypes.ToNativeValue<bool>(
            await CallOrFaultAsync("SetCallVoteRatios", ratios)
        );
    }

    /// <summary>
    ///     Get the current ratios for passing votes.
    /// </summary>
    /// <returns></returns>
    public async Task<TmCallVoteRatio[]> GetCallVoteRatiosAsync()
    {
        return (TmCallVoteRatio[]) XmlRpcTypes.ToNativeValue<TmCallVoteRatio>(
            await CallOrFaultAsync("GetCallVoteRatios")
        );
    }
}