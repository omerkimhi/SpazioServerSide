using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Data;
using System.Text;
using SpazioServer.Models;



public class DBServices
    {
    public SqlDataAdapter da;
    public DataTable dt;

    public DBServices()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    //--------------------------------------------------------------------------------------------------
    // This method creates a connection to the database according to the connectionString name in the web.config 
    //--------------------------------------------------------------------------------------------------
    public SqlConnection connect(String conString)
    {

        // read the connection string from the configuration file
        string cStr = WebConfigurationManager.ConnectionStrings[conString].ConnectionString;
        SqlConnection con = new SqlConnection(cStr);
        con.Open();
        return con;
    }

    
    ////---------------------------------------------------------------------------------
    //// Create the SqlCommand
    ////---------------------------------------------------------------------------------
    public SqlCommand CreateCommand(String CommandSTR, SqlConnection con)
    {

        SqlCommand cmd = new SqlCommand(); // create the command object

        cmd.Connection = con;              // assign the connection to the command object

        cmd.CommandText = CommandSTR;      // can be Select, Insert, Update, Delete 

        cmd.CommandTimeout = 30;           // Time to wait for the execution' The default is 30 seconds

        cmd.CommandType = System.Data.CommandType.Text; // the type of the command, can also be stored procedure

        return cmd;
    }


    public int insert(User user)
    {
        SqlConnection con;
        SqlCommand cmd;

        try
        {
            con = connect("database");
        }
        catch (Exception ex)
        {
            throw (ex);
        }
        String cStr = BuildInsertCommand(user);
        // cmd = CreatCommmand(cStr, con);
        cmd = CreateCommand(cStr, con);

        try
        {
            int numEffected = cmd.ExecuteNonQuery();
            return numEffected;
        }
        finally
        {
            if (con != null)
                con.Close();
        }
    }



    private String BuildInsertCommand(User user)
    {
        String command;

        StringBuilder sb = new StringBuilder();
        // use a string builder to create the dynamic string
        sb.AppendFormat("Values('{0}', '{1}' ,'{2}', '{3}','{4}')", user.Email, user.Password, user.UserName, user.PhoneNumber, user.Photo);
        String prefix = "INSERT INTO Users_2020" + "(Email,Password,UserName,PhoneNumber,Photo) ";
        command = prefix + sb.ToString();

        return command;
    }

    
    

    public List<User> readUsers()
    {
        List<User> Users = new List<User>();
        SqlConnection con = null;
        try
        {
            con = connect("database");
            string selectSTR = "SELECT * FROM Users_2020";
            SqlCommand cmd = new SqlCommand(selectSTR, con);
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            while (dr.Read())
            {   // Read till the end of the data into a row
                User u = new User();

                 u.Id = Convert.ToInt32(dr["Id"]);
                 u.Email = (string)dr["Email"];
                 u.Password = (string)dr["Password"];
                 u.UserName = (string)dr["UserName"];
                 u.PhoneNumber = (string)dr["PhoneNumber"];
                 u.Photo = (string)dr["Photo"];

                Users.Add(u);
            }
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }

        }
        return Users;
    }
    public int insert(Space space)
    {
        SqlConnection con;
        SqlCommand cmd;

        try
        {
            con = connect("database");
        }
        catch (Exception ex)
        {
            throw (ex);
        }
        String cStr = BuildInsertCommand(space);
        // cmd = CreatCommmand(cStr, con);
        cmd = CreateCommand(cStr, con);

        try
        {
            int numEffected = cmd.ExecuteNonQuery();
            return numEffected;
        }
        finally
        {
            if (con != null)
                con.Close();
        }
    }



    private String BuildInsertCommand(Space space)
    {
        String command;

        StringBuilder sb = new StringBuilder();
        // use a string builder to create the dynamic string
        sb.AppendFormat("Values('{0}', '{1}' ,'{2}', '{3}','{4}', '{5}' ,'{6}', '{7}','{8}', '{9}' ,'{10}', '{11}','{12}', '{13}' ,'{14}', '{15}')", space.Name, space.Field, space.Price, space.City, space.Street,space.Number,space.Capabillity,space.Bank,space.Branch,space.AccountNumber,space.Imageurl1,space.Imageurl2,space.Imageurl3,space.Imageurl4,space.Imageurl5,space.UserEmail);
        String prefix = "INSERT INTO Spaces_2020" + "(SpaceName,Field,Price,City,Street,Number,Capabillity,Bank,Branch,Image1,Image2,Image3,Image4,Image5,AccountNumber,FKEmail)";
        command = prefix + sb.ToString();

        return command;
    }



    public List<Space> readSpaces()
    {
        List<Space> Spaces = new List<Space>();
        SqlConnection con = null;
        try
        {
            con = connect("database");
            string selectSTR = "SELECT * FROM Spaces_2020";
            SqlCommand cmd = new SqlCommand(selectSTR, con);
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            while (dr.Read())
            {   // Read till the end of the data into a row
                Space s = new Space();

                s.Id = Convert.ToInt32(dr["SpaceId"]);
                s.Name = (string)dr["SpaceName"];
                s.Field = (string)dr["Field"];
                s.Price = Convert.ToDouble(dr["Price"]);
                s.City = (string)dr["City"];
                s.Street = (string)dr["Street"];
                s.Number = (string)dr["Number"];
                s.Capabillity = Convert.ToInt32(dr["Capabillity"]);
                s.Bank = (string)dr["Bank"];
                s.Branch = (string)dr["Branch"];
                s.AccountNumber = (string)dr["AccountNumber"];
                s.Imageurl1 = (string)dr["Image1"];
                s.Imageurl2 = (string)dr["Image2"];
                s.Imageurl3 = (string)dr["Image3"];
                s.Imageurl4 = (string)dr["Image4"];
                s.Imageurl5 = (string)dr["Image5"];
                s.UserEmail = (string)dr["FKEmail"];

                Spaces.Add(s);
            }
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }

        }
        return Spaces;
    }

    public int insert(Equipment eq)
    {
        SqlConnection con;
        SqlCommand cmd;

        try
        {
            con = connect("database");
        }
        catch (Exception ex)
        {
            throw (ex);
        }
        String cStr = BuildInsertCommand(eq);
        // cmd = CreatCommmand(cStr, con);
        cmd = CreateCommand(cStr, con);

        try
        {
            int numEffected = cmd.ExecuteNonQuery();
            return numEffected;
        }
        finally
        {
            if (con != null)
                con.Close();
        }
    }



    private String BuildInsertCommand(Equipment eq)
    {
        String command;

        StringBuilder sb = new StringBuilder();
        // use a string builder to create the dynamic string
        sb.AppendFormat("Values('{0}', '{1}')", eq.Name,eq.SpaceId);
        String prefix = "INSERT INTO Equipment_2020" + "(EquipmentName,FKSpaceId) ";
        command = prefix + sb.ToString();

        return command;
    }



    public List<Equipment> readEquipments()
    {
        List<Equipment> Equipments = new List<Equipment>();
        SqlConnection con = null;
        try
        {
            con = connect("database");
            string selectSTR = "SELECT * FROM Equipment_2020";
            SqlCommand cmd = new SqlCommand(selectSTR, con);
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            while (dr.Read())
            {   // Read till the end of the data into a row
                Equipment eq = new Equipment();

                eq.Id = Convert.ToInt32(dr["EquipmentId"]);
                eq.Name = (string)dr["EquipmentName"];
                eq.SpaceId = Convert.ToInt32(dr["FKSpaceId"]);
                Equipments.Add(eq);
            }
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }

        }
        return Equipments;
    }
    public int insert(Facility f)
    {
        SqlConnection con;
        SqlCommand cmd;

        try
        {
            con = connect("database");
        }
        catch (Exception ex)
        {
            throw (ex);
        }
        String cStr = BuildInsertCommand(f);
        // cmd = CreatCommmand(cStr, con);
        cmd = CreateCommand(cStr, con);

        try
        {
            int numEffected = cmd.ExecuteNonQuery();
            return numEffected;
        }
        finally
        {
            if (con != null)
                con.Close();
        }
    }
    private String BuildInsertCommand(Facility f)
    {
        String command;

        StringBuilder sb = new StringBuilder();
        // use a string builder to create the dynamic string
        sb.AppendFormat("Values('{0}', '{1}','{2}', '{3}','{4}', '{5}','{6}', '{7}')", f.Parking,f.Toilet,f.Kitchen,f.Intercom,f.Accessible,f.AirCondition,f.Wifi,f.SpaceId);
        String prefix = "INSERT INTO Facilities_2020" + "(Parking, Toilet, Kitchen, Intercom ,Accessible, AirCondition, WiFi, FKSpaceId)";
        command = prefix + sb.ToString();

        return command;
    }



    public List<Facility> readFacilities()
    {
        List<Facility> Facilities = new List<Facility>();
        SqlConnection con = null;
        try
        {
            con = connect("database");
            string selectSTR = "SELECT * FROM Facilities_2020";
            SqlCommand cmd = new SqlCommand(selectSTR, con);
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            while (dr.Read())
            {   // Read till the end of the data into a row
                Facility f = new Facility();

                f.Id = Convert.ToInt32(dr["FacilityId"]);
                f.Parking = Convert.ToBoolean(dr["Parking"]);
                f.Toilet = Convert.ToBoolean(dr["Toilet"]);
                f.Kitchen = Convert.ToBoolean(dr["Kitchen"]);
                f.Intercom = Convert.ToBoolean(dr["Intercom"]);
                f.Accessible = Convert.ToBoolean(dr["Accessible"]);
                f.AirCondition = Convert.ToBoolean(dr["AirCondition"]);
                f.Wifi = Convert.ToBoolean(dr["WiFi"]);
                f.SpaceId = Convert.ToInt32(dr["FKSpaceId"]);


                Facilities.Add(f);

            }
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }

        }
        return Facilities;
    }
    public int insert(Availability a)
    {
        SqlConnection con;
        SqlCommand cmd;

        try
        {
            con = connect("database");
        }
        catch (Exception ex)
        {
            throw (ex);
        }
        String cStr = BuildInsertCommand(a);
        // cmd = CreatCommmand(cStr, con);
        cmd = CreateCommand(cStr, con);

        try
        {
            int numEffected = cmd.ExecuteNonQuery();
            return numEffected;
        }
        finally
        {
            if (con != null)
                con.Close();
        }
    }
    private String BuildInsertCommand(Availability a)
    {
        String command;

        StringBuilder sb = new StringBuilder();
        // use a string builder to create the dynamic string
        sb.AppendFormat("Values('{0}', '{1}','{2}', '{3}','{4}', '{5}','{6}', '{7}')", a.Sunday,a.Monday,a.Tuesday, a.Wednesday, a.Thursday, a.Friday, a.Saturday, a.SpaceId);
        String prefix = "INSERT INTO Availability_2020" + "(Sunday,Monday,Tuesday,Wednesday,Thursday,Friday,Saturday, FKSpaceId)";
        command = prefix + sb.ToString();

        return command;
    }



    public List<Availability> readAvailabilities()
    {
        List<Availability> Availabilities = new List<Availability>();
        SqlConnection con = null;
        try
        {
            con = connect("database");
            string selectSTR = "SELECT * FROM Availability_2020";
            SqlCommand cmd = new SqlCommand(selectSTR, con);
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            while (dr.Read())
            {   // Read till the end of the data into a row
                Availability a = new Availability();

                a.Sunday = (string)dr["Sunday"];
                a.Monday = (string)dr["Monday"];
                a.Tuesday = (string)dr["Tuesday"];
                a.Wednesday = (string)dr["Wednesday"];
                a.Thursday = (string)dr["Thursday"];
                a.Friday = (string)dr["Friday"];
                a.Saturday = (string)dr["Saturday"];
                a.SpaceId = Convert.ToInt32(dr["AvailabilityId"]);

                Availabilities.Add(a);
            }
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }

        }
        return Availabilities;
    }
    public int insert(FieldEq fe)
    {
        SqlConnection con;
        SqlCommand cmd;

        try
        {
            con = connect("database");
        }
        catch (Exception ex)
        {
            throw (ex);
        }
        String cStr = BuildInsertCommand(fe);
        // cmd = CreatCommmand(cStr, con);
        cmd = CreateCommand(cStr, con);

        try
        {
            int numEffected = cmd.ExecuteNonQuery();
            return numEffected;
        }
        finally
        {
            if (con != null)
                con.Close();
        }
    }
    private String BuildInsertCommand(FieldEq fe)
    {
        String command;

        StringBuilder sb = new StringBuilder();
        // use a string builder to create the dynamic string
        sb.AppendFormat("Values('{0}', '{1}','{2}')", fe.Id, fe.Field, fe.Name);
        String prefix = "INSERT INTO FieldEquipment_2020" + "(EquipmentId,Field,EquipmentName)";
        command = prefix + sb.ToString();

        return command;
    }



    public List<FieldEq> readFieldsEq()
    {
        List<FieldEq> FieldsEq = new List<FieldEq>();
        SqlConnection con = null;
        try
        {
            con = connect("database");
            string selectSTR = "SELECT * FROM FieldEquipment_2020";
            SqlCommand cmd = new SqlCommand(selectSTR, con);
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            while (dr.Read())
            {   // Read till the end of the data into a row
                FieldEq fe = new FieldEq();

                fe.Id = Convert.ToInt32(dr["EquipmentId"]);
                fe.Field = (string)dr["Field"];
                fe.Name = (string)dr["EquipmentName"];



                FieldsEq.Add(fe);
            }
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }

        }
        return FieldsEq;
    }




}
