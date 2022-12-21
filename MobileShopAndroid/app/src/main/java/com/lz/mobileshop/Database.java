package com.lz.mobileshop;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;

public class Database
{
    static final String JDBC_DRIVER = "org.postgresql.Driver";
    static final String DB_URL = "jdbc:postgresql://10.0.2.2:5432/mirea";

    static final String USER = "postgres";
    static final String PASS = "keker227";

    public ResultSet executeQuery(String query)
    {
        Connection connection = null;
        Statement statement = null;
        ResultSet resultSet = null;

        try
        {
            Class.forName(JDBC_DRIVER);

            connection = DriverManager.getConnection(DB_URL, USER, PASS);

            statement = connection.createStatement();

            resultSet = statement.executeQuery(query);

            resultSet.close();
            statement.close();
            connection.close();
        }
        catch (SQLException | ClassNotFoundException se)
        {
            // TODO: Вывод ошибки
        }
        finally
        {
            try
            {
                if (statement!=null)
                {
                    statement.close();
                }
            }
            catch (SQLException ignored) {}

            try
            {
                if (connection!=null)
                {
                    connection.close();
                }
            }
            catch (SQLException se)
            {
                se.printStackTrace();
            }
        }

        return resultSet;
    }
}
