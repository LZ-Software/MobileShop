package com.lz.mobileshop.db;

import android.app.Activity;
import android.content.Context;
import android.widget.Toast;

import com.lz.mobileshop.Environment;

import java.sql.CallableStatement;
import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;

public class Database
{
    static final String JDBC_DRIVER = "org.postgresql.Driver";
    static String DB_URL = "";

    static String USER = "";
    static String PASS = "";

    private Connection connection = null;

    private PreparedStatement preparedStatement = null;
    private CallableStatement callableStatement = null;

    private ResultSet resultSet = null;

    private Activity activity = null;

    public Database(Context context, String user, String pass)
    {
        String host = Environment.getValue(context, "DB_HOST");
        String port = Environment.getValue(context, "DB_PORT");
        String database = Environment.getValue(context, "DB_DATABASE");

        DB_URL = String.format("jdbc:postgresql://%s:%s/%s", host, port, database);
        USER = user;
        PASS = pass;
    }

    public Database() {}

    public ResultSet executeQuery(String query, Activity act, Object... parameters)
    {
        activity = act;
        int i = 1;

        try
        {
            Class.forName(JDBC_DRIVER);
            connection = DriverManager.getConnection(DB_URL, USER, PASS);
            preparedStatement = connection.prepareStatement(query);

            for (Object parameter : parameters)
            {
                if (parameter instanceof String)
                {
                    preparedStatement.setString(i++, (String) parameter);
                }
                else if (parameter instanceof Integer)
                {
                    preparedStatement.setInt(i++, (int) parameter);
                }
                else if (parameter instanceof Float)
                {
                    preparedStatement.setFloat(i++, (float) parameter);
                }
                else if (parameter instanceof Double)
                {
                    preparedStatement.setDouble(i++, (double) parameter);
                }
                else if (parameter instanceof Boolean)
                {
                    preparedStatement.setBoolean(i++, (boolean) parameter);
                }
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

    public boolean callStatement(String query, Activity act, Object... parameters)
    {
        activity = act;

        int i = 1;

        try
        {
            Class.forName(JDBC_DRIVER);
            connection = DriverManager.getConnection(DB_URL, USER, PASS);
            callableStatement = connection.prepareCall(query);

            for (Object parameter : parameters)
            {
                if (parameter instanceof String)
                {
                    callableStatement.setString(i++, (String) parameter);
                }
                else if (parameter instanceof Integer)
                {
                    callableStatement.setInt(i++, (int) parameter);
                }
                else if (parameter instanceof Float)
                {
                    callableStatement.setFloat(i++, (float) parameter);
                }
                else if (parameter instanceof Double)
                {
                    callableStatement.setDouble(i++, (double) parameter);
                }
                else if (parameter instanceof Boolean)
                {
                    callableStatement.setBoolean(i++, (boolean) parameter);
                }
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
