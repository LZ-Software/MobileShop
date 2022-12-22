package com.lz.mobileshop;

import android.app.Activity;
import android.widget.Toast;

import java.sql.CallableStatement;
import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;

public class Database
{
    static final String JDBC_DRIVER = "org.postgresql.Driver";
    static final String DB_URL = "jdbc:postgresql://10.0.2.2:5432/mobile_shop";

    static final String USER = "postgres";
    static final String PASS = "keker227";

    private Connection connection = null;
    private Statement statement = null;
    private CallableStatement callableStatement = null;
    private ResultSet resultSet = null;

    private Activity activity = null;

    public ResultSet executeQuery(String query, Activity act)
    {
        activity = act;

        try
        {
            Class.forName(JDBC_DRIVER);
            connection = DriverManager.getConnection(DB_URL, USER, PASS);
            statement = connection.createStatement();
            resultSet = statement.executeQuery(query);
        }
        catch (SQLException | ClassNotFoundException e)
        {
            activity.runOnUiThread(new Runnable()
            {
                public void run()
                {
                    Toast.makeText(activity.getApplicationContext(), e.getMessage(), Toast.LENGTH_LONG).show();
                }
            });
        }

        return resultSet;
    }

    public boolean callStatement(String query, Activity act, String... parameters)
    {
        activity = act;

        int i = 1;

        try
        {
            Class.forName(JDBC_DRIVER);
            connection = DriverManager.getConnection(DB_URL, USER, PASS);
            callableStatement = connection.prepareCall(query);

            for (String param : parameters)
            {
                callableStatement.setString(i++, param);
            }

            return callableStatement.execute();
        }
        catch (SQLException | ClassNotFoundException e)
        {
            activity.runOnUiThread(new Runnable()
            {
                public void run()
                {
                    Toast.makeText(activity.getApplicationContext(), e.getMessage(), Toast.LENGTH_LONG).show();
                }
            });

            return false;
        }
    }

    public void close()
    {
        try
        {
            resultSet.close();
            statement.close();
            connection.close();
        }
        catch (SQLException e)
        {
            activity.runOnUiThread(new Runnable()
            {
                public void run()
                {
                    Toast.makeText(activity.getApplicationContext(), e.getMessage(), Toast.LENGTH_LONG).show();
                }
            });
        }
        catch (NullPointerException ignored) {}
    }
}
