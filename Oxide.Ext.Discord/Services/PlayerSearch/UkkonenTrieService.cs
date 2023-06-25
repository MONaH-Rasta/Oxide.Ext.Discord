﻿using System.Collections.Generic;
using Oxide.Core;
using Oxide.Core.Libraries.Covalence;
using Oxide.Ext.Discord.Trie;

namespace Oxide.Ext.Discord.Services.PlayerSearch
{
    internal class UkkonenTrieService : IPlayerSearchService
    {
        private readonly UkkonenTrie<IPlayer> _online = new UkkonenTrie<IPlayer>(PlayerEquals);
        private readonly UkkonenTrie<IPlayer> _all = new UkkonenTrie<IPlayer>(PlayerEquals);

        internal UkkonenTrieService()
        {
            Covalence covalence = Interface.Oxide.GetLibrary<Covalence>();
            foreach (IPlayer player in covalence.Players.All)
            {
                _all.Add(player.Name, player);
            }
            
            foreach (IPlayer player in covalence.Players.Connected)
            {
                _all.Add(player.Name, player);
            }
        }

        public IEnumerable<IPlayer> GetOnlinePlayers(string name) => _online.Search(name);

        public IEnumerable<IPlayer> GetAllPlayers(string name) => _all.Search(name);

        public void OnUserConnected(IPlayer player) => _online.Add(player.Name, player);

        public void OnUserDisconnected(IPlayer player) => _online.Remove(player.Name, player);

        public void OnUserNameUpdated(IPlayer player, string oldName, string newName)
        {
            _all.Remove(oldName, player);
            _all.Add(newName, player);
        }
        
        private static bool PlayerEquals(IPlayer left, IPlayer right) => left.Id == right.Id;
    }
}