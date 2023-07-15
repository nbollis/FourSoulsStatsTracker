﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourSoulsDataConnection
{
    public static class ClassExtensions
    {
        /// <summary>
        /// Create new <see cref="ObservableCollection{T}"/> from <see cref="IEnumerable{T}"/>
        /// </summary>
        public static ObservableCollection<T> ToObservableCollection<T>(this IEnumerable<T> collection)
        {
            return new ObservableCollection<T>(collection);
        }
    }
}
