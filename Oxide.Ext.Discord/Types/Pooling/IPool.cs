namespace Oxide.Ext.Discord.Types.Pooling
{
    /// <summary>
    /// Represents a pool
    /// </summary>
    public interface IPool
    {
        /// <summary>
        /// Called on a pool when a plugin is unloaded
        /// </summary>
        /// <param name="pluginPool"></param>
        void OnPluginUnloaded(DiscordPluginPool pluginPool);

        /// <summary>
        /// Clears the pool of all items
        /// </summary>
        void ClearPoolEntities();

        /// <summary>
        /// Wipes all pools of the given type
        /// </summary>
        void RemoveAllPools();
    }
}