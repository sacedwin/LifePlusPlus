using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for AUser
/// </summary>
public class AUser
{
    public string userId;
    public string email;
    public string name;
    public DateTime dob;
    public string gender;
    public string rstatus;
    public int height;
    public int weight;
    public string bloodtype;
    public string username;
    public string password;
    public int phone;
    public string nric;
    public string emergencyname;
    public int emergencyphone;
    public string emergencyrelationship;
    public string status;
    public string address;
    public int zipcode;
    public string nationality;
    public string profilepic;
    public string doneby;
    public string medicalStatus;
    public string medicalStatusUpdateBy;
    public string latitude;
    public string longtitude;

    public AUser() { }

    public AUser(string email, string name, DateTime dob, string gender, string rstatus, int height, int weight, string bloodtype, string username, string password, int phone, string nric, string emergencyname, int emergencyphone, string emergencyrelationship, string status, string address, int zipcode, string nationality, string profilepic, string doneby, string medicalStatus, string medicalStatusUpdateBy, string latitude, string longtitude)
    {
        this.email = email;
        this.name = name;
        this.dob = dob;
        this.gender = gender;
        this.rstatus = rstatus;
        this.height = height;
        this.weight = weight;
        this.bloodtype = bloodtype;
        this.username = username;
        this.password = password;
        this.phone = phone;
        this.nric = nric;
        this.emergencyname = emergencyname;
        this.emergencyphone = emergencyphone;
        this.emergencyrelationship = emergencyrelationship;
        this.status = status;
        this.address = address;
        this.zipcode = zipcode;
        this.nationality = nationality;
        this.profilepic = profilepic;
        this.doneby = doneby;
        this.medicalStatus = medicalStatus;
        this.medicalStatusUpdateBy = medicalStatusUpdateBy;
        this.latitude = latitude;
        this.longtitude = longtitude;
    }

    public string MedicalStatus
    {
        get { return medicalStatus; }
        set { medicalStatus = value; }
    }
    public string MedicalStatusUpdateBy
    {
        get { return medicalStatusUpdateBy; }
        set { medicalStatusUpdateBy = value; }
    }

    public string Latitude
    {
        get { return latitude; }
        set { latitude = value; }
    }

    public string Longtitude
    {
        get { return longtitude; }
        set { longtitude = value; }
    }

    public string UserId
    {
        get { return userId; }
        set { userId = value; }
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

    public DateTime DOB
    {
        get { return dob; }
        set { dob = value; }
    }

    public string Gender
    {
        get { return gender; }
        set { gender = value; }
    }

    public string Rstatus
    {
        get { return rstatus; }
        set { rstatus = value; }
    }

    public int Height
    {
        get { return height; }
        set { height = value; }
    }

    public int Weight
    {
        get { return weight; }
        set { weight = value; }
    }

    public string BloodType
    {
        get { return bloodtype; }
        set { bloodtype = value; }
    }

    public string Username
    {
        get { return username; }
        set { username = value; }
    }

    public string Password
    {
        get { return password; }
        set { password = value; }
    }

    public int Phone
    {
        get { return phone; }
        set { phone = value; }
    }

    public string Nric
    {
        get { return nric; }
        set { nric = value; }
    }

    public string Emergencyname
    {
        get { return emergencyname; }
        set { emergencyname = value; }
    }

    public int Emergencyphone
    {
        get { return emergencyphone; }
        set { emergencyphone = value; }
    }

    public string Emergencyrelationship
    {
        get { return emergencyrelationship; }
        set { emergencyrelationship = value; }
    }

    public string Status
    {
        get { return status; }
        set { status = value; }
    }

    public string Address
    {
        get { return address; }
        set { address = value; }
    }

    public int ZipCode
    {
        get { return zipcode; }
        set { zipcode = value; }
    }

    public string Nationality
    {
        get { return nationality; }
        set { nationality = value; }
    }

    public string Profilepic
    {
        get { return profilepic; }
        set { profilepic = value; }
    }

    public string Doneby
    {
        get { return doneby; }
        set { doneby = value; }
    }
}