﻿using System;
using System.Collections.Generic;
using System.Reflection;
using Oxide.Ext.Discord.Attributes;

namespace Oxide.Ext.Discord.Plugins.Setup
{
    internal struct PluginField
    {
        public readonly MemberInfo Member;
        private readonly List<Attribute> _attributes;

        public PluginField(MemberInfo member)
        {
            Member = member;
            _attributes = new List<Attribute>(0);
            Attribute[] attributes = Attribute.GetCustomAttributes(member);
            for (int index = 0; index < attributes.Length; index++)
            {
                Attribute attribute = attributes[index];
                if (attribute is BaseDiscordAttribute)
                {
                    _attributes.Add(attribute);
                }
            }
        }
        
        public T GetAttribute<T>() where T : Attribute
        {
            for (int index = 0; index < _attributes.Count; index++)
            {
                Attribute attribute = _attributes[index];
                if (attribute is T tAttribute)
                {
                    return tAttribute;
                }
            }

            return default(T);
        }
    }
}