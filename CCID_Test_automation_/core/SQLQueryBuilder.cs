using System.Text;
using System.Data;


namespace CCID_Test_automation_.core
{
    public static class SQlQueryBuilder
    {
        /*
         * Returns a string containing all the fields in the table
         * Returns a list of all the columns in the DataTable in SQL format which can be used in a SELECT command etc. E.g.: CustomerID, CustomerName, ....
        */
        public static string BuildAllFieldsSQL(DataTable table)
        {
            string sql = "";
            foreach (DataColumn column in table.Columns)
            {
                if (sql.Length > 0)
                    sql += ", ";
                sql += column.ColumnName;
            }
            return sql;
        }
        /*
         * Returns a SQL INSERT command. Assumes autoincrement is identity (optional)
         * Returns an INSERT command with an optional SELECT CAST statement to get the SCOPE_IDENTITY if required. E.g.: INSERT INTO tableName ( CustomerName,...) VALUES (@CustomerName,...); SELECT CAST(scope_identity() AS int ). (Note that in this example, CustomerID is an Identity so it isn't included in the string.)
        */
        public static string BuildInsertSQL(DataTable table)
        {
            StringBuilder sql = new StringBuilder("INSERT INTO " + table.TableName + " (");
            StringBuilder values = new StringBuilder("VALUES (");
            bool bFirst = true;
            bool bIdentity = false;
            string identityType = null;

            foreach (DataColumn column in table.Columns)
            {
                if (column.AutoIncrement)
                {
                    bIdentity = true;

                    identityType = column.DataType.Name switch
                    {
                        "Int16" => "smallint",
                        "SByte" => "tinyint",
                        "Int64" => "bigint",
                        "Decimal" => "decimal",
                        _ => "int",
                    };
                }
                else
                {
                    if (bFirst)
                        bFirst = false;
                    else
                    {
                        sql.Append(", ");
                        values.Append(", ");
                    }

                    sql.Append(column.ColumnName);
                    values.Append("@");
                    values.Append(column.ColumnName);
                }
            }
            sql.Append(") ");
            sql.Append(values.ToString());
            sql.Append(")");

            if (bIdentity)
            {
                sql.Append("; SELECT CAST(scope_identity() AS ");
                sql.Append(identityType);
                sql.Append(")");
            }

            return sql.ToString(); ;
        }
    }
}
