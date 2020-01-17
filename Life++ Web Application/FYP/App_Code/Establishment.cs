using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


public class Establishment
{
    public string ID { get; set; }
    public string Email { get; set; }
    public string Name { get; set; }
    public string Password { get; set; }
    public string Type { get; set; }
    public int Phone { get; set; }
    public string Address { get; set; }
    public string Status { get; set; }
    public Admins Admin { get; set; }

    public Establishment()
    {

    }

    public Establishment(string id, string email, string name, string password, string type, int phone, string address, string status)
    {
        ID = id;
        Email = email;
        Name = name;
        Password = password;
        Type = type;
        Phone = phone;
        Address = address;
        Status = status;
    }

    public Establishment(string email, string name, string password, string type, int phone, string address)
    {
        Email = email;
        Name = name;
        Password = password;
        Type = type;
        Phone = phone;
        Address = address;
    }

    public Establishment(string email, string name, string password, string type, int phone, string address, string id, Admins admin)
    {
        Email = email;
        Name = name;
        Password = password;
        Type = type;
        Phone = phone;
        Address = address;
        Admin = admin;
        ID = id;
    }

    public Establishment(string email, string name)
    {
        Email = email;
        Name = name;
    }
}