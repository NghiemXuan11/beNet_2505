using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace EX_14
{
    public class AttributeService
    {
        private DatabaseHelper db;

        public AttributeService(DatabaseHelper db)
        {
            this.db = db;
        }

        public void AddAttribute(int attributeId, string attributeName, string attributeValue, int groupId)
        {
            ValidateAttribute(attributeId, attributeName, attributeValue, groupId);
            SqlParameter[] parameters = {
            new SqlParameter("@attribute_id", attributeId),
            new SqlParameter("@attribute_name", attributeName),
            new SqlParameter("@attribute_value", attributeValue),
            new SqlParameter("@group_id", groupId)
        };
            db.ExecuteNonQuery("AddAttribute", parameters);
        }

        public void UpdateAttribute(int attributeId, string attributeName, string attributeValue, int groupId)
        {
            ValidateAttribute(attributeId, attributeName, attributeValue, groupId);
            SqlParameter[] parameters = {
            new SqlParameter("@attribute_id", attributeId),
            new SqlParameter("@attribute_name", attributeName),
            new SqlParameter("@attribute_value", attributeValue),
            new SqlParameter("@group_id", groupId)
        };
            db.ExecuteNonQuery("UpdateAttribute", parameters);
        }

        public void DeleteAttribute(int attributeId)
        {
            if (attributeId <= 0)
            {
                throw new ArgumentException("Attribute ID must be a positive integer.");
            }

            SqlParameter[] parameters = {
            new SqlParameter("@attribute_id", attributeId)
        };
            db.ExecuteNonQuery("DeleteAttribute", parameters);
        }

        private void ValidateAttribute(int attributeId, string attributeName, string attributeValue, int groupId)
        {
            if (attributeId <= 0)
            {
                throw new ArgumentException("Attribute ID must be a positive integer.");
            }

            if (string.IsNullOrWhiteSpace(attributeName))
            {
                throw new ArgumentException("Attribute name must not be empty.");
            }

            if (string.IsNullOrWhiteSpace(attributeValue))
            {
                throw new ArgumentException("Attribute value must not be empty.");
            }

            if (groupId <= 0)
            {
                throw new ArgumentException("Group ID must be a positive integer.");
            }
        }
    }
}
