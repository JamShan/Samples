//
//  This file was auto-generated using the ChilliConnect SDK Generator.
//
//  The MIT License (MIT)
//
//  Copyright (c) 2015 Tag Games Ltd
//
//  Permission is hereby granted, free of charge, to any person obtaining a copy
//  of this software and associated documentation files (the "Software"), to deal
//  in the Software without restriction, including without limitation the rights
//  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//  copies of the Software, and to permit persons to whom the Software is
//  furnished to do so, subject to the following conditions:
//
//  The above copyright notice and this permission notice shall be included in
//  all copies or substantial portions of the Software.
//
//  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
//  THE SOFTWARE.
//

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using SdkCore;

namespace ChilliConnect 
{
	/// <summary>
	/// <para>A container that can be used to describe items and currencies being sent from one
	/// player to another.</para>
	///
	/// <para>This is immutable after construction and is therefore thread safe.</para>
	/// </summary>
	public sealed class MessageTransfer
	{
		/// <summary>
		/// A list of Currencies.
		/// </summary>
        public ReadOnlyCollection<MessageSendCurrency> Currencies { get; private set; }
	
		/// <summary>
		/// A list of Inventory ItemIDs.
		/// </summary>
        public ReadOnlyCollection<string> ItemIDs { get; private set; }

		/// <summary>
		/// Initialises a new instance with the given properties.
		/// </summary>
		///
		/// <param name="currencies">A list of Currencies.</param>
		/// <param name="itemIDs">A list of Inventory ItemIDs.</param>
		public MessageTransfer(IList<MessageSendCurrency> currencies, IList<string> itemIDs)
		{
			ReleaseAssert.IsNotNull(currencies, "Currencies cannot be null.");
			ReleaseAssert.IsNotNull(itemIDs, "Item I Ds cannot be null.");
	
            Currencies = Mutability.ToImmutable(currencies);
            ItemIDs = Mutability.ToImmutable(itemIDs);
		}
		
		/// <summary>
		/// Initialises a new instance from the given Json dictionary.
		/// </summary>
		///
		/// <param name="jsonDictionary">The dictionary containing the Json data.</param>
		public MessageTransfer(IDictionary<string, object> jsonDictionary)
		{
			ReleaseAssert.IsNotNull(jsonDictionary, "JSON dictionary cannot be null.");
			ReleaseAssert.IsTrue(jsonDictionary.ContainsKey("Currencies"), "Json is missing required field 'Currencies'");
			ReleaseAssert.IsTrue(jsonDictionary.ContainsKey("ItemIDs"), "Json is missing required field 'ItemIDs'");
	
			foreach (KeyValuePair<string, object> entry in jsonDictionary)
			{
				// Currencies
				if (entry.Key == "Currencies")
				{
                    ReleaseAssert.IsTrue(entry.Value is IList<object>, "Invalid serialised type.");
                    Currencies = JsonSerialisation.DeserialiseList((IList<object>)entry.Value, (object element) =>
                    {
                        ReleaseAssert.IsTrue(element is IDictionary<string, object>, "Invalid element type.");
                        return new MessageSendCurrency((IDictionary<string, object>)element);	
                    });
				}
		
				// Item I Ds
				else if (entry.Key == "ItemIDs")
				{
                    ReleaseAssert.IsTrue(entry.Value is IList<object>, "Invalid serialised type.");
                    ItemIDs = JsonSerialisation.DeserialiseList((IList<object>)entry.Value, (object element) =>
                    {
                        ReleaseAssert.IsTrue(element is string, "Invalid element type.");
                        return (string)element;
                    });
				}
	
				// An error has occurred.
				else
				{
#if DEBUG
					throw new ArgumentException("Input Json contains an invalid field.");
#endif
				}
			}
		}

		/// <summary>
		/// Serialises all properties. The output will be a dictionary containing the
		/// objects properties in a form that can easily be converted to Json. 
		/// </summary>
		///
		/// <returns>The serialised object in dictionary form.</returns>
		public IDictionary<string, object> Serialise()
		{
            var dictionary = new Dictionary<string, object>();
			
			// Currencies
            var serialisedCurrencies = JsonSerialisation.Serialise(Currencies, (MessageSendCurrency element) =>
            {
                return element.Serialise();
            });
            dictionary.Add("Currencies", serialisedCurrencies);
			
			// Item I Ds
            var serialisedItemIDs = JsonSerialisation.Serialise(ItemIDs, (string element) =>
            {
                return element;
            });
            dictionary.Add("ItemIDs", serialisedItemIDs);
			
			return dictionary;
		}
	}
}
