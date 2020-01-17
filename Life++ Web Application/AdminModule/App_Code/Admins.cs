using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Admins
/// </summary>
public class Admins
{
    public string adminId;
    public string email;
    public string name;
    public string password;
    public string address;
    public int phone;
    public string status;

    public Admins() { }
    public Admins(string email, string name, string password, string address, int phone, string status)
    {
        this.email = email;
        this.name = name;
        this.password = password;
        this.address = address;
        this.phone = phone;
        this.status = status;
    }

    public string AdminId
    {
        get { return adminId; }
        set { adminId = value; }
    }

    public string Email
    {
        get { return email; }
        set { email = value; }
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public string Password
    {
        get { return password; }
        set { password = value; }
    }

    public string Address
    {
        get { return address; }
        set { address = value; }
    }

    public int Phone
    {
        get { return phone; }
        set { phone = value; }
    }

    public string Status
    {
        get { return status; }
        set { status = value; }
    }
}