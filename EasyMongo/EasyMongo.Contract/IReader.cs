﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Runtime.InteropServices;

namespace EasyMongo.Contract
{
    public interface IReader
    {
        /// <summary>
        /// Synchronously searches against a MongoDB collection
        /// </summary>
        /// <remarks>Proxy method to private implementation method CollectionDateRangeRead</remarks>
        /// <param name="collectionName">The MongoDB Collection to be read from</param>
        /// <param name="dateTimeFieldName">The name of the field (property) of the persisted object associated with a DateTime object</param>
        /// <param name="start">The time at which search should begin</param>
        /// <param name="end">The time at which search should end</param>
        /// <returns>IEnumerable of read results from the MongoDB</returns>
        IEnumerable<T> Read<T>(string collectionName, string dateTimeFieldName, DateTime start, DateTime end);
        /// <summary>
        /// Synchronously searches against a MongoDB collection
        /// </summary>
        /// <remarks>Proxy method to private implementation method CollectionDateRangePropertyRead</remarks>
        /// <param name="collectionName">The MongoDB Collection to be read from</param>
        /// <param name="fieldName">The name of the field (property) of the persisted object that will be searched for a matching regexPattern</param>
        /// <param name="regexPattern">A string representing text to search a fieldName for. An objected with an associated match will be returned as a result</param>
        /// <param name="dateTimeFieldName">The name of the field (property) of the persisted object associated with a DateTime object</param>
        /// <param name="start">The time at which search should begin</param>
        /// <param name="end">The time at which search should end</param>
        /// <returns>IEnumerable of read results from the MongoDB</returns>
        IEnumerable<T> Read<T>(string collectionName, string fieldName, string regexPattern, string dateTimeFieldName, DateTime start, DateTime end);
        /// <summary>
        /// Synchronously searches against a MongoDB collection
        /// </summary>
        /// <remarks>Proxy method to private implementation method CollectionPropertyRead</remarks>
        /// <param name="collectionName">>The MongoDB Collection to be read from</param>
        /// <param name="fieldName">The name of the field (property) of the persisted object that will be searched for a matching regexPattern</param>
        /// <param name="regexPattern">A string representing text to search a fieldName for. An objected with an associated match will be returned as a result</param>
        /// <returns>IEnumerable of read results from the MongoDB</returns>
        IEnumerable<T> Read<T>(string collectionName, string fieldName, string regexPattern);

        /// <summary>
        /// Synchronously searches against multiple MongoDB collections
        /// </summary>
        /// <remarks>Proxy method to private implementation method DateRangeRead</remarks>
        /// <param name="collectionName">The MongoDB Collection to be read from</param>
        /// <param name="dateTimeFieldName">The name of the field (property) of the persisted object associated with a DateTime object</param>
        /// <param name="start">The time at which search should begin</param>
        /// <param name="end">The time at which search should end</param>
        /// <returns>IEnumerable of read results from the MongoDB</returns>
        IEnumerable<T> Read<T>(IEnumerable<string> collectionNames, string fieldName, DateTime start, DateTime end);
        /// <summary>
        /// Synchronously searches against multiple MongoDB collections
        /// </summary>
        /// <remarks>Proxy method to private implementation method DateRangePropertyRead</remarks>
        /// <param name="collectionName">The MongoDB Collection to be read from</param>
        /// <param name="fieldName">The name of the field (property) of the persisted object that will be searched for a matching regexPattern</param>
        /// <param name="regexPattern">A string representing text to search a fieldName for. An objected with an associated match will be returned as a result</param>
        /// <param name="dateTimeFieldName">The name of the field (property) of the persisted object associated with a DateTime object</param>
        /// <param name="start">The time at which search should begin</param>
        /// <param name="end">The time at which search should end</param>
        /// <returns>IEnumerable of read results from the MongoDB</returns>
        IEnumerable<T> Read<T>(IEnumerable<string> collectionNames, string fieldName, string regexPattern, string dateTimeFieldName, DateTime start, DateTime end);
        /// <summary>
        /// Synchronously searches against multiple MongoDB collections
        /// </summary>
        /// <remarks>Proxy method to private implementation method PropertyRead</remarks>
        /// <param name="collectionName">>The MongoDB Collection to be read from</param>
        /// <param name="fieldName">The name of the field (property) of the persisted object that will be searched for a matching regexPattern</param>
        /// <param name="regexPattern">A string representing text to search a fieldName for. An objected with an associated match will be returned as a result</param>
        /// <returns>IEnumerable of read results from the MongoDB</returns>
        IEnumerable<T> Read<T>(IEnumerable<string> collectionNames, string fieldName, string regexPattern);

        IEnumerable<T> Distinct<T>(string collectionName, string fieldName);
        IEnumerable<T> Distinct<T>(string collectionName, string fieldName, IMongoQuery query);
        IEnumerable<T> Distinct<T>(IEnumerable<string> collectionNames, string fieldName);
        IEnumerable<T> Distinct<T>(IEnumerable<string> collectionNames, string fieldName, IMongoQuery query);
    }
}