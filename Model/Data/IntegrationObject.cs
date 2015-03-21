using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Data
{
    public abstract class IntegrationObject
    {
        /// <summary>
        /// An enumeration of possible record source query operations.
        /// </summary>
        public enum RequestType { Delete, Read, Upsert };

        /// <summary>
        /// An enumeration of possible records types to query.
        /// </summary>
        public enum RecordType
        {
            AttributeItem, AttributeSchema,
            GameObject, GameObjectSchema,
            Property, PropertySchema
        };
    }
}
