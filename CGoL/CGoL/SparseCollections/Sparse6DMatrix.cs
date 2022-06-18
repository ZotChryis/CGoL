//=======================================================================
// Copyright (C) 2010-2013 William Hallahan
//
// Permission is hereby granted, free of charge, to any person
// obtaining a copy of this software and associated documentation
// files (the "Software"), to deal in the Software without restriction,
// including without limitation the rights to use, copy, modify, merge,
// publish, distribute, sublicense, and/or sell copies of the Software,
// and to permit persons to whom the Software is furnished to do so,
// subject to the following conditions:
//
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
// OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
// HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
// WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
// OTHER DEALINGS IN THE SOFTWARE.
//=======================================================================

﻿//======================================================================
// Generic Class: Sparse6DMatrix
// Author: Bill Hallahan
// Date: April 12, 2010
//======================================================================

using System;
using System.Collections.Generic;

namespace SparseCollections
{
    /// <summary>
    /// This class implements a sparse 6 dimensional matrix.
    /// </summary>
    /// <typeparam name="TKey0">The first key type used to index the array items</typeparam>
    /// <typeparam name="TKey1">The second key type used to index the array items</typeparam>
    /// <typeparam name="TKey2">The third key type used to index the array items</typeparam>
    /// <typeparam name="TKey3">The fourth key type used to index the array items</typeparam>
    /// <typeparam name="TKey4">The fifth key type used to index the array items</typeparam>
    /// <typeparam name="TKey5">The sixth key type used to index the array items</typeparam>
    /// <typeparam name="TValue">The type of the array values</typeparam>
    [Serializable]
    public class Sparse6DMatrix<TKey0, TKey1, TKey2, TKey3, TKey4, TKey5, TValue> : IEnumerable<KeyValuePair<ComparableTuple6<TKey0, TKey1, TKey2, TKey3, TKey4, TKey5>, TValue>>
        where TKey0 : IComparable<TKey0>
        where TKey1 : IComparable<TKey1>
        where TKey2 : IComparable<TKey2>
        where TKey3 : IComparable<TKey3>
        where TKey4 : IComparable<TKey4>
        where TKey5 : IComparable<TKey5>
    {
        private Dictionary<ComparableTuple6<TKey0, TKey1, TKey2, TKey3, TKey4, TKey5>, TValue> m_dictionary;

        /// <summary>
        /// This property stores the default value that is returned if the keys don't exist in the array.
        /// </summary>
        public TValue DefaultValue
        {
            get;
            set;
        }

        /// <summary>
        /// Property to get the count of items in the sparse array.
        /// </summary>
        public int Count
        {
            get
            {
                return m_dictionary.Count;
            }
        }

        #region Constructors
        /// <summary>
        /// Constructor - creates an empty sparse array instance.
        /// </summary>
        public Sparse6DMatrix()
        {
            InitializeDictionary();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="defaultValue">A default value to return if the key is not present.</param>
        public Sparse6DMatrix(TValue defaultValue)
        {
            InitializeDictionary();
            DefaultValue = defaultValue;
        }

        /// <summary>
        /// Copy constructor.
        /// </summary>
        /// <param name="sparse6DMatrix">The sparse array instance to be copied</param>
        public Sparse6DMatrix(Sparse6DMatrix<TKey0, TKey1, TKey2, TKey3, TKey4, TKey5, TValue> sparse6DMatrix)
        {
            InitializeDictionary();
            Initialize(sparse6DMatrix);
            DefaultValue = sparse6DMatrix.DefaultValue;
        }

        #endregion

        /// <summary>
        /// Initialize the dictionary to compare items based on key values.
        /// </summary>
        private void InitializeDictionary()
        {
            ComparableTuple6EqualityComparer<TKey0, TKey1, TKey2, TKey3, TKey4, TKey5> equalityComparer = new ComparableTuple6EqualityComparer<TKey0, TKey1, TKey2, TKey3, TKey4, TKey5>();
            m_dictionary = new Dictionary<ComparableTuple6<TKey0, TKey1, TKey2, TKey3, TKey4, TKey5>, TValue>(equalityComparer);
        }

        /// <summary>
        /// Method to copy the data in another Sparse6DMatrix instance to this instance.
        /// </summary>
        /// <param name="sparse6DMatrix">An instance of the Sparse6DMatrix class.</param>
        private void Initialize(Sparse6DMatrix<TKey0, TKey1, TKey2, TKey3, TKey4, TKey5, TValue> sparse6DMatrix)
        {
            m_dictionary.Clear();

            // Copy each key value pair to the dictionary.
            foreach (KeyValuePair<ComparableTuple6<TKey0, TKey1, TKey2, TKey3, TKey4, TKey5>, TValue> pair in sparse6DMatrix)
            {
                ComparableTuple6<TKey0, TKey1, TKey2, TKey3, TKey4, TKey5> newCombinedKey = new ComparableTuple6<TKey0, TKey1, TKey2, TKey3, TKey4, TKey5>(pair.Key);
                m_dictionary.Add(newCombinedKey, pair.Value);
            }
        }

        /// <summary>
        /// Method to copy the data in this Sparse6DMatrix instance to another instance.
        /// </summary>
        /// <param name="sparse6DMatrix">An instance of the Sparse6DMatrix class.</param>
        public void CopyTo(Sparse6DMatrix<TKey0, TKey1, TKey2, TKey3, TKey4, TKey5, TValue> sparse6DMatrix)
        {
            sparse6DMatrix.m_dictionary.Clear();

            // Copy each key value pair to the dictionary.
            foreach (KeyValuePair<ComparableTuple6<TKey0, TKey1, TKey2, TKey3, TKey4, TKey5>, TValue> pair in m_dictionary)
            {
                ComparableTuple6<TKey0, TKey1, TKey2, TKey3, TKey4, TKey5> newCombinedKey = new ComparableTuple6<TKey0, TKey1, TKey2, TKey3, TKey4, TKey5>(pair.Key);
                sparse6DMatrix.m_dictionary.Add(newCombinedKey, pair.Value);
            }
        }

        /// <summary>
        /// Property []
        /// </summary>
        /// <param name="key0">The first key used to index the value</param>
        /// <param name="key1">The second key used to index the value</param>
        /// <param name="key2">The third key used to index the value</param>
        /// <param name="key3">The fourth key used to index the value</param>
        /// <param name="key4">The fifth key used to index the value</param>
        /// <param name="key5">The sixth key used to index the value</param>
        /// <returns>The 'get' property returns the value at the current key</returns>
        public TValue this[TKey0 key0, TKey1 key1, TKey2 key2, TKey3 key3, TKey4 key4, TKey5 key5]
        {
            get
            {
                TValue value;

                if (!m_dictionary.TryGetValue(CombineKeys(key0, key1, key2, key3, key4, key5), out value))
                {
                    value = DefaultValue;
                }

                return value;
            }

            set
            {
                m_dictionary[CombineKeys(key0, key1, key2, key3, key4, key5)] = value;
            }
        }
        /// <summary>
        /// Determines whether this matrix contains the specified keys.
        /// </summary>
        /// <param name="key0">The first key used to index the value</param>
        /// <param name="key1">The second key used to index the value</param>
        /// <param name="key2">The third key used to index the value</param>
        /// <param name="key3">The fourth key used to index the value</param>
        /// <param name="key4">The fifth key used to index the value</param>
        /// <param name="key5">The sixth key used to index the value</param>
        /// <returns>Returns the value 'true' if and only if the keys exists in this matrix</returns>
        public bool ContainsKey(TKey0 key0, TKey1 key1, TKey2 key2, TKey3 key3, TKey4 key4, TKey5 key5)
        {
            return m_dictionary.ContainsKey(CombineKeys(key0, key1, key2, key3, key4, key5));
        }

        /// <summary>
        /// Determines whether this matrix contains the specified value.
        /// </summary>
        /// <param name="value">A value</param>
        /// <returns>Returns the value 'true' if and only if the value exists in this matrix</returns>
        public bool ContainsValue(TValue value)
        {
            return m_dictionary.ContainsValue(value);
        }

        /// <summary>
        /// Gets the value for the associated keys.
        /// </summary>
        /// <param name="key0">The first key used to index the value</param>
        /// <param name="key1">The second key used to index the value</param>
        /// <param name="key2">The third key used to index the value</param>
        /// <param name="key3">The fourth key used to index the value</param>
        /// <param name="key4">The fifth key used to index the value</param>
        /// <param name="key5">The sixth key used to index the value</param>
        /// <param name="value">An out parameter that contains the value if the key exists</param>
        /// <returns>Returns the value 'true' if and only if the key exists in this matrix</returns>
        public bool TryGetValue(TKey0 key0, TKey1 key1, TKey2 key2, TKey3 key3, TKey4 key4, TKey5 key5, out TValue value)
        {
            return m_dictionary.TryGetValue(CombineKeys(key0, key1, key2, key3, key4, key5), out value);
        }

        /// <summary>
        /// Removes the value with the specified key from this sparse matrix instance.
        /// </summary>
        /// <param name="key0">The first key of the element to remove</param>
        /// <param name="key1">The second key of the element to remove</param>
        /// <param name="key2">The third key used to index the value</param>
        /// <param name="key3">The fourth key used to index the value</param>
        /// <param name="key4">The fifth key used to index the value</param>
        /// <param name="key5">The sixth key used to index the value</param>
        /// <returns>The value 'true' if and only if the element is successfully found and removed.</returns>
        public bool Remove(TKey0 key0, TKey1 key1, TKey2 key2, TKey3 key3, TKey4 key4, TKey5 key5)
        {
            return m_dictionary.Remove(CombineKeys(key0, key1, key2, key3, key4, key5));
        }

        /// <summary>
        /// Method to clear all values in the sparse array.
        /// </summary>
        public void Clear()
        {
            m_dictionary.Clear();
        }

        /// <summary>
        /// This method must be overridden by the caller to combine the keys.
        /// </summary>
        /// <param name="key0">The first key</param>
        /// <param name="key1">The second key</param>
        /// <param name="key2">The third key</param>
        /// <param name="key3">The fourth key</param>
        /// <param name="key4">The fifth key</param>
        /// <param name="key5">The sixth key</param>
        /// <returns>A value that combines the keys in a unique fashion</returns>
        public ComparableTuple6<TKey0, TKey1, TKey2, TKey3, TKey4, TKey5> CombineKeys(TKey0 key0, TKey1 key1, TKey2 key2, TKey3 key3, TKey4 key4, TKey5 key5)
        {
            return new ComparableTuple6<TKey0, TKey1, TKey2, TKey3, TKey4, TKey5>(key0, key1, key2, key3, key4, key5);
        }

        /// <summary>
        /// This method must be overridden by the caller to separate a combined key into the two original keys.
        /// </summary>
        /// <param name="combinedKey">A value that combines the keys in a unique fashion</param>
        /// <param name="key0">A reference to the first key</param>
        /// <param name="key1">A reference to the second key</param>
        /// <param name="key2">A reference to the third key</param>
        /// <param name="key3">A reference to the fourth key</param>
        /// <param name="key4">A reference to the fifth key</param>
        /// <param name="key5">A reference to the sixth key</param>
        public void SeparateCombinedKeys(ComparableTuple6<TKey0, TKey1, TKey2, TKey3, TKey4, TKey5> combinedKey,
                                         ref TKey0 key0,
                                         ref TKey1 key1,
                                         ref TKey2 key2,
                                         ref TKey3 key3,
                                         ref TKey4 key4,
                                         ref TKey5 key5)
        {
            key0 = combinedKey.Item0;
            key1 = combinedKey.Item1;
            key2 = combinedKey.Item2;
            key3 = combinedKey.Item3;
            key4 = combinedKey.Item4;
            key5 = combinedKey.Item5;
        }

        #region IEnumerable<KeyValuePair<ComparableTuple6<TKey0, TKey1, TKey2, TKey3, TKey4, TKey5>, TValue>> Members

        /// <summary>
        /// The Generic IEnumerator<> GetEnumerator method
        /// </summary>
        /// <returns>An enumerator to iterate over all key-value pairs in this sparse array</returns>
        public IEnumerator<KeyValuePair<ComparableTuple6<TKey0, TKey1, TKey2, TKey3, TKey4, TKey5>, TValue>> GetEnumerator()
        {
            return this.m_dictionary.GetEnumerator();
        }

        #endregion

        #region IEnumerable Members

        /// <summary>
        /// The non-generic IEnumerator<> GetEnumerator method
        /// </summary>
        /// <returns>An enumerator to iterate over all key-value pairs in this sparse array</returns>
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.m_dictionary.GetEnumerator();
        }

        #endregion
    }
}
