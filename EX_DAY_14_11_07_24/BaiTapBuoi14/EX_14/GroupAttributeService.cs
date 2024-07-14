using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace EX_14
{
    public class GroupAttributeService
    {
        private DatabaseHelper db;

        public GroupAttributeService(DatabaseHelper db)
        {
            this.db = db;
        }

        public void AddGroupAttribute(int groupId, string groupName, string price)
        {
            ValidateGroupAttribute(groupId, groupName, price);
            SqlParameter[] parameters = {
            new SqlParameter("@group_id", groupId),
            new SqlParameter("@group_name", groupName),
            new SqlParameter("@price", price)
        };
            db.ExecuteNonQuery("AddGroupAttribute", parameters);
        }

        public void UpdateGroupAttribute(int groupId, string groupName, string price)
        {
            ValidateGroupAttribute(groupId, groupName, price);
            SqlParameter[] parameters = {
            new SqlParameter("@group_id", groupId),
            new SqlParameter("@group_name", groupName),
            new SqlParameter("@price", price)
        };
            db.ExecuteNonQuery("UpdateGroupAttribute", parameters);
        }

        public void DeleteGroupAttribute(int groupId)
        {
            if (groupId <= 0)
            {
                throw new ArgumentException("Group ID must be a positive integer.");
            }

            SqlParameter[] parameters = {
            new SqlParameter("@group_id", groupId)
        };
            db.ExecuteNonQuery("DeleteGroupAttribute", parameters);
        }

        private void ValidateGroupAttribute(int groupId, string groupName, string price)
        {
            if (groupId <= 0)
            {
                throw new ArgumentException("Group ID must be a positive integer.");
            }

            if (string.IsNullOrWhiteSpace(groupName))
            {
                throw new ArgumentException("Group name must not be empty.");
            }

            if (string.IsNullOrWhiteSpace(price))
            {
                throw new ArgumentException("Price must not be empty.");
            }
        }
    }
}
