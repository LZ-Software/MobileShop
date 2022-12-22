package com.lz.mobileshop.db;

import android.app.Activity;
import android.widget.Toast;

import java.sql.CallableStatement;
import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;

public class Database
{
    static final String JDBC_DRIVER = "org.postgresql.Driver";
    static final String DB_URL = "jdbc:postgresql://10.0.2.2:5432/mobile_shop";

    static String USER = "";
    static String PASS = "";

    private Connection connection = null;
    private PreparedStatement preparedStatement = null;
    private CallableStatement callableStatement = null;
    private ResultSet resultSet = null;

    private Activity activity = null;

    public Database(String user, String pass)
    {
        USER = user;
        PASS = pass;
    }

    public Database()
    {

    }

    public ResultSet executeQuery(String query, Activity act, String... parameters)
    {
        activity = act;
        int i = 1;

        try
        {
            Class.forName(JDBC_DRIVER);
            connection = DriverManager.getConnection(DB_URL, USER, PASS);
            preparedStatement = connection.prepareStatement(query);

            for (String parameter : parameters)
            {
                preparedStatement.setString(i++, parameter);
            }

            resultSet = preparedStatement.executeQuery();
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

    public ResultSet executeQuery(String query, Activity act, Object parameter)
    {
        activity = act;

        try
        {
            Class.forName(JDBC_DRIVER);
            connection = DriverManager.getConnection(DB_URL, USER, PASS);
            preparedStatement = connection.prepareStatement(query);

            if (parameter instanceof String)
            {
                preparedStatement.setString(1, (String) parameter);
            }
            else if (parameter instanceof Integer)
            {
                preparedStatement.setInt(1, (int) parameter);
            }
            else if (parameter instanceof Float)
            {
                preparedStatement.setFloat(1, (float) parameter);
            }
            else if (parameter instanceof Double)
            {
                preparedStatement.setDouble(1, (double) parameter);
            }
            else if (parameter instanceof Boolean)
            {
                preparedStatement.setBoolean(1, (boolean) parameter);
            }

            resultSet = preparedStatement.executeQuery();
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
            preparedStatement.close();
            callableStatement.close();
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
