#pragma warning disable CS8600 // Possible null value conversion
#pragma warning disable CA1416 // Windows-only API

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace NotificationBanner.Framework.Factory
{
    /// <summary>
    /// Used to build factory based on Enums
    /// </summary>
    /// <typeparam name="TEnum">The Enum defining the type</typeparam>
    /// <typeparam name="TImplementation">The implementation of the enum</typeparam>
    public abstract class AbstractFactory<TEnum, TImplementation> where TImplementation : IEnumImpl<TEnum>
        where TEnum : System.Enum, IConvertible
    {
        protected AbstractFactory(IEnumImplList<TEnum, TImplementation> enumImplList)
        {
            AllImplementations = enumImplList.ToReadOnlyDictionary();
        }

        public IReadOnlyDictionary<TEnum, TImplementation> AllImplementations { get; }

        /// <summary>
        /// Get the implementation for the given Enum
        /// </summary>
        /// <param name="eEnum"></param>
        /// <returns></returns>
        public TImplementation Get(TEnum eEnum)
        {
            TImplementation value;
            if (!DataSource().TryGetValue(eEnum, out value))
            {
                throw new InvalidEnumArgumentException();
            }
            return value!;
        }

        protected virtual IReadOnlyDictionary<TEnum, TImplementation> DataSource()
        {
            return AllImplementations;
        }

        /// <summary>
        /// Configure the list control DataSource, ValueMember and DisplayMember
        /// </summary>
        /// <param name="list"></param>
        public void ConfigureListControl(ListControl list)
        {
            list.DataSource =
                DataSource().Values.Select(
                    implementation => new DisplayEnumObject<TEnum>(implementation))
                    .ToArray();
            list.ValueMember = nameof(DisplayEnumObject<TEnum>.Enum);
            list.DisplayMember = nameof(DisplayEnumObject<TEnum>.Display);
        }
    }
}